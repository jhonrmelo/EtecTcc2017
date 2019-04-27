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
    public partial class frmLogin : Form
    {
        public static string login = "";
        public static int idProfLogado; // atributo estático para armazenar o id do professor logado
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            login = txtLogin.Text.ToString();
            string senha = txtSenha.Text;
            string CONFIG = "Server = 127.0.0.1; Database = bd_elaborator; user = Jonathan; pwd = 1234";
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();

            Conexao.Open();
            Query.Connection = Conexao;
            Query.CommandText = "select idprofessor, login, senha FROM professor WHERE login ='" + login + "' AND senha = sha1('" + senha + "')";

            MySqlDataReader Reader = Query.ExecuteReader();

            bool verifica = Reader.HasRows;
            if (verifica == true)
            {
                Reader.Read();
                string login = Reader.GetString("login");
                idProfLogado = Reader.GetInt32(0);
                if (login.Equals("admin"))
                {
                    MessageBox.Show("Usuário administrador logado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    frmMenuAdmin frmMenuAdmin = new frmMenuAdmin();
                    frmMenuAdmin.Show();
                }

                else
                {
                    MessageBox.Show("Docente logado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    frmMenuDocente frmMenuDocente = new frmMenuDocente();
                    frmMenuDocente.Show();
                }
            }
            else
            {
                MessageBox.Show("Login e/ou senha incorreto(s)!", "login Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Conexao.Close();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEntrar_Click_1(sender, e);
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair da aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

