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
    public partial class frmEncerrar : Form
    {
        Chamado chamado = new Chamado();
        ChamadoBLL ChamadoBLL;

        public frmEncerrar(string usuario, Chamado ticket)
        {
            InitializeComponent();
            chamado = ticket;
            txtMatricula.Text = usuario;
            ChamadoBLL = new ChamadoBLL();
        }

        private void frmEncerrar_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (txtJustificativa.Text != "")
            {
                DateTime dateTime = DateTime.Now.Date;
                DateTime DataChamado = Convert.ToDateTime(chamado.dataAbertura);
                string dia = dateTime.Day.ToString();
                string mes = dateTime.Month.ToString();
                string ano = dateTime.Year.ToString();
                string completa = ano + "-" + mes + "-" + dia;
                chamado.dataEncerramento = completa;
                
            
                if (dateTime == DataChamado)
                {
                    chamado.codstatus = 3;
                }
                else
                {
                    chamado.codstatus = 4;
                }
                chamado.justificativa = txtJustificativa.Text;
                ChamadoBLL.EncerrarChamado(chamado);
                MessageBox.Show("Chamado encerrado com sucesso");
                Close();
            }
            else
            {
                MessageBox.Show("Você precisa digitar uma justificativa para o encerramento do chamado!");
            }
            
            
            }
    }
}
