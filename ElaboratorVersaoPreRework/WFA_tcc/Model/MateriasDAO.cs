using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_tcc.Model
{
    class MateriasDAO
    {
        private MySqlCommand cmd = new MySqlCommand();
        private DataTable tbMaterias = new DataTable();
        private MySqlDataReader objDados;
        public string strErro { get; private set; }

        private bool Conectar()
        {
            try
            {
                Connection.conexao.Open();
                return true;
            }
            catch (Exception Erro)
            {
                strErro = Erro.Message;
                return false;
            }
        }

        private void Desconectar()
        {
            try
            {
                Connection.conexao.Close();
            }
            catch (Exception Erro)
            {
                strErro = Erro.Message;
            }
        }

        // -------------------------------------------

        public DataTable retornaTBMaterias()
        {
            MySqlDataReader cmdline;
            Connection.conexao.Open();
            cmd.Connection = Connection.conexao;
            cmd.CommandText = "SELECT * FROM bd_elaborator.materia;";

            cmdline = cmd.ExecuteReader();

            tbMaterias.Load(cmdline);

            cmdline.Close();
            Connection.conexao.Close();

            return tbMaterias;
        }

        public static string cadastrarMaterias(string nome)
        {
            String m;
            Connection.conexao.Open();
            MySqlCommand objComando = new MySqlCommand();
            MySqlDataReader dr;
            objComando.Connection = Connection.conexao;
            objComando.CommandText = "select bd_elaborator.fCadMaterias('" + nome + "') as M";
            dr = objComando.ExecuteReader();
            dr.Read();
            m = dr["M"].ToString();
            Connection.conexao.Close();
            return m;
        }

        public DataTable ConsultarMaterias(string strSQL)
        {
            try
            {
                DataTable dtDados = new DataTable();
                if (Conectar())
                {
                    dtDados.Columns.Add("Matérias");

                    if (objDados != null)
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }
                    }

                    cmd.Connection = Connection.conexao;
                    cmd.CommandText = strSQL;
                    objDados = cmd.ExecuteReader();
                    if (objDados.HasRows)
                    {
                        DataRow drRegistro;
                        while (objDados.Read())
                        {
                            drRegistro = dtDados.NewRow();
                            drRegistro["Matérias"] = objDados["nome"].ToString();
                            dtDados.Rows.Add(drRegistro);
                        }
                        if (objDados != null)
                        {
                            if (!objDados.IsClosed) { objDados.Close(); }
                        }
                    }
                }
                return dtDados;
            }

            catch (Exception Erro)
            {
                strErro = Erro.Message;
                return null;
            }
            finally
            {
                Desconectar();
            }

    }
    }
}
