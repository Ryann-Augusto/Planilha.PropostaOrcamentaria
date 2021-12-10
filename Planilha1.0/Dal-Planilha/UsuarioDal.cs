using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Planilha
{
    public class UsuarioDal
    {
        private string MysqlConn()
        {
            //Chama a string de conexao dentro do Web.Config do projeto.
            return ConfigurationManager.AppSettings["MysqlConn"];
        }

        public DataTable ObterCodigo(string Usuario)
        {
                string queryString = "SELECT pl_codigo FROM tbl_usuario WHERE pl_usuario = @Usuario;";

                using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
                {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("?Usuario", Usuario);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }
    }
}
