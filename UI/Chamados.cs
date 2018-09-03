using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Data.SqlClient;
using System.Net.Mail;
namespace UI
{
    
    public partial class Chamados : Form
    {
        FuncionarioBLL FuncionarioBLL;
        ChamadoBLL ChamadoBLL;
        Chamado chamado = new Chamado();
        string buffer;
        

        public Chamados(string usuario)
        {
            InitializeComponent();
            FuncionarioBLL = new FuncionarioBLL();
            ChamadoBLL = new ChamadoBLL();
            lblUsuario.Text = usuario;
            FillCombobox();
        }

        public void LimparCampos()
        {
            txtSolicitante.Text = "";
            txtNome.Text = "";
            txtAndar.Text = "";
            txtSala.Text = "";
            txtRamal.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtDescricao.Text = "";
        }

        protected void FillCombobox() // Método que preenche o combobox com os tipos de problemas existentes.
        {
            SqlConnection conexao;
            // Linha que lê o caminho do banco de dados //
            string caminho = @"" + System.IO.File.ReadAllText("caminho.txt");

            conexao = new SqlConnection(caminho);

            DataSet ds = new DataSet();
            try
            {
                conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT CD_PROBLEMA, NM_PROBLEMA FROM TB_PROBLEMA group by CD_PROBLEMA, NM_PROBLEMA", conexao);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(ds);
                cmbTipo.DisplayMember = "NM_PROBLEMA";
                cmbTipo.ValueMember = "CD_PROBLEMA";
                cmbTipo.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                //Exception Message
            }
            finally
            {
                conexao.Close();

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbMatricula.Checked == true)

            {
                if (txtPesquisar.TextLength != 8)
                {
                    MessageBox.Show("Você digitou um valor errado, a matrícula de um funcionário é composta de 8 dígitos");
                }
                else
                {
                    List<Funcionario> funcionarios = new List<Funcionario>();
                    Funcionario funcionario = new Funcionario();
                    funcionario = FuncionarioBLL.ProcurarMatricula(int.Parse(txtPesquisar.Text));
                    List<Chamado> chamados = new List<Chamado>();
                    Chamado chamado = new Chamado();
                    chamados = ChamadoBLL.ProcurarMatricula(funcionario.codigo);
                  
                    dgvChamados.DataSource = null;
                    dgvChamados.DataSource = chamados;
                }

            }
            else
            {
                List<Chamado> chamados = new List<Chamado>();
                Chamado chamado = new Chamado();
                chamado = ChamadoBLL.ProcurarProtocolo(int.Parse(txtPesquisar.Text));
                chamados.Add(chamado);
                dgvChamados.DataSource = null;
                dgvChamados.DataSource = chamados;
            }

        }

        private void Chamados_Load(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtSolicitante.TextLength == 8)
            {
                Funcionario funcionario = new Funcionario();
                funcionario = FuncionarioBLL.ProcurarMatricula(int.Parse(txtSolicitante.Text));
                if (funcionario.codigo > 0)
                {
                    txtSolicitante.Text = (funcionario.codigo + 20000000).ToString();
                    txtNome.Text = funcionario.nome;
                    txtAndar.Text = funcionario.andar.ToString();
                    txtSala.Text = funcionario.sala.ToString();
                    txtRamal.Text = funcionario.ramal.ToString();
                    txtCelular.Text = funcionario.celular.ToString();
                    txtEmail.Text = funcionario.email;
                }
                else
                {
                    MessageBox.Show("Matrícula não encontrada, verifique se os dados foram digitados corretamente");
                }
            }
            else
            {
                MessageBox.Show("Verifique se foi digitado os 8 dígitos da matrícula");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtSolicitante.Enabled == true)
            {
                Chamado chamado = new Chamado();
                DateTime dateTime = DateTime.Now;
                string dia = dateTime.Day.ToString();
                string mes = dateTime.Month.ToString();
                string ano = dateTime.Year.ToString();
                chamado.dataAbertura = ano + "-" + mes + "-" + dia;
                chamado.descricao = txtDescricao.Text;
                chamado.codfuncionario = int.Parse(txtSolicitante.Text) - 20000000;
                chamado.codproblema = int.Parse(cmbTipo.SelectedValue.ToString());
                chamado.codstatus = 1;
                ChamadoBLL.IncluirChamado(chamado);
                chamado.codigo = ChamadoBLL.ultimoId();
                // Configuração de mensagem que será enviada para o usuário
                SmtpClient smtp = new SmtpClient();
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress("helpfastpim@gmail.com", "Daniel");
                mensagem.To.Add(txtEmail.Text);
                mensagem.Subject = ("Abertura de chamado - Protocolo" + chamado.codigo.ToString());
                mensagem.IsBodyHtml = true;
                mensagem.Body = "<h1> Pode ficar tranquilo, recebemos seu chamado e em breve um de nossos técnicos visitarão sua sala, enquanto isso, guarde o número de protocolo enviado neste e-mail para futuras consultas </h1> <br> Protocolo: " + chamado.codigo.ToString();
                mensagem.Priority = MailPriority.Normal;
                // Configuração do Servidor de e-mail e credenciais
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("helpfastpim@gmail.com", "HELPFASTADS4");
                smtp.Send(mensagem);
                LimparCampos();
                MessageBox.Show("Chamado aberto com sucesso");
            }
            else
            {
                Chamado chamado = new Chamado();
                chamado.descricao = txtDescricao.Text;
                chamado.codproblema = int.Parse(cmbTipo.SelectedValue.ToString());
                ChamadoBLL.AtualizarChamado(chamado);
                LimparCampos();
                MessageBox.Show("Chamado atualizado com sucesso");
            }
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvChamados_DoubleClick(object sender, EventArgs e)
        {
            
            chamado.codigo = int.Parse(dgvChamados.CurrentRow.Cells[0].Value.ToString());
            chamado.codtecnico = int.Parse(dgvChamados.CurrentRow.Cells[1].Value.ToString());
            chamado.dataAbertura = dgvChamados.CurrentRow.Cells[2].Value.ToString();
            chamado.justificativa = dgvChamados.CurrentRow.Cells[3].Value.ToString();
            chamado.descricao = dgvChamados.CurrentRow.Cells[4].Value.ToString();
            chamado.dataEncerramento = dgvChamados.CurrentRow.Cells[5].Value.ToString();
            chamado.codfuncionario = int.Parse(dgvChamados.CurrentRow.Cells[6].Value.ToString());
            chamado.codstatus = int.Parse(dgvChamados.CurrentRow.Cells[7].Value.ToString());
            chamado.codavaliacao = int.Parse(dgvChamados.CurrentRow.Cells[8].Value.ToString());

            Funcionario funcionario = new Funcionario();
            funcionario = FuncionarioBLL.ProcurarMatricula(chamado.codfuncionario + 20000000);
       
            
            txtSolicitante.Text = (chamado.codfuncionario + 20000000).ToString();
            txtNome.Text = funcionario.nome;
            txtAndar.Text = funcionario.andar.ToString();
            txtSala.Text = funcionario.sala.ToString();
            txtRamal.Text = funcionario.ramal.ToString();
            txtCelular.Text = funcionario.celular.ToString();
            txtEmail.Text = funcionario.email;
            txtDescricao.Text = chamado.descricao;
            txtSolicitante.Enabled = false;
            btnValidar.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSolicitante.Enabled = true;
            btnValidar.Enabled = true;
            LimparCampos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Chamado> chamados = new List<Chamado>();
            Chamado chamado = new Chamado();
            if (cmbStatus.SelectedIndex == 0)
            {
                chamado.dataAbertura = txtDataInicial.Text;
                chamado.dataEncerramento = txtDataFinal.Text;
                chamado.codstatus = 2;
            }
            else if (cmbStatus.SelectedIndex == 1)
            {
                chamado.dataAbertura = txtDataInicial.Text;
                chamado.dataEncerramento = txtDataFinal.Text;
                chamado.codstatus = 4;
            }
            else
            {
                chamado.dataAbertura = txtDataInicial.Text;
                chamado.dataEncerramento = txtDataFinal.Text;
                chamado.codstatus = 6;
            }
            chamados = ChamadoBLL.FiltroChamados(chamado);
            dgvChamados.DataSource = null;
            dgvChamados.DataSource = chamados;
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            chamado.codigo = int.Parse(dgvChamados.CurrentRow.Cells[0].Value.ToString());
            chamado.codtecnico = int.Parse(lblUsuario.Text) - 20000000;
            chamado.dataAbertura = dgvChamados.CurrentRow.Cells[2].Value.ToString();
            chamado.justificativa = dgvChamados.CurrentRow.Cells[3].Value.ToString();
            chamado.descricao = dgvChamados.CurrentRow.Cells[4].Value.ToString();
            chamado.dataEncerramento = dgvChamados.CurrentRow.Cells[5].Value.ToString();
            chamado.codfuncionario = int.Parse(dgvChamados.CurrentRow.Cells[6].Value.ToString());
            chamado.codstatus = int.Parse(dgvChamados.CurrentRow.Cells[7].Value.ToString());
            chamado.codavaliacao = int.Parse(dgvChamados.CurrentRow.Cells[8].Value.ToString());
            frmEncerrar encerrar = new frmEncerrar(lblUsuario.Text, chamado);
            encerrar.Show();

            
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            frmRelatorio relatorio = new frmRelatorio();
            relatorio.Show();
        }
    }
}
