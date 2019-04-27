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
    public partial class frmAlterarDados : Form
    {
        public string strErro { get; private set; }

        string cpff="";
        string nomee = "";
        string tell= "";
        string enderecoo = "";
        string emaill = "";
        string cell = "";
        string numaulasS = "";

        public frmAlterarDados(string cpf, string nome, string tel, string endereco,string email, string cel, string numaulas)
        {
            InitializeComponent();
            cpff = cpf;
            nomee = nome;
            tell = tel;
            enderecoo = endereco;
            emaill = email;
            cell = cel;
            numaulasS = numaulas;
        }

        private void frmAlterarDados_Load(object sender, EventArgs e)
        {
            txtcpf.Text = cpff;
            txtnome.Text = nomee;
            txttel.Text = tell;
            txtendereco.Text = enderecoo;
            txtemail.Text = emaill;
            txtcel.Text = cell;
            txtnumaulas.Text = numaulasS;

        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Model.DocenteDAO.procAlterarDados(txtnome.Text.Trim(), txtemail.Text, txtcpf.Text, txttel.Text, txtcel.Text, txtendereco.Text, txtnumaulas.Text), "Alterar Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro na alteração" + erro.Message, "Alterar Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmDadosDocente frmDados = new frmDadosDocente();
            frmDados.ShowDialog();
        }

        private void lnkAlterarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAlterarSenha frmAlterarSenha = new frmAlterarSenha();
            frmAlterarSenha.ShowDialog();
        }

        private void txtnome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }

        private void txtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }

        private void txtcel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }

        private void txtendereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }

        private void txtnumaula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnalterar_Click(sender, e);
            }
        }
    }
}
