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
    public class resultadoDal
    {
        private string MysqlConn()
        {
            return ConfigurationManager.AppSettings["MysqlConn"];
        }
        public DataTable Resultados(int Ano, int Cat, int Cod)
        {
            string queryString = "SELECT cat.pl_categoria AS categoria, sum(jan.pl_proposta) + fev.pl_proposta + mar.pl_proposta + abr.pl_proposta + mai.pl_proposta + jun.pl_proposta + jul.pl_proposta + jul.pl_proposta + ago.pl_proposta + stb.pl_proposta + otb.pl_proposta + nov.pl_proposta + dez.pl_proposta AS faturamento_Prop, " +
                "sum(jan.pl_realizado) +fev.pl_realizado + mar.pl_realizado + abr.pl_realizado + mai.pl_realizado + jun.pl_realizado + jul.pl_realizado + jul.pl_realizado + ago.pl_realizado + stb.pl_realizado + otb.pl_realizado + nov.pl_realizado + dez.pl_realizado AS faturamento_Reali " +
                "FROM "+Cod+"tbl_janeiro jan " +
                "INNER JOIN tbl_categoria cat ON cat.pl_codigo = jan.cod_categoria INNER JOIN "+Cod+ "tbl_fevereiro fev ON jan.cod_categoria = fev.cod_categoria AND jan.pl_ano = fev.pl_ano INNER JOIN "+Cod+ "tbl_marco mar ON fev.cod_categoria = mar.cod_categoria AND fev.pl_ano = mar.pl_ano INNER JOIN "+Cod+ "tbl_abril abr ON mar.cod_categoria = abr.cod_categoria AND mar.pl_ano = abr.pl_ano INNER JOIN "+Cod+ "tbl_maio mai ON abr.cod_categoria = mai.cod_categoria AND abr.pl_ano = mai.pl_ano INNER JOIN "+Cod+ "tbl_junho jun ON mai.cod_categoria = jun.cod_categoria AND mai.pl_ano = jun.pl_ano INNER JOIN "+Cod+ "tbl_julho jul ON jun.cod_categoria = jul.cod_categoria AND jun.pl_ano = jul.pl_ano INNER JOIN "+Cod+ "tbl_agosto ago ON jul.cod_categoria = ago.cod_categoria AND jul.pl_ano = ago.pl_ano INNER JOIN "+Cod+ "tbl_setembro stb ON ago.cod_categoria = stb.cod_categoria AND ago.pl_ano = stb.pl_ano INNER JOIN "+Cod+ "tbl_outubro otb ON stb.cod_categoria = otb.cod_categoria AND stb.pl_ano = otb.pl_ano INNER JOIN "+Cod+ "tbl_novembro nov ON otb.cod_categoria = nov.cod_categoria AND otb.pl_ano = nov.pl_ano INNER JOIN "+Cod+"tbl_dezembro dez ON nov.cod_categoria = dez.cod_categoria AND nov.pl_ano = dez.pl_ano WHERE jan.pl_ano = @Ano AND cat.pl_codigo = @Cat";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                cmd.Parameters.Add("@Cat", MySqlDbType.VarChar).Value = Cat;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }

        public void AlterarResultado(int Ano, int Cod, int Cat, decimal FatProp, decimal FatReali)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE "+Cod+"tbl_resultado SET pl_propResultado = @pl_proposta , pl_realiResultado = @pl_realizacao WHERE cod_categoria = @cod_categoria AND pl_ano = @pl_ano");
            cmd.Parameters.Add("@pl_ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@cod_categoria", MySqlDbType.Int32).Value = Cat;
            cmd.Parameters.Add("@pl_proposta", MySqlDbType.Decimal).Value = FatProp;
            cmd.Parameters.Add("@pl_realizacao", MySqlDbType.Decimal).Value = FatReali;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public DataTable totalPropResultados(int Ano, int Cod)
        {
            string queryString = "SELECT sum(pl_propResultado) AS PropResultado FROM "+Cod+"tbl_resultado WHERE pl_ano = @Ano AND cod_categoria NOT IN (1) ";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }

        public DataTable totalRealiResultados(int Ano, int Cod)
        {
            string queryString = "SELECT sum(pl_realiResultado) AS RealiResultado FROM "+Cod+"tbl_resultado WHERE pl_ano = @Ano AND cod_categoria NOT IN (1) ";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }

        public DataTable sobreFaturamento(int Ano, int Cod, int Cat)
        {
            string queryString = "SELECT sum(rez.pl_realiResultado / res.pl_realiResultado * 100) AS sobreFaturamento "+ 
                "FROM "+Cod+"tbl_resultado rez INNER JOIN "+Cod+"tbl_resultado res "+
                "WHERE res.cod_categoria = '1' AND res.pl_ano = @Ano "+
                "AND rez.cod_categoria = @Cat AND rez.pl_ano = @Ano ";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }
        public void AlterarSobreFat(int Ano, int Cod, int Cat, decimal sobreFat)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE "+Cod+"tbl_resultado SET pl_sobreFaturamento = @sobreFaturamento WHERE cod_categoria = @cod_categoria AND pl_ano = @pl_ano");
            cmd.Parameters.Add("@pl_ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@cod_categoria", MySqlDbType.Int32).Value = Cat;
            cmd.Parameters.Add("@sobreFaturamento", MySqlDbType.Decimal).Value = sobreFat;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void AlterarTotalProposta(int Ano, int Cod, decimal totalProp)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE "+Cod+"tbl_total SET pl_totalProposta = @totalProposta WHERE pl_ano = @Ano;");
            cmd.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@totalProposta", MySqlDbType.Decimal).Value = totalProp;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void AlterarTotalRealizado(int Ano, int Cod, decimal totalProp)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE "+Cod+"tbl_total SET pl_totalRealizado = @totalRealizado WHERE pl_ano = @Ano;");
            cmd.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@totalRealizado", MySqlDbType.Decimal).Value = totalProp;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }


        public DataTable totalSobreFaturamento(int Ano, int Cod)
        {
            string queryString = "SELECT sum(pl_sobreFaturamento) AS Total_SobreFaturamento FROM "+Cod+"tbl_resultado WHERE pl_ano = @Ano ";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }

        public DataTable contribuicaoDespesas(int Ano, int Cod, int Cat)
        {
            string queryString = "SELECT sum(res.pl_realiResultado / tot.pl_totalRealizado * 100) AS contribDespesas " +
                "FROM "+Cod+"tbl_resultado res " +
                "INNER JOIN "+Cod+"tbl_total tot " +
                "ON tot.pl_ano = res.pl_ano " +
                "WHERE res.cod_categoria = @Cat " +
                "AND res.pl_ano = @Ano ";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }

        public DataTable totalContribDespesas(int Ano, int Cod)
        {
            string queryString = "SELECT sum(pl_contrib_Despesas) AS totalContribDespesas FROM "+Cod+"tbl_resultado WHERE pl_ano = @Ano ";

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.Add("@Ano", MySqlDbType.Decimal).Value = Ano;
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                adapter.Fill(table);

                connection.Close();

                return table;
            }
        }

        public void AlterarContribDespesas(int Ano, int Cod, int Cat, decimal contriDespesas)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE "+Cod+"tbl_resultado SET pl_contrib_Despesas = @contriDespesas WHERE pl_ano = @Ano AND cod_categoria = @Cat;");
            cmd.Parameters.Add("@Ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@Cat", MySqlDbType.Int32).Value = Cat;
            cmd.Parameters.Add("@contriDespesas", MySqlDbType.Decimal).Value = contriDespesas;

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