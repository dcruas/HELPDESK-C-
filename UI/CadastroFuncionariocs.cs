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

namespace UI
{
    public partial class CadastroFuncionariocs : Form
    {
        FuncionarioBLL FuncionarioBLL;
       
        

        

        public CadastroFuncionariocs(string usuario)
        {
            InitializeComponent();
            FuncionarioBLL = new FuncionarioBLL();
            lblUsuario.Text = usuario;
            
        }

        public void LimparCampos()
        {

            txtAdmissao.Text = "";
            txtAndar.Text = "";
            txtCelular.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtMatricula.Text = "";
            txtNome.Text = "";
            txtPesquisar.Text = "";
            txtRamal.Text = "";
            txtSala.Text = "";
            txtSenha.Text = "";
           
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbMatricula.Checked == true)

            {
                if (txtPesquisar.TextLength != 8 )
                {   
                    MessageBox.Show("Você digitou um valor errado, a matrícula de um funcionário é composta de 8 dígitos");
                }
                else
                {
                    List<Funcionario> funcionarios = new List<Funcionario>();
                    Funcionario funcionario = new Funcionario();
                    funcionario = FuncionarioBLL.ProcurarMatricula(int.Parse(txtPesquisar.Text));
                    funcionarios.Add(funcionario);
                    dgvFuncionario.DataSource = null;
                    dgvFuncionario.DataSource = funcionarios;
                }
                
            }
            else
            {
                List<Funcionario> funcionarios = new List<Funcionario>();
                dgvFuncionario.DataSource = null;
                funcionarios = FuncionarioBLL.ProcurarNome("%"+txtPesquisar.Text+"%");
                dgvFuncionario.DataSource = funcionarios;
            }
            
           
        }

        private void CadastroFuncionariocs_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text == "")
            {
                Funcionario funcionario = new Funcionario();
                funcionario.matricula = 20000000 + FuncionarioBLL.ultimoIdBLL()+1;
                if (rdbTecnico.Checked == true)
                {
                    funcionario.codacesso = 1;
                }
                else
                {
                    funcionario.codacesso = 2;
                }
                if (rdbAtivo.Checked == true)
                {
                    funcionario.situacao = 1;
                }
                else
                {
                    funcionario.situacao = 2;
                }
                funcionario.nome = txtNome.Text;
                funcionario.andar = int.Parse(txtAndar.Text);
                funcionario.sala = int.Parse(txtSala.Text);
                funcionario.ramal = int.Parse(txtRamal.Text);
                funcionario.celular = int.Parse(txtCelular.Text);
                funcionario.email = txtEmail.Text;
                funcionario.dataAdmissao = txtAdmissao.Text;
                funcionario.senha = txtSenha.Text;
                funcionario.cpf = txtCPF.Text;
                FuncionarioBLL.InserirFuncionario(funcionario);
                LimparCampos();

            }
            else
            {
                Funcionario funcionario = new Funcionario();
                
                if (rdbTecnico.Checked == true)
                {
                    funcionario.codacesso = 1;
                }
                else
                {
                    funcionario.codacesso = 2;
                }
                if (rdbAtivo.Checked == true)
                {
                    funcionario.situacao = 1;
                }
                else
                {
                    funcionario.situacao = 2;
                }
                funcionario.nome = txtNome.Text;
                funcionario.andar = int.Parse(txtAndar.Text);
                funcionario.sala = int.Parse(txtSala.Text);
                funcionario.ramal = int.Parse(txtRamal.Text);
                funcionario.celular = int.Parse(txtCelular.Text);
                funcionario.dataAdmissao = txtAdmissao.Text;
                funcionario.matricula = int.Parse(txtMatricula.Text);
                funcionario.cpf = txtCPF.Text;
                if (txtCPF.TextLength != 11 || txtCelular.TextLength != 11)
                {
                    MessageBox.Show("Verifique se o CPF contém 11 digítos ou se o celular contém o DDD");
                }
                else
                {
                    FuncionarioBLL.AtualizarFuncionario(funcionario);
                }
                LimparCampos();
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtEmail.Enabled = true;
            txtSenha.Enabled = true;
                                 
        }

        private void dgvFuncionario_DoubleClick(object sender, EventArgs e)
        {
            int codacesso, situacao;

            
            txtNome.Text = dgvFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtAndar.Text = dgvFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtSala.Text = dgvFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtRamal.Text = dgvFuncionario.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = dgvFuncionario.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = dgvFuncionario.CurrentRow.Cells[7].Value.ToString();
            txtAdmissao.Text = dgvFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtMatricula.Text = dgvFuncionario.CurrentRow.Cells[9].Value.ToString();
            situacao = int.Parse(dgvFuncionario.CurrentRow.Cells[10].Value.ToString());
            txtCPF.Text = dgvFuncionario.CurrentRow.Cells[12].Value.ToString();
            dgvFuncionario.Columns[11].Visible = false;
            codacesso = int.Parse(dgvFuncionario.CurrentRow.Cells[1].Value.ToString());
            if (codacesso == 1)
            {
                rdbAtivo.Checked = true;
            }
            else
            {
                rdbInativo.Checked = true;
            }

            if (situacao == 1)
            {
                rdbTecnico.Checked = true;
            }
            else
            {
                rdbComum.Checked = true;
            }
            txtSenha.Enabled = false;
            txtEmail.Enabled = false;


        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbMatricula.Checked == true)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }

        private void txtRamal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }

        private void txtSala_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }

        private void txtAndar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {

        }
    }
}
