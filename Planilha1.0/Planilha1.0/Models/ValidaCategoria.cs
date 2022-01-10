using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Planilha1._0.Models
{
    public class ValidaCategoria
    {
        private string MysqlConn()
        {
            //Chama a string de conexao dentro do Web.Config do projeto.
            return ConfigurationManager.AppSettings["MysqlConn"];
        }

        public bool ProcurarCategoria(int Cod, int Anos)
        {
            string queryString = "SELECT COUNT(1) FROM " + Cod + "tbl_janeiro " + Cod + "tbl_dezembro WHERE cod_categoria = 1 AND pl_ano = @Ano;";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Ano", MySqlDbType.Int32).Value = Anos;
                connection.Open();

                var result = Convert.ToBoolean(command.ExecuteScalar());

                return result;
            }
        }
    }
}