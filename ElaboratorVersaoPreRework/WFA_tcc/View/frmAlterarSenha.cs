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
    public partial class frmAlterarSenha : Form
    {

        public frmAlterarSenha()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfAlteracao_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Model.DocenteDAO.procAlterarSenha(frmLogin.idProfLogado, txtNovaSenha.Text, txtConfSenha.Text), "Alterar Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao alterar a senha:   " + erro.Message, "Alterar Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtNovaSenha.Text = "";
                txtConfSenha.Text = "";
            }
        }

        private void txtNovaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConfAlteracao_Click(sender, e);
            }
        }

        private void txtConfSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConfAlteracao_Click(sender, e);
            }
        }
    }
}


