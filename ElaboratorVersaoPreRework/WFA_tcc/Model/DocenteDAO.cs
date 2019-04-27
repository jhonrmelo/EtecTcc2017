using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Windows.Forms;

namespace WFA_tcc.Model
{
    class DocenteDAO
    {
    
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader objDados;
        public string strErro { get; private set; }

        //métodos para execução dos demais 
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

        public int ExecutarSQL(string strSQL)
        {
            try
            {
                int lngRetorno = 0;
                if (Conectar())
                {
                    if (objDados != null)
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }
                    }
                    cmd.Connection = Connection.conexao;
                    cmd.CommandText = strSQL;
                    lngRetorno = cmd.ExecuteNonQuery();
                }
                return lngRetorno;
            }
            catch (Exception Erro)
            {
                strErro = Erro.Message;
                return 0;
            }
            finally
            {
                Desconectar();
            }
        }


        // Método para executar a função do Banco de Dados para cadastrar docentes
        public static string cadastrarDocente(int idMateria, String nProf, String emailProf, String CpfProf, String tel, String cel, String endereco, String loginProf, String senhaProf, String confSenhaProf, String numAulas )
        {
            String m;
            Connection.conexao.Open();
            MySqlCommand objComando = new MySqlCommand();
            MySqlDataReader dr;
            objComando.Connection = Connection.conexao;
            objComando.CommandText = "select fCadProf('" + nProf + "','" + emailProf + "','" + CpfProf + "','" + tel + "','" + cel + "','" + endereco + "','" + loginProf + "','" + senhaProf + "','" + confSenhaProf + "','" + numAulas + "','" + idMateria + "') as M";
            dr = objComando.ExecuteReader();
            dr.Read();
            m = dr["M"].ToString();
            Connection.conexao.Close();
            return m;
        }

        // Método que será utilizado no formulário Dados Docente para executar um comando 'Select'
        public string dadosDocente(string strSQL)
        {
            try
            {
                string lngRetorno = "";
                if (Conectar())
                {
                    if (objDados != null)
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }
                    }
                    cmd.Connection = Connection.conexao;
                    cmd.CommandText = strSQL;
                    lngRetorno = (string)cmd.ExecuteScalar();
                }
                return lngRetorno;
            }
            catch (Exception Erro)
            {
                strErro = Erro.Message;
                return strErro;
            }
            finally
            {
                Desconectar();
            }
        }

        // Método que irá executar a procedure criada no BD para alterar os dados dos docentes
        public static string procAlterarDados(string pNomeProf, string pEmailProf, string pCpfProf, string pTelProf, string pCelProf, string pEndProf, string pNumAula)
        {
            String m;
            Connection.conexao.Open();
            MySqlCommand cmd = new MySqlCommand("sAlteraDados", Connection.conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pNome", pNomeProf);
            cmd.Parameters["pNome"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pEmail", pEmailProf);
            cmd.Parameters["pEmail"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pCpf", pCpfProf);
            cmd.Parameters["pCpf"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pTel", pTelProf);
            cmd.Parameters["pTel"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pCel", pCelProf);
            cmd.Parameters["pCel"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pEndereco", pEndProf);
            cmd.Parameters["pEndereco"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pNumAula", pNumAula);
            cmd.Parameters["pNumAula"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("pMensagem", MySqlDbType.VarChar, 50);
            cmd.Parameters["pMensagem"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            m = cmd.Parameters["pMensagem"].Value.ToString();
            Connection.conexao.Close();
            return m;
        }

        // Método que irá executar a procedure criada no BD para alterar a senha do docente
        public static string procAlterarSenha(int idProfLog, string senha, string confirmarSenha)
        {
            String m;
            Connection.conexao.Open();
            MySqlCommand cmd = new MySqlCommand("sAlteraSenha", Connection.conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idProfLog", idProfLog);
            cmd.Parameters["idProfLog"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pNovaSenha", senha);
            cmd.Parameters["pNovaSenha"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("pConfSenha", confirmarSenha);
            cmd.Parameters["pConfSenha"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add("pMensagem", MySqlDbType.VarChar, 50);
            cmd.Parameters["pMensagem"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            m = cmd.Parameters["pMensagem"].Value.ToString();
            Connection.conexao.Close();
            return m;
        }

    }
}
