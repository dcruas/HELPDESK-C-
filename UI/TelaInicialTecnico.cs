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
    public partial class TelaInicialTecnico : Form
    {
        Funcionario funcionario = new Funcionario();

        public TelaInicialTecnico(Funcionario func)
        {
            InitializeComponent();
            funcionario = func;
            lblUsuario.Text = (funcionario.codigo+20000000).ToString();        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            CadastroFuncionariocs cadastro = new CadastroFuncionariocs(lblUsuario.Text);
            cadastro.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Chamados formchamado = new Chamados(lblUsuario.Text);
            formchamado.Show();
        }

        private void TelaInicialTecnico_Load(object sender, EventArgs e)
        {

        }
    }
}
