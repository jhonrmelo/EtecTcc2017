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
    public partial class frmMenuAdmin : Form
    {
        public frmMenuAdmin()
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

        private void disponibilidadeGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmDispoGeral frmDispoGeral = new frmDispoGeral();
            frmDispoGeral.ShowDialog();
        }

        private void matériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmMaterias frmMaterias = new frmMaterias();
            frmMaterias.ShowDialog();
        }

        private void cadastrarProfessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmCadastro frmCadastro = new frmCadastro();
            frmCadastro.ShowDialog();
        }

        private void dadosGeraisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            frmDadosGerais frmDadosGerais = new frmDadosGerais();
            frmDadosGerais.ShowDialog();
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlterarSenha frmAlterarSenha = new frmAlterarSenha();
            frmAlterarSenha.ShowDialog();
        }

        private void relatórioDeProfessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            View.frmRelatorio relatorio = new View.frmRelatorio();
            relatorio.ShowDialog();
        }
    }
}
