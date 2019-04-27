using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace WFA_tcc
{
    public partial class frmCadastro : Form
    {
        Model.Connection cnx = new Model.Connection();
        Model.MateriasDAO lDao = new Model.MateriasDAO();

        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objCmd = new MySqlCommand();
        public string strErro { get; private set; }

        public frmCadastro()
        {
            InitializeComponent();
            cbxMat.DataSource = lDao.retornaTBMaterias();
            cbxMat.DisplayMember = "nome";
            cbxMat.ValueMember = "idMateria";
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idMateria = Convert.ToInt32(cbxMat.SelectedValue);
                MessageBox.Show(Model.DocenteDAO.cadastrarDocente(idMateria, txtNomeProf.Text.Trim(), txtEmail.Text.Trim(), txtCPF.Text.Trim(), txtTel1.Text.Trim(), txtTel2.Text.Trim(), txtEndereco.Text.Trim(), txtLogin.Text.Trim(), txtSenha.Text.Trim(), txtConfSenha.Text.Trim(), txtAulas.Text.Trim()), "Cadastro de Professores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no cadastro:  " + erro.Message, "Cadastrar Professor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally
            {
                txtNomeProf.Text = "";
                txtEmail.Text = "";
                txtSenha.Text = "";
                txtConfSenha.Text = "";
                txtLogin.Text = "";
                txtCPF.Text = "";
                txtEndereco.Text = "";
                txtTel1.Text = "";
                txtTel2.Text = "";
                txtAulas.Text = "";
            }
        }
        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            txtNomeProf.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtConfSenha.Text = "";
            txtLogin.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtAulas.Text = "";
        }          
        private void txtNomeProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtConfSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtEndereco_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void VoltarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            frmMenuAdmin frmMenuAdmin = new frmMenuAdmin();
            frmMenuAdmin.ShowDialog();
        }

        private void txtCPF_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtTel1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtTel2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }

        private void txtAulas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnCadastrar_Click_1(sender, e);
            }
        }
    }
}
