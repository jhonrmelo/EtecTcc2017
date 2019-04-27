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
                ConectaBD.conexao.Open();
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
                ConectaBD.conexao.Close();
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
            ConectaBD.conexao.Open();
            cmd.Connection = ConectaBD.conexao;
            cmd.CommandText = "SELECT * FROM bd_elaborator.materia;";

            cmdline = cmd.ExecuteReader();

            tbMaterias.Load(cmdline);

            cmdline.Close();
            ConectaBD.conexao.Close();

            return tbMaterias;
        }

        public static string cadastrarMaterias(string nome)
        {
            String m;
            ConectaBD.conexao.Open();
            MySqlCommand objComando = new MySqlCommand();
            MySqlDataReader dr;
            objComando.Connection = ConectaBD.conexao;
            objComando.CommandText = "select bd_elaborator.fCadMaterias('" + nome + "') as M";
            dr = objComando.ExecuteReader();
            dr.Read();
            m = dr["M"].ToString();
            ConectaBD.conexao.Close();
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

                    cmd.Connection = ConectaBD.conexao;
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
