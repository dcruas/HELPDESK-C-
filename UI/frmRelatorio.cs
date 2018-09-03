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
    public partial class frmRelatorio : Form
    {
        RelatorioBLL RelatorioBLL;

        public frmRelatorio()
        {
            InitializeComponent();
            RelatorioBLL = new RelatorioBLL();
            
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Relatorio relatorio = new Relatorio();   
            if (txtDataInicial.Text != "" && txtDataFinal.Text != "")
            {
                if (cmbTipo.SelectedIndex == 0)
                {
                    relatorio.tiporelatorio = 0;
                }
                else
                {
                    relatorio.tiporelatorio = 1;
                }
                dgvRelatorios.DataSource = null;
                dgvRelatorios.DataSource = RelatorioBLL.GerarRelatorio(relatorio, txtDataInicial.Text, txtDataFinal.Text);
                

            }
            else
            {
                MessageBox.Show("Por favor, coloque o período que deseja gerar o relatório");
            }
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
