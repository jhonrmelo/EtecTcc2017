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
    public partial class frmDispoGeral : Form
    {
        // STRING DE CONEXÃO
        static String conString = "Server = 127.0.0.1; Database = bd_elaborator; user = alunos; pwd = etec";
        MySqlConnection con = new MySqlConnection(conString);
        DataTable dt = new DataTable();

        Model.DocenteDAO Docente = new Model.DocenteDAO();
        public frmDispoGeral()
        {
            InitializeComponent();

            //dtgvDispoGeral.DataSource = Docente.DispoGeral("select p.nomeProf,ds.nomeDia,pr.nome from disponibilidadeprofessor d inner join professor p on d.idprof = p.idprofessor inner join diassemana ds on d.iddiasemana = ds.idsemana inner join periodo pr on d.idperiodo = pr.idperiodo");

        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmMenuAdmin frmMenuAdmin = new frmMenuAdmin();
            frmMenuAdmin.ShowDialog();
        }

        private void frmDispoGeral_Load(object sender, EventArgs e)
        {
            preencherDados();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            if (dia.Checked == true)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Dia LIKE '%{0}%'", txtFiltrar.Text);
                dtgvDispoGeral.DataSource = dv;
            }

            else if (nome.Checked == true)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Nome LIKE '%{0}%'", txtFiltrar.Text);
                dtgvDispoGeral.DataSource = dv;
            }

            else if (Periodo.Checked == true)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Horário LIKE '%{0}%'", txtFiltrar.Text);
                dtgvDispoGeral.DataSource = dv;
            }
        }

        private void preencherDados()
        {
            // INICIALIZAÇÃO
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd;

            // SQL
            string sql = "select p.nomeProf as Nome, ds.nomeDia as Dia, pr.nome as Horário from disponibilidadeprofessor d inner join professor p on d.idprof = p.idprofessor inner join diassemana ds on d.iddiasemana = ds.idsemana inner join periodo pr on d.idperiodo = pr.idperiodo ";
            cmd = new MySqlCommand(sql, con);
            adapter.SelectCommand = cmd;

            // PREENCHER DG
            adapter.Fill(dt);
            dtgvDispoGeral.DataSource = dt;
        }
    }
}
