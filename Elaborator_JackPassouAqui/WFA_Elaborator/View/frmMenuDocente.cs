using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_tcc
{
    public partial class frmMenuDocente : Form
    {
        public frmMenuDocente()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void consultarDadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            frmDadosDocente frmDadosDocente = new frmDadosDocente();
            frmDadosDocente.ShowDialog();
        }

        private void cadastrarDisponibilidadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            frmCadastroDispo frmCadastroDispo = new frmCadastroDispo();
            frmCadastroDispo.ShowDialog();
         
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string url = "G:\\TCC - 08.06 (Atualizado)\\Site\\index.html";
            //Process.Start("file:///" + url);
        }
    }
}
