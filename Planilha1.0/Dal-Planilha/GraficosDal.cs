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
    public class GraficosDal
    {
        private string MysqlConn()
        {
            return ConfigurationManager.AppSettings["MysqlConn"];
        }

        public DataTable MontarGraficos(int Ano, int Cod, string Mes)
        {
            string queryString = "SELECT pl_proposta AS proposta, pl_realizado AS realizado FROM " + Cod + Mes + " WHERE cod_categoria = 1";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Ano", MySqlDbType.Int32).Value = Ano;
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
