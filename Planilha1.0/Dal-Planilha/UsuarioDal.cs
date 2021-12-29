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
                string queryString = "SELECT pl_codigo, pl_usuario, pl_nivel FROM tbl_usuario WHERE pl_email = @Email;";

                using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
                {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Email", Usuario);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public DataTable ObterUsuarios()
        {
            string queryString = "SELECT pl_codigo, pl_usuario, pl_email, pl_senha, pl_nivel FROM tbl_usuario;";

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
        
        public void CadUsuario(string Nome, string Email, string Senha, int Nivel)
        {
            MySqlCommand Usu = new MySqlCommand("INSERT INTO tbl_usuario(pl_usuario, pl_email, pl_senha, pl_nivel) VALUES(@Nome, @Email, @Senha, @Nivel);");

            Usu.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = Nome;
            Usu.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
            Usu.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;
            Usu.Parameters.Add("@Nivel", MySqlDbType.Int32).Value = Nivel;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                Usu.Connection = conn;
                conn.Open();
                Usu.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataTable BuscarUsuId(int Codigo)
        {
            string queryString = "SELECT pl_codigo, pl_usuario, pl_email, pl_senha, pl_nivel FROM tbl_usuario WHERE pl_codigo = @Codigo;";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Codigo", Codigo);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }

        public void AlterarNomeEmail(int Codigo, string Usuario, string Email)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_usuario SET pl_usuario = @Usuario, pl_email = @Email WHERE pl_codigo = @Codigo;");
            cmd.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = Codigo;
            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = Usuario;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AlterarTudo(int Codigo, string Usuario, string Email, string Senha)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_usuario SET pl_usuario = @Usuario, pl_email = @Email, pl_senha = @Senha WHERE pl_codigo = @Codigo;");
            cmd.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = Codigo;
            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = Usuario;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void ApagarUsuario(int Cod)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_usuario WHERE pl_codigo = @Codigo");
            cmd.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = Cod;
            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
