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
    public class CriarPlanilhaDal
    {
        private string MysqlConn()
        {
            //Chama a string de conexao dentro do Web.Config do projeto.
            return ConfigurationManager.AppSettings["MysqlConn"];
        }
        //Cria a funçao lista para ser usada em outras classes

        public void ExisteAno(int Ano, int Cod)
        {
            string queryString = "SELECT COUNT(1) FROM " + Cod + "tbl_Janeiro WHERE pl_ano = @Ano";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
                connection.Open();

                int result = Convert.ToInt32(command.ExecuteScalar());

                // Call Read before accessing data.
                if (result != 0)
                {
                    throw new Exception("Esse ano já existe");
                }
                connection.Close();
            }
        }

        public void NovaPlanilha(int Ano, int Cod, int Cat)
        {
            MySqlCommand Jan = new MySqlCommand("INSERT INTO " + Cod + "tbl_Janeiro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Fev = new MySqlCommand("INSERT INTO " + Cod + "tbl_Fevereiro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Mar = new MySqlCommand("INSERT INTO " + Cod + "tbl_Marco(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Abr = new MySqlCommand("INSERT INTO " + Cod + "tbl_Abril(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Mai = new MySqlCommand("INSERT INTO " + Cod + "tbl_Maio(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Jun = new MySqlCommand("INSERT INTO " + Cod + "tbl_Junho(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Jul = new MySqlCommand("INSERT INTO " + Cod + "tbl_Julho(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Ago = new MySqlCommand("INSERT INTO " + Cod + "tbl_Agosto(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Set = new MySqlCommand("INSERT INTO " + Cod + "tbl_Setembro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Out = new MySqlCommand("INSERT INTO " + Cod + "tbl_Outubro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Nov = new MySqlCommand("INSERT INTO " + Cod + "tbl_Novembro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Dez = new MySqlCommand("INSERT INTO " + Cod + "tbl_Dezembro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, @Cat);");
            MySqlCommand Res = new MySqlCommand("INSERT INTO " + Cod + "tbl_resultado(pl_ano, pl_propResultado, pl_realiResultado, cod_categoria, pl_sobreFaturamento, pl_contrib_Despesas) VALUES (@Ano, 0, 0, @Cat, 0, 0);");


            Jan.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Fev.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Mar.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Abr.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Mai.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Jun.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Jul.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Ago.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Set.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Out.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Nov.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Dez.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Res.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;

            Jan.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Fev.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Mar.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Abr.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Mai.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Jun.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Jul.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Ago.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Set.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Out.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Nov.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Dez.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            Res.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                Jan.Connection = conn;
                Fev.Connection = conn;
                Mar.Connection = conn;
                Abr.Connection = conn;
                Mai.Connection = conn;
                Jun.Connection = conn;
                Jul.Connection = conn;
                Ago.Connection = conn;
                Set.Connection = conn;
                Out.Connection = conn;
                Nov.Connection = conn;
                Dez.Connection = conn;
                Res.Connection = conn;

                conn.Open();
                Jan.ExecuteNonQuery();
                Fev.ExecuteNonQuery();
                Mar.ExecuteNonQuery();
                Abr.ExecuteNonQuery();
                Mai.ExecuteNonQuery();
                Jun.ExecuteNonQuery();
                Jul.ExecuteNonQuery();
                Ago.ExecuteNonQuery();
                Set.ExecuteNonQuery();
                Out.ExecuteNonQuery();
                Nov.ExecuteNonQuery();
                Dez.ExecuteNonQuery();
                Res.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void TotalMesesPlanilha(int Ano, int Cod)
        {
            MySqlCommand Total = new MySqlCommand("INSERT INTO " + Cod + "tbl_total(pl_ano, pl_totalProposta, pl_totalRealizado, pl_propostaTabResultado, pl_realizadoTabResultado) VALUES (@Ano, 0, 0, 0, 0)");
            MySqlCommand Meses = new MySqlCommand("INSERT INTO " + Cod + "tbl_totalmeses(pl_ano, pl_totalPropostaMes, pl_totalRealizadoMes, pl_tabelaMes) VALUES (@Ano, 0, 0, 'tbl_janeiro'), (@Ano, 0, 0, 'tbl_fevereiro'), (@Ano, 0, 0, 'tbl_marco'), (@Ano, 0, 0, 'tbl_abril'), (@Ano, 0, 0, 'tbl_maio'), (@Ano, 0, 0, 'tbl_junho'), (@Ano, 0, 0, 'tbl_julho'), (@Ano, 0, 0, 'tbl_agosto'), (@Ano, 0, 0, 'tbl_setembro'), (@Ano, 0, 0, 'tbl_outubro'), (@Ano, 0, 0, 'tbl_novembro'), (@Ano, 0, 0, 'tbl_dezembro')");

            Total.Parameters.AddWithValue("@Ano", MySqlDbType.Int32).Value = Ano;
            Meses.Parameters.AddWithValue("@Ano", MySqlDbType.Int32).Value = Ano;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                Total.Connection = conn;
                Meses.Connection = conn;

                conn.Open();
                Total.ExecuteNonQuery();
                Meses.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcluirPlanilha(int Cod, int Ano)
        {
            MySqlCommand Jan = new MySqlCommand("DELETE FROM " + Cod + "tbl_Janeiro WHERE pl_ano = @Ano;");
            MySqlCommand Fev = new MySqlCommand("DELETE FROM " + Cod + "tbl_Fevereiro WHERE pl_ano = @Ano;");
            MySqlCommand Mar = new MySqlCommand("DELETE FROM " + Cod + "tbl_Marco WHERE pl_ano = @Ano;");
            MySqlCommand Abr = new MySqlCommand("DELETE FROM " + Cod + "tbl_Abril WHERE pl_ano = @Ano;");
            MySqlCommand Mai = new MySqlCommand("DELETE FROM " + Cod + "tbl_Maio WHERE pl_ano = @Ano;");
            MySqlCommand Jun = new MySqlCommand("DELETE FROM " + Cod + "tbl_Junho WHERE pl_ano = @Ano;");
            MySqlCommand Jul = new MySqlCommand("DELETE FROM " + Cod + "tbl_Julho WHERE pl_ano = @Ano;");
            MySqlCommand Ago = new MySqlCommand("DELETE FROM " + Cod + "tbl_Agosto WHERE pl_ano = @Ano;");
            MySqlCommand Set = new MySqlCommand("DELETE FROM " + Cod + "tbl_Setembro WHERE pl_ano = @Ano;");
            MySqlCommand Out = new MySqlCommand("DELETE FROM " + Cod + "tbl_Outubro WHERE pl_ano = @Ano;");
            MySqlCommand Nov = new MySqlCommand("DELETE FROM " + Cod + "tbl_Novembro WHERE pl_ano = @Ano;");
            MySqlCommand Dez = new MySqlCommand("DELETE FROM " + Cod + "tbl_Dezembro WHERE pl_ano = @Ano;");
            MySqlCommand Res = new MySqlCommand("DELETE FROM " + Cod + "tbl_resultado WHERE pl_ano = @Ano;");
            MySqlCommand Total = new MySqlCommand("DELETE FROM " + Cod + "tbl_total WHERE pl_ano = @Ano;");
            MySqlCommand Meses = new MySqlCommand("DELETE FROM " + Cod + "tbl_totalmeses WHERE pl_ano = @Ano;");

            Jan.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Fev.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Mar.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Abr.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Mai.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Jun.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Jul.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Ago.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Set.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Out.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Nov.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Dez.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Res.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Total.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            Meses.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                Jan.Connection = conn;
                Fev.Connection = conn;
                Mar.Connection = conn;
                Abr.Connection = conn;
                Mai.Connection = conn;
                Jun.Connection = conn;
                Jul.Connection = conn;
                Ago.Connection = conn;
                Set.Connection = conn;
                Out.Connection = conn;
                Nov.Connection = conn;
                Dez.Connection = conn;
                Res.Connection = conn;
                Total.Connection = conn;
                Meses.Connection = conn;

                conn.Open();
                Jan.ExecuteNonQuery();
                Fev.ExecuteNonQuery();
                Mar.ExecuteNonQuery();
                Abr.ExecuteNonQuery();
                Mai.ExecuteNonQuery();
                Jun.ExecuteNonQuery();
                Jul.ExecuteNonQuery();
                Ago.ExecuteNonQuery();
                Set.ExecuteNonQuery();
                Out.ExecuteNonQuery();
                Nov.ExecuteNonQuery();
                Dez.ExecuteNonQuery();
                Res.ExecuteNonQuery();
                Total.ExecuteNonQuery();
                Meses.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcluirCategoria(int Cod, int Id)
        {
            MySqlCommand Jan = new MySqlCommand("DELETE FROM " + Cod + "tbl_Janeiro WHERE cod_categoria = @Id;");
            MySqlCommand Fev = new MySqlCommand("DELETE FROM " + Cod + "tbl_Fevereiro WHERE cod_categoria = @Id;");
            MySqlCommand Mar = new MySqlCommand("DELETE FROM " + Cod + "tbl_Marco WHERE cod_categoria = @Id;");
            MySqlCommand Abr = new MySqlCommand("DELETE FROM " + Cod + "tbl_Abril WHERE cod_categoria = @Id;");
            MySqlCommand Mai = new MySqlCommand("DELETE FROM " + Cod + "tbl_Maio WHERE cod_categoria = @Id;");
            MySqlCommand Jun = new MySqlCommand("DELETE FROM " + Cod + "tbl_Junho WHERE cod_categoria = @Id;");
            MySqlCommand Jul = new MySqlCommand("DELETE FROM " + Cod + "tbl_Julho WHERE cod_categoria = @Id;");
            MySqlCommand Ago = new MySqlCommand("DELETE FROM " + Cod + "tbl_Agosto WHERE cod_categoria = @Id;");
            MySqlCommand Set = new MySqlCommand("DELETE FROM " + Cod + "tbl_Setembro WHERE cod_categoria = @Id;");
            MySqlCommand Out = new MySqlCommand("DELETE FROM " + Cod + "tbl_Outubro WHERE cod_categoria = @Id;");
            MySqlCommand Nov = new MySqlCommand("DELETE FROM " + Cod + "tbl_Novembro WHERE cod_categoria = @Id;");
            MySqlCommand Dez = new MySqlCommand("DELETE FROM " + Cod + "tbl_Dezembro WHERE cod_categoria = @Id;");
            MySqlCommand Res = new MySqlCommand("DELETE FROM " + Cod + "tbl_resultado WHERE cod_categoria = @Id;");
            MySqlCommand Cat = new MySqlCommand("DELETE FROM " + Cod + "tbl_Categoria WHERE pl_codigo = @Id;");

            Jan.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Fev.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Mar.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Abr.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Mai.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Jun.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Jul.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Ago.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Set.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Out.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Nov.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Dez.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Res.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
            Cat.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                Jan.Connection = conn;
                Fev.Connection = conn;
                Mar.Connection = conn;
                Abr.Connection = conn;
                Mai.Connection = conn;
                Jun.Connection = conn;
                Jul.Connection = conn;
                Ago.Connection = conn;
                Set.Connection = conn;
                Out.Connection = conn;
                Nov.Connection = conn;
                Dez.Connection = conn;
                Res.Connection = conn;
                Cat.Connection = conn;

                conn.Open();
                Jan.ExecuteNonQuery();
                Fev.ExecuteNonQuery();
                Mar.ExecuteNonQuery();
                Abr.ExecuteNonQuery();
                Mai.ExecuteNonQuery();
                Jun.ExecuteNonQuery();
                Jul.ExecuteNonQuery();
                Ago.ExecuteNonQuery();
                Set.ExecuteNonQuery();
                Out.ExecuteNonQuery();
                Nov.ExecuteNonQuery();
                Dez.ExecuteNonQuery();
                Res.ExecuteNonQuery();
                Cat.ExecuteNonQuery();
                conn.Close();
            }
        }


        public DataTable MontarPlanilhaParteUm(int Ano, int Cod)
        {
            string queryString = "SELECT pl_categoria AS categoria, " +
                "jan.pl_proposta AS jan_proposta, jan.pl_realizado AS jan_realizado, " +
                "fev.pl_proposta AS fev_proposta, fev.pl_realizado AS fev_realizado, " +
                "mar.pl_proposta AS mar_proposta, mar.pl_realizado AS mar_realizado, " +
                "abr.pl_proposta AS abr_proposta, abr.pl_realizado AS abr_realizado, " +
                "mai.pl_proposta AS mai_proposta, mai.pl_realizado AS mai_realizado, " +
                "jun.pl_proposta AS jun_proposta, jun.pl_realizado AS jun_realizado " +
                "FROM " + Cod + "tbl_categoria cat " +
                "INNER JOIN " + Cod + "tbl_janeiro AS jan ON cat.pl_codigo = jan.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_fevereiro fev ON jan.cod_categoria = fev.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_marco mar ON fev.cod_categoria = mar.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_abril abr ON mar.cod_categoria = abr.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_maio mai ON abr.cod_categoria = mai.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_junho jun ON mai.cod_categoria = jun.cod_categoria " +
                "WHERE jan.pl_ano = @Ano and fev.pl_ano = @Ano and mar.pl_ano = @Ano " +
                "AND abr.pl_ano = @Ano and mai.pl_ano = @Ano and jun.pl_ano = @Ano ";

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

        public DataTable MontarPlanilhaParteDois(int Ano, int Cod)
        {
            string queryString = "SELECT pl_categoria AS categoria , " +
                "jul.pl_proposta AS jul_proposta, jul.pl_realizado AS jul_realizado, " +
                "ago.pl_proposta AS ago_proposta, ago.pl_realizado AS ago_realizado, " +
                "stb.pl_proposta AS set_proposta, stb.pl_realizado AS set_realizado, " +
                "otb.pl_proposta AS out_proposta, otb.pl_realizado AS out_realizado, " +
                "nov.pl_proposta AS nov_proposta, nov.pl_realizado AS nov_realizado, " +
                "dez.pl_proposta AS dez_proposta, dez.pl_realizado AS dez_realizado " +
                "FROM " + Cod + "tbl_categoria cat " +
                "INNER JOIN " + Cod + "tbl_julho jul ON cat.pl_codigo = jul.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_agosto ago ON jul.cod_categoria = ago.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_setembro stb ON ago.cod_categoria = stb.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_outubro otb ON stb.cod_categoria = otb.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_novembro nov ON otb.cod_categoria = nov.cod_categoria " +
                "INNER JOIN " + Cod + "tbl_dezembro dez ON nov.cod_categoria = dez.cod_categoria " +
                "WHERE jul.pl_ano = @Ano and ago.pl_ano = @Ano and stb.pl_ano = @Ano " +
                "AND otb.pl_ano = @Ano and nov.pl_ano = @Ano and dez.pl_ano = @Ano ";

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

        public DataTable ListarTotal(int Ano, int Cod, string Mes)
        {
            string queryString = "SELECT sum(pl_proposta) AS jan_propTotal, sum(pl_realizado) AS jan_realiTotal FROM " + Cod + Mes + " WHERE pl_ano = @Ano AND cod_categoria NOT IN (1)";

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

        public void AlterarTotalPropReali(int Ano, int Cod, string Mes, decimal totalPropMes, decimal totalRealiMes)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE " + Cod + "tbl_totalmeses SET pl_totalPropostaMes = @totalPropMes, pl_totalRealizadoMes = @totalRealiMes WHERE pl_ano = @Ano AND pl_tabelaMes = @Mes;");
            cmd.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@Mes", MySqlDbType.VarChar).Value = Mes;
            cmd.Parameters.Add("@totalPropMes", MySqlDbType.Decimal).Value = totalPropMes;
            cmd.Parameters.Add("@totalRealiMes", MySqlDbType.Decimal).Value = totalRealiMes;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public DataTable ListarTotalResultado(int Ano, int Cod, string Mes)
        {
            string queryString = "SELECT sum(mes.pl_proposta - tblmes.pl_totalPropostaMes) AS totalProp_result, " +
                "(mes.pl_realizado - tblmes.pl_totalRealizadoMes) AS totalReali_result " +
                "FROM " + Cod + Mes + " mes " +
                "INNER JOIN " + Cod + "tbl_totalmeses tblmes ON tblmes.pl_ano = mes.pl_ano " +
                "WHERE cod_categoria = 1 AND mes.pl_ano = @Ano AND pl_tabelaMes = @Mes";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Ano", MySqlDbType.Int32).Value = Ano;
                command.Parameters.AddWithValue("@Mes", Mes);

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
