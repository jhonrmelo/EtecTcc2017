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
    public partial class frmCadastroMaterias : Form
    {

        public frmCadastroMaterias()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCadastrarMat_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Model.MateriasDAO.cadastrarMaterias(txtNomeMat.Text.Trim()), "Cadastrar matérias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar matéria" + erro.Message," Cadastra Matéria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Model.ConectaBD.conexao.Dispose();
            }
        }

        private void txtNomeMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrarMat_Click(sender, e);
            }
        }
    }
}
