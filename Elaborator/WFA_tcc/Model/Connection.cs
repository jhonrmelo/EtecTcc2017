using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_tcc.Model
{
    class Connection
    {
        // Objeto de conexão com o Banco de Dados
        public static MySqlConnection conexao = new MySqlConnection(Properties.Settings.Default.bd_elaboratorConnectionString);
    }
}
