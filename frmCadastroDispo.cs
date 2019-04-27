using MySql.Data.MySqlClient;
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
    public partial class frmCadastroDispo : Form
    {
        //para verficar os horários disponibilizados
        private static List<int[]> horarios; /*NOVO*/

        public frmCadastroDispo()
        {
            InitializeComponent();
            carregaHorarios();//carrega os horários do professor /*NOVO*/
            //Percorre todas as linhas e colunas
            for (int linha = 1; linha < tableLayoutPanel2.RowCount; linha++)
            {
                for (int coluna = 1; coluna < tableLayoutPanel2.ColumnCount; coluna++)
                {
                    Label lb = tableLayoutPanel2.GetControlFromPosition(coluna, linha) as Label;
                    lb.Click += new EventHandler(Salvar);
                    //Verifica se tem o horário cadastrado no banco
                    if (verifica(linha, coluna))
                    {
                        lb.Text = "D";
                        lb.BackColor = Color.MediumAquamarine;
                    }
                    else
                    {
                        lb.Text = "IN";
                        lb.BackColor = Color.LightCoral;
                    }
                }
            }
        }
        //Evento para salvar ao clicar
        private void Salvar(object sender, EventArgs e)
        {
            //Pega a posição da label
            Label lb = (Label)sender;
            TableLayoutPanelCellPosition pos = tableLayoutPanel2.GetPositionFromControl(lb);
            //Verifica se é disponível ou indisponível
            //Se clicar no Disponível muda para indisponível e remove do banco
            if (lb.Text == "D")
            {
                lb.Text = "IN";
                lb.BackColor = Color.LightCoral;
                delete(pos.Row, pos.Column);
            }
            else // se clicar no IN muda para disponível e insere no banco
            {
                lb.Text = "D";
                lb.BackColor = Color.MediumAquamarine;
                insere(pos.Row,pos.Column);
            }
        }
        //método para inserir no banco de dados
        private void insere(int linha, int coluna)
        {
            string CONFIG = "Server = 127.0.0.1; Database = bd_elaborator; user=root; pwd=1234";
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Conexao.Open();
            Query.Connection = Conexao;
            Query.CommandText = "insert into disponibilidadeprofessor (iddiasemana,idperiodo,idprof) values (" + coluna + "," + linha + "," + frmLogin.idProfLogado + ");";
            Query.ExecuteReader();
        }
        //método para excluir do banco de dados
        private void delete(int linha, int coluna)
        {
            string CONFIG = "Server = 127.0.0.1; Database = bd_elaborator; user=root; pwd=1234";
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Conexao.Open();
            Query.Connection = Conexao;
            Query.CommandText = "DELETE FROM disponibilidadeprofessor WHERE iddiasemana = " + coluna + " AND idperiodo = " + linha + " AND idprof = " + frmLogin.idProfLogado;
            Query.ExecuteReader();
        }
        //Carrega os horários do professor /*NOVO*/
        private void carregaHorarios()
        {
            string CONFIG = "Server = 127.0.0.1; Database = bd_elaborator; user=root; pwd=1234";
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Conexao.Open();
            Query.Connection = Conexao;
            //Query.CommandText = "select * FROM disponibilidadeprofessor WHERE iddiasemana = " + coluna + " AND idperiodo = " + linha + " AND idprof = " + frmLogin.idProfLogado ;
            Query.CommandText = "select iddiasemana,idperiodo FROM disponibilidadeprofessor WHERE idprof = " + frmLogin.idProfLogado;
            MySqlDataReader Reader = Query.ExecuteReader();
            horarios = new List<int[]>();
            while (Reader.Read())
            {
                horarios.Add(new int[2] { Reader.GetInt32(0), Reader.GetInt32(1) });
            }
        }

        //método que verifica se o horário está cadastrado no banco /*NOVO*/
        private bool verifica(int linha, int coluna)
        {
            bool contem = false;
            int[] horario = new int[2] { coluna, linha };
            //Percorre a lista de horários do professor
            //Se a lista de array contiver o array verificardo, retorna verdadeiro
            foreach (var h in horarios)
            {
                if(h.SequenceEqual(horario))
                {
                    contem = true;
                }
            }
            return contem;
            
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            frmMenuDocente frmMenuDocente = new frmMenuDocente();
            frmMenuDocente.ShowDialog();
        }
      
        private void h1_Click(object sender, EventArgs e)
        {
            //Dispo = 1;
        }

        private void h2_Click(object sender, EventArgs e)
        {
            h2.BackColor = Color.MediumAquamarine;
            h2.Text = "IN";
        }

        private void h3_Click(object sender, EventArgs e)
        {
            h3.BackColor = Color.LightSteelBlue;
            h3.Text = "D";
        }

        private void h4_Click(object sender, EventArgs e)
        {
            h4.BackColor = Color.LightCoral;
            h4.Text = "ND";
        }

        private void h5_Click(object sender, EventArgs e)
        {
            h5.BackColor = Color.MediumAquamarine;
            h5.Text = "IN";
        }

        private void frmCadastroDispo_Load(object sender, EventArgs e)
        {

        }

       
    }
}
