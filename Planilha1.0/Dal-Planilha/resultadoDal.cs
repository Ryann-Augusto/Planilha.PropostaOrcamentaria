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
        public DataTable Resultados(int Ano, string Cat)
        {
            string queryString = "SELECT sum(jan.pl_proposta) + fev.pl_proposta + mar.pl_proposta + abr.pl_proposta + mai.pl_proposta + jun.pl_proposta + jul.pl_proposta + jul.pl_proposta + ago.pl_proposta + stb.pl_proposta + otb.pl_proposta + nov.pl_proposta + dez.pl_proposta AS faturamento_Prop, " +
                "sum(jan.pl_realizado) +fev.pl_realizado + mar.pl_realizado + abr.pl_realizado + mai.pl_realizado + jun.pl_realizado + jul.pl_realizado + jul.pl_realizado + ago.pl_realizado + stb.pl_realizado + otb.pl_realizado + nov.pl_realizado + dez.pl_realizado AS faturamento_Reali " +
                "FROM tbl_janeiro jan " +
                "INNER JOIN tbl_fevereiro fev ON jan.pl_categoria = fev.pl_categoria AND jan.pl_ano = fev.pl_ano INNER JOIN tbl_marco mar ON fev.pl_categoria = mar.pl_categoria AND fev.pl_ano = mar.pl_ano INNER JOIN tbl_abril abr ON mar.pl_categoria = abr.pl_categoria AND mar.pl_ano = abr.pl_ano INNER JOIN tbl_maio mai ON abr.pl_categoria = mai.pl_categoria AND abr.pl_ano = mai.pl_ano INNER JOIN tbl_junho jun ON mai.pl_categoria = jun.pl_categoria AND mai.pl_ano = jun.pl_ano INNER JOIN tbl_julho jul ON jun.pl_categoria = jul.pl_categoria AND jun.pl_ano = jul.pl_ano INNER JOIN tbl_agosto ago ON jul.pl_categoria = ago.pl_categoria AND jul.pl_ano = ago.pl_ano INNER JOIN tbl_setembro stb ON ago.pl_categoria = stb.pl_categoria AND ago.pl_ano = stb.pl_ano INNER JOIN tbl_outubro otb ON stb.pl_categoria = otb.pl_categoria AND stb.pl_ano = otb.pl_ano INNER JOIN tbl_novembro nov ON otb.pl_categoria = nov.pl_categoria AND otb.pl_ano = nov.pl_ano INNER JOIN tbl_dezembro dez ON nov.pl_categoria = dez.pl_categoria AND nov.pl_ano = dez.pl_ano WHERE jan.pl_ano = @Ano AND jan.pl_categoria = @Cat";

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

        public void AlterarResultado(int Ano, string Cat, decimal FatProp, decimal FatReali)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_resultado SET pl_propResultado = @pl_proposta , pl_realiResultado = @pl_realizacao WHERE pl_categoria = @pl_categoria AND pl_ano = @pl_ano");
            cmd.Parameters.Add("@pl_ano", MySqlDbType.Int32).Value = Ano;
            cmd.Parameters.Add("@pl_categoria", MySqlDbType.VarChar).Value = Cat;
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

        public DataTable sobreFaturamento(int Ano)
        {
            string queryString = "SELECT res.pl_realiResultado AS Faturamento, rez.pl_realiResultado AS Funcionarios " +
                "FROM tbl_resultado rez INNER JOIN tbl_resultado res " +
                "WHERE res.pl_categoria = 'Faturamento' AND res.pl_ano = @Ano " +
                "AND rez.pl_categoria = 'Funcionários' AND rez.pl_ano = @Ano; ";

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
    }
}