using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using DTO;
using BLL;
using System.Data.SqlClient;

namespace UI
{
    public partial class frmSenha : Form
    {

        FuncionarioBLL FuncionarioBLL;
        Funcionario funcionario = new Funcionario(); // instância objeto funcionário para receber informações


        public frmSenha()
        {
            InitializeComponent();
            FuncionarioBLL = new FuncionarioBLL();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmImrpimir_Load(object sender, EventArgs e)
        {

        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtMatricula.TextLength != 8) // Verificia se matrícula possui 8 dígitos antes de tentar verificar o banco de dados
            {
                MessageBox.Show("Verifique se existem 8 dígitos no campo matrícula");
            }
            else
            {
                funcionario = FuncionarioBLL.ValidarLogin(int.Parse(txtMatricula.Text), txtSenha.Text); // Com base no texto inserido na caixa de texto matrícula e senha, o método retorna as informações do usuário caso o mesmo tenha sido encontrado
                if (funcionario.codigo > 0) // Verifica se o código é maior que 1, caso negativo o usuário não foi encontrado.
                {

                    if (funcionario.situacao == 1) // Verifica se o usuário está ativo ou não no sistema
                    {
                        if (funcionario.codacesso == 1) // verifica se o login é de um TÉCNICO ou de um USUÁRIO
                        {
                            TelaInicialTecnico tecnico = new TelaInicialTecnico(funcionario);
                            tecnico.Show();
                        }
                        else
                        {
                            // Abrir form funcionário
                            MessageBox.Show("TUDO CERTO, BEM-VINDO USUARIO!!"); // Teste
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuário INATIVO, contate o administrador para maiores informações");
                    }
                }
                else
                {
                    MessageBox.Show("Mátricula ou Senha Incorreta, verifique se os dados foram digitados corretamente");
                }
            }

            


        }

        private void lblEsqueciSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEsqueci esquecisenha = new frmEsqueci();
            esquecisenha.Show();
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }   
}
