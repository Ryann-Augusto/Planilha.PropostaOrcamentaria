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
            try
            {
                string queryString = "SELECT COUNT(1) FROM "+Cod+"tbl_Janeiro WHERE pl_ano = @Ano";

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
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NovaPlanilha(int Ano, int Cod)
        {
            MySqlCommand Jan = new MySqlCommand("INSERT INTO "+Cod+"tbl_Janeiro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Fev = new MySqlCommand("INSERT INTO "+Cod+"tbl_Fevereiro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Mar = new MySqlCommand("INSERT INTO "+Cod+"tbl_Marco(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Abr = new MySqlCommand("INSERT INTO "+Cod+"tbl_Abril(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Mai = new MySqlCommand("INSERT INTO "+Cod+"tbl_Maio(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Jun = new MySqlCommand("INSERT INTO "+Cod+"tbl_Junho(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Jul = new MySqlCommand("INSERT INTO "+Cod+"tbl_Julho(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Ago = new MySqlCommand("INSERT INTO "+Cod+"tbl_Agosto(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Set = new MySqlCommand("INSERT INTO "+Cod+"tbl_Setembro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Out = new MySqlCommand("INSERT INTO "+Cod+"tbl_Outubro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Nov = new MySqlCommand("INSERT INTO "+Cod+"tbl_Novembro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Dez = new MySqlCommand("INSERT INTO "+Cod+"tbl_Dezembro(pl_ano, pl_proposta, pl_realizado, cod_categoria) VALUES (@Ano, 0, 0, 1), (@Ano, 0, 0, 2), (@Ano, 0, 0, 3), (@Ano, 0, 0, 4), (@Ano, 0, 0, 5), (@Ano, 0, 0, 6), (@Ano, 0, 0, 7), (@Ano, 0, 0, 8), (@Ano, 0, 0, 9), (@Ano, 0, 0, 10)");
            MySqlCommand Res = new MySqlCommand("INSERT INTO "+Cod+ "tbl_resultado(pl_ano, pl_propResultado, pl_realiResultado, cod_categoria, pl_sobreFaturamento, pl_contrib_Despesas) VALUES (@Ano, 0, 0, 1, NULL, NULL), (@Ano, 0, 0, 2, 0, 0), (@Ano, 0, 0, 3, 0, 0), (@Ano, 0, 0, 4, 0, 0), (@Ano, 0, 0, 5, 0, 0), (@Ano, 0, 0, 6, 0, 0 ), (@Ano, 0, 0, 7, 0, 0), (@Ano, 0, 0, 8, 0, 0 ), (@Ano, 0, 0, 9, 0, 0), (@Ano, 0, 0, 10, 0, 0)");
            MySqlCommand Total = new MySqlCommand("INSERT INTO "+Cod+"tbl_total(pl_ano, pl_totalProposta, pl_totalRealizado) VALUES (@Ano, 0, 0)");
            MySqlCommand Meses = new MySqlCommand("INSERT INTO "+Cod+"tbl_totalmeses(pl_ano, pl_totalPropostaMes, pl_totalRealizadoMes, pl_tabelaMes) VALUES (@Ano, 0, 0, 'tbl_janeiro'), (@Ano, 0, 0, 'tbl_fevereiro'), (@Ano, 0, 0, 'tbl_marco'), (@Ano, 0, 0, 'tbl_abril'), (@Ano, 0, 0, 'tbl_maio'), (@Ano, 0, 0, 'tbl_junho'), (@Ano, 0, 0, 'tbl_julho'), (@Ano, 0, 0, 'tbl_agosto'), (@Ano, 0, 0, 'tbl_setembro'), (@Ano, 0, 0, 'tbl_outubro'), (@Ano, 0, 0, 'tbl_novembro'), (@Ano, 0, 0, 'tbl_dezembro')");

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

        public DataTable MontarPlanilha(int Ano, int Cod)
        {
            string queryString = "SELECT cat.pl_categoria AS categoria, jan.pl_proposta AS jan_proposta, jan.pl_realizado AS jan_realizado, fev.pl_proposta AS fev_proposta, fev.pl_realizado AS fev_realizado, mar.pl_proposta AS mar_proposta, mar.pl_realizado AS mar_realizado, abr.pl_proposta AS abr_proposta, abr.pl_realizado AS abr_realizado, mai.pl_proposta AS mai_proposta, mai.pl_realizado AS mai_realizado, jun.pl_proposta AS jun_proposta, jun.pl_realizado AS jun_realizado, jul.pl_proposta AS jul_proposta, jul.pl_realizado AS jul_realizado, ago.pl_proposta AS ago_proposta, ago.pl_realizado AS ago_realizado, stb.pl_proposta AS set_proposta, stb.pl_realizado AS set_realizado, otb.pl_proposta AS out_proposta, otb.pl_realizado AS out_realizado, nov.pl_proposta AS nov_proposta, nov.pl_realizado AS nov_realizado, dez.pl_proposta AS dez_proposta, dez.pl_realizado AS dez_realizado " +
                "FROM "+Cod+"tbl_janeiro AS jan INNER JOIN tbl_categoria cat ON cat.pl_codigo = jan.cod_categoria INNER JOIN "+Cod+"tbl_fevereiro fev ON jan.cod_categoria = fev.cod_categoria INNER JOIN "+Cod+"tbl_marco mar ON fev.cod_categoria = mar.cod_categoria INNER JOIN "+Cod+ "tbl_abril abr ON mar.cod_categoria = abr.cod_categoria INNER JOIN "+Cod+ "tbl_maio mai ON abr.cod_categoria = mai.cod_categoria INNER JOIN "+Cod+ "tbl_junho jun ON mai.cod_categoria = jun.cod_categoria INNER JOIN "+Cod+ "tbl_julho jul ON jun.cod_categoria = jul.cod_categoria INNER JOIN "+Cod+"tbl_agosto ago ON jul.cod_categoria = ago.cod_categoria INNER JOIN "+Cod+"tbl_setembro stb ON ago.cod_categoria = stb.cod_categoria INNER JOIN "+Cod+"tbl_outubro otb ON stb.cod_categoria = otb.cod_categoria INNER JOIN "+Cod+"tbl_novembro nov ON otb.cod_categoria = nov.cod_categoria INNER JOIN "+Cod+"tbl_dezembro dez ON nov.cod_categoria = dez.cod_categoria " +
                "WHERE jan.pl_ano = @Ano and fev.pl_ano = @Ano and mar.pl_ano = @Ano and abr.pl_ano = @Ano and mai.pl_ano = @Ano and jun.pl_ano = @Ano and jul.pl_ano = @Ano and ago.pl_ano = @Ano and stb.pl_ano = @Ano and otb.pl_ano = @Ano and nov.pl_ano = @Ano and dez.pl_ano = @Ano ";

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
            string queryString = "SELECT sum(pl_proposta) AS jan_propTotal, sum(pl_realizado) AS jan_realiTotal FROM "+Cod+Mes+ " WHERE pl_ano = @Ano AND cod_categoria NOT IN (1)";

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
            MySqlCommand cmd = new MySqlCommand("UPDATE "+Cod+"tbl_totalmeses SET pl_totalPropostaMes = @totalPropMes, pl_totalRealizadoMes = @totalRealiMes, pl_ano = @Ano WHERE pl_tabelaMes = @Mes;");
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
                "FROM "+Cod+Mes+" mes " +
                "INNER JOIN "+Cod+"tbl_totalmeses tblmes ON tblmes.pl_ano = mes.pl_ano " +
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
