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
        Model.Connection cnx = new Model.Connection();
        private string CONFIG = "Server = 127.0.0.1; Database = bd_elaborator; user = alunos; pwd = etec";

        private int cadastrou, numaulas, minimo;
            //para verficar os horários disponibilizados
        private static List<int[]> horarios; 
        public frmCadastroDispo()
        {
            InitializeComponent();
            carregaHorarios();//carrega os horários do professor 
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
            try
            {
                MySqlConnection Conexao = new MySqlConnection(CONFIG);
                MySqlCommand Query = new MySqlCommand();
                Conexao.Open();
                Query.Connection = Conexao;
                Query.CommandText = "insert into disponibilidadeprofessor (iddiasemana,idperiodo,idprof) values (" + coluna + "," + linha + "," + frmLogin.idProfLogado + ");";
                Query.ExecuteReader();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao inserir: " + erro.Message, "Inserir Disponibilidade", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //método para excluir do banco de dados
        private void delete(int linha, int coluna)
        {
            try
            {
                MySqlConnection Conexao = new MySqlConnection(CONFIG);
                MySqlCommand Query = new MySqlCommand();
                Conexao.Open();
                Query.Connection = Conexao;
                Query.CommandText = "DELETE FROM disponibilidadeprofessor WHERE iddiasemana = " + coluna + " AND idperiodo = " + linha + " AND idprof = " + frmLogin.idProfLogado;
                Query.ExecuteReader();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao excluir: " + erro.Message, "Excluir Disponibilidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregaHorarios()
        {
            try
            {
                MySqlConnection Conexao = new MySqlConnection(CONFIG);
                MySqlCommand Query = new MySqlCommand();
                Conexao.Open();
                Query.Connection = Conexao;
               
                Query.CommandText = "select iddiasemana,idperiodo FROM disponibilidadeprofessor WHERE idprof = " + frmLogin.idProfLogado;
                MySqlDataReader Reader = Query.ExecuteReader();
                horarios = new List<int[]>();
                while (Reader.Read())
                {
                    horarios.Add(new int[2] { Reader.GetInt32(0), Reader.GetInt32(1) });
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao carregar Horário: " + erro.Message, "Carregar Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //método que verifica se o horário está cadastrado no banco 
        private bool verifica(int linha, int coluna)
        {
            bool contem = false;
            int[] horario = new int[2] { coluna, linha };
            //Percorre a lista de horários do professor
            //Se a lista de array contiver o array verificardo, retorna verdadeiro
            foreach (var h in horarios)
            {
                if (h.SequenceEqual(horario))
                {
                    contem = true;
                }
            }
            return contem;

        }

        private void h1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private bool cadastrouQuantidade()
        {
            // metodo que calcula a quantidade de aulas, para definir o numero minimo de disponibilidade
            // conta o numero de aulas e aplica a logica dentro do select
                MySqlConnection Conexao = new MySqlConnection(CONFIG);
                MySqlCommand Query = new MySqlCommand();
                Conexao.Open();
                Query.Connection = Conexao;
                //Query.CommandText = "select * FROM disponibilidadeprofessor WHERE iddiasemana = " + coluna + " AND idperiodo = " + linha + " AND idprof = " + frmLogin.idProfLogado ;
                Query.CommandText = @"select count(*) cadastrou, numaulas, round(numAulas * 1 + (30 / 100 * numAulas)) as mini from disponibilidadeprofessor d inner join professor p on d.idprof = p.idprofessor   where idprof = " + frmLogin.idProfLogado;
                MySqlDataReader Reader = Query.ExecuteReader();
                Reader.Read();
                cadastrou = Reader.GetInt32(0);
                numaulas = Reader.GetInt32(1);
                minimo = Reader.GetInt32(2);
                return minimo <= cadastrou;
         

        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verificação do número minimo de disponibilidades, se foi validado volta se nao mensagem de erro.
            if (cadastrouQuantidade())
            {
                Hide();
                frmMenuDocente frmMenuDocente = new frmMenuDocente();
                frmMenuDocente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Você  cadastrou " + cadastrou + " disponiblidade(s) e precisa cadastrar no minimo " + minimo ,  "Disponibildidade(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
