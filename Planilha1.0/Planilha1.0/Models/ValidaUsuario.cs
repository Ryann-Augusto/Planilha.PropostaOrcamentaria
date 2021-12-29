using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Planilha1._0.Models
{
    public class ValidaUsuario
    {
        private string MysqlConn()
        {
            //Chama a string de conexao dentro do Web.Config do projeto.
            return ConfigurationManager.AppSettings["MysqlConn"];
        }

        public bool ValidarUsuario(string Login, string Senha)
        {
            string queryString = "SELECT COUNT(1) FROM tbl_Usuario WHERE pl_email = @login AND pl_senha = @Senha";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Login", Login);
                command.Parameters.AddWithValue("@Senha", Senha);
                connection.Open();

                var result = Convert.ToBoolean(command.ExecuteScalar());

                return result;
            }
        }

        public bool UsuarioExistente(string Email)
        {
            string queryString = "SELECT COUNT(1) FROM tbl_Usuario WHERE pl_email = @login";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Login", Email);
                connection.Open();

                var result = Convert.ToBoolean(command.ExecuteScalar());

                return result;
            }
        }
    }
}