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
    public class ValoresDal
    {
        private string MysqlConn()
        {
            //Chama a string de conexao dentro do Web.Config do projeto.
            return ConfigurationManager.AppSettings["MysqlConn"];
        }
        //Cria a funçao lista para ser usada em outras classes
        public DataTable Lista(int Ano, string mes, int Cod)
        {
            string queryString = "SELECT mes.pl_codigo, cat.pl_categoria, pl_proposta, pl_realizado FROM " + Cod + "tbl_" + mes + " mes INNER JOIN " + Cod + "tbl_categoria cat ON cat.pl_codigo = mes.cod_categoria WHERE pl_ano = ?Ano";
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                //Select que chama atraves do ID
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("?Ano", Ano);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }
        public DataTable BuscaPorId(int Codigo, string mes, int Cod)
        {
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                //Select que chama atraves do ID
                string queryString = "SELECT mes.pl_codigo, cat.pl_categoria, pl_proposta, pl_realizado FROM " + Cod + "tbl_" + mes + " mes INNER JOIN " + Cod + "tbl_categoria cat ON cat.pl_codigo = mes.cod_categoria WHERE mes.pl_codigo= ?Codigo";
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("?Codigo", Codigo);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public DataTable BuscaCategoriaPorId(int Codigo, int Cod)
        {
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                //Select que chama atraves do ID
                string queryString = "SELECT pl_codigo, pl_categoria FROM  " + Cod + "tbl_categoria WHERE pl_codigo= @Codigo";
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = Codigo;
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public void AlterarValores(int Codigo, decimal Proposta, decimal Realizado, string mes, int Cod)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE " + Cod + "tbl_" + mes + " SET pl_proposta = @tbl_proposta , pl_realizado = @tbl_realizacao  WHERE pl_codigo = @tbl_codigo");
            cmd.Parameters.Add("@tbl_codigo", MySqlDbType.Int32).Value = Codigo;
            cmd.Parameters.Add("@tbl_proposta", MySqlDbType.Decimal).Value = Proposta;
            cmd.Parameters.Add("@tbl_realizacao", MySqlDbType.Decimal).Value = Realizado;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        //INICIO DAS CATEGORIAS <<!>>

        public DataTable CodigoDasCategorias(int Cod)
        {
            string queryString = "SELECT pl_codigo FROM " + Cod + "tbl_categoria WHERE pl_codigo NOT IN (1);";
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public DataTable CodigoDeTodasCategorias(int Cod)
        {
            string queryString = "SELECT pl_codigo FROM " + Cod + "tbl_categoria ORDER BY pl_codigo ASC;";
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public DataTable CodigoCategoria(int Cod, string Cat)
        {
            string queryString = "SELECT pl_codigo FROM " + Cod + "tbl_categoria WHERE pl_categoria = @Categoria;";
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Categoria", Cat);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public DataTable ListaCategorias(int Cod)
        {
            string queryString = "SELECT pl_codigo, pl_categoria FROM " + Cod + "tbl_categoria WHERE pl_codigo NOT IN (1)";
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public void AlterarCategoria(int id, string Categoria, int Cod)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE " + Cod + "tbl_categoria SET pl_categoria = @Categoria WHERE pl_codigo = @tbl_codigo");
            cmd.Parameters.Add("@tbl_codigo", MySqlDbType.Int32).Value = id;
            cmd.Parameters.AddWithValue("@Categoria", Categoria);

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void AdicionarCategoria(int Cod, string Categoria)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO " + Cod + "tbl_categoria(pl_categoria) VALUES (@Categoria)");
            cmd.Parameters.AddWithValue("@Categoria", Categoria);

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void AddValoresDaCategoria(string Categoria, int Cod)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO " + Cod + "tbl_categoria(pl_categoria) VALUES (@Categoria)");
            cmd.Parameters.AddWithValue("@Categoria", Categoria);

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}
