using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Net;

namespace UI
{
    public partial class frmEsqueci : Form
     {
        FuncionarioBLL FuncionarioBLL;

        public frmEsqueci()
        {
            InitializeComponent();
            FuncionarioBLL = new FuncionarioBLL();
           
           
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            Funcionario funcionario = new Funcionario();
            funcionario = FuncionarioBLL.EsqueciSenhaBLL(txtCPF.Text, txtEmail.Text);
            MessageBox.Show("Senha é: "+funcionario.senha);
            if (funcionario.senha != "")
            {
                MailMessage mensagem = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                mensagem.From = new MailAddress("helpfastpim@gmail.com", "Daniel");
                mensagem.To.Add(txtEmail.Text);
                mensagem.Subject = ("Recuperação de senha");
                mensagem.IsBodyHtml = true;
                mensagem.Body = "<h3> Segue abaixo a sua senha utilizada em nosso serviço: " + funcionario.senha + "</h3>";
                mensagem.Priority = MailPriority.Normal;

                
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("helpfastpim@gmail.com", "HELPFASTADS4");
                

                try
                {
                    smtp.Send(mensagem);
                   
                }
                catch (System.Exception erro)
                {
                    MessageBox.Show("ERRO!");
                }
                finally
                {
                    mensagem = null;
                    frmEsqueci esqueci = new frmEsqueci();
                    esqueci.Close();
                }
            }
            else
            {
                MessageBox.Show("E-mail ou CPF não encontrado, verifique os dados digitados");
            }
        }

        private void frmEsqueci_Load(object sender, EventArgs e)
        {

        }
    }
}
