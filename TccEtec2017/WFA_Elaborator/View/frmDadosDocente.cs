using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WFA_tcc
{
    public partial class frmDadosDocente : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objCmd = new MySqlCommand();
        public string strErro { get; private set; }
        public frmDadosDocente()
        {
            InitializeComponent();
            Model.DocenteDAO objBD = new Model.DocenteDAO();
            //Banco objBD = new Banco();
            frmLogin login = new frmLogin();
            txtnome.Text = objBD.dadosDocente("Select nomeProf from bd_elaborator.professor where login = '" + frmLogin.login + "'");
            txtemail.Text = objBD.dadosDocente("Select emailProf from bd_elaborator.professor where login = '" + frmLogin.login + "'");
            txtcpf.Text = objBD.dadosDocente("Select cpfProf from bd_elaborator.professor where login = '" + frmLogin.login + "'");
            txttel.Text = objBD.dadosDocente("Select telProf1 from bd_elaborator.professor where login = '" + frmLogin.login + "'");
            txtcel.Text = objBD.dadosDocente("Select telProf2 from bd_elaborator.professor where login = '" + frmLogin.login + "'");
            txtendereco.Text = objBD.dadosDocente("Select enderecoProf from bd_elaborator.professor where login = '" + frmLogin.login + "'");
            txtnumaula.Text = objBD.dadosDocente("Select numAulas from bd_elaborator.professor where login = '" + frmLogin.login + "'");
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmMenuDocente frmMenuDocente = new frmMenuDocente();
            frmMenuDocente.ShowDialog();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            Hide();
            frmAlterarDados frmAlterarDados = new frmAlterarDados(txtcpf.Text , txtnome.Text, txttel.Text,txtendereco.Text,txtemail.Text,txtcel.Text, txtnumaula.Text);
            frmAlterarDados.ShowDialog();
        }
    }
}
    