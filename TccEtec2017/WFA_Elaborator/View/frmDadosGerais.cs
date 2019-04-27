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
    public partial class frmDadosGerais : Form
    {
        static String conString = "Server = 127.0.0.1; Database = bd_elaborator; user = Jonathan; pwd = 1234";
        MySqlConnection con = new MySqlConnection(conString);
        DataTable dt = new DataTable();

        //Model.DocenteDAO objBD = new Model.DocenteDAO();
        public frmDadosGerais()
        {
            InitializeComponent();
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmMenuAdmin frmMenuAdmin = new frmMenuAdmin();
            frmMenuAdmin.ShowDialog();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (nome.Checked == true)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Nome LIKE '%{0}%'", txtFiltrar.Text);
                dgvDadosGerais.DataSource = dv;
            }

            if (cpf.Checked == true)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("CPF LIKE '%{0}%'", txtFiltrar.Text);
                dgvDadosGerais.DataSource = dv;
            }

            if (email.Checked == true)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Email LIKE '%{0}%'", txtFiltrar.Text);
                dgvDadosGerais.DataSource = dv;
            }
        }

        private void preencherDados()
        {
            // INICIALIZAÇÃO
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd;

            // SQL
            string sql = "select professor.nomeProf as Nome, professor.emailProf as Email, professor.cpfProf as CPF, professor.telProf1 as Telefone, professor.telProf2 as Celular, professor.enderecoProf as Endereço, professor.numAulas as NºAulas from bd_elaborator.professor";
            cmd = new MySqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            // PREENCHER DG
            adapter.Fill(dt);
            dgvDadosGerais.DataSource = dt;
        }

        private void frmDadosGerais_Load(object sender, EventArgs e)
        {
            preencherDados();
        }
    }
}
