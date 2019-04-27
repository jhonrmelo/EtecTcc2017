using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_tcc
{
    public partial class frmMaterias : Form
    {
        Model.MateriasDAO materias = new Model.MateriasDAO();

        public frmMaterias()
        {
            InitializeComponent();
            dgvMaterias.DataSource = materias.ConsultarMaterias("Select materia.nome from materia");
        }

        private void btnCadastrarMaterias_Click(object sender, EventArgs e)
        {
            frmCadastroMaterias frmCadastroMaterias = new frmCadastroMaterias();
            frmCadastroMaterias.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dgvMaterias.DataSource = materias.ConsultarMaterias("Select materia.nome from materia");
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmMenuAdmin frmMenuAdmin = new frmMenuAdmin();
            frmMenuAdmin.ShowDialog();
        }
    }
}
