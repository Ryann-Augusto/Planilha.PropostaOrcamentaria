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

        public void ExisteAno(int Ano)
        {
            try
            {
                string queryString = "SELECT COUNT(1) FROM tbl_Janeiro WHERE pl_ano = @Ano";

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

        public void NovaPlanilha(int Ano)
        {
            MySqlCommand Jan = new MySqlCommand("INSERT INTO tbl_Janeiro(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Fev = new MySqlCommand("INSERT INTO tbl_Fevereiro(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Mar = new MySqlCommand("INSERT INTO tbl_Marco(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Abr = new MySqlCommand("INSERT INTO tbl_Abril(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Mai = new MySqlCommand("INSERT INTO tbl_Maio(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Jun = new MySqlCommand("INSERT INTO tbl_Junho(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Jul = new MySqlCommand("INSERT INTO tbl_Julho(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Ago = new MySqlCommand("INSERT INTO tbl_Agosto(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Set = new MySqlCommand("INSERT INTO tbl_Setembro(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Out = new MySqlCommand("INSERT INTO tbl_Outubro(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Nov = new MySqlCommand("INSERT INTO tbl_Novembro(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Dez = new MySqlCommand("INSERT INTO tbl_Dezembro(pl_ano, pl_categoria, pl_proposta, pl_realizado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");
            MySqlCommand Res = new MySqlCommand("INSERT INTO tbl_resultado(pl_ano, pl_categoria, pl_propResultado, pl_realiResultado) VALUES (@Ano, 'Faturamento', 0, 0), (@Ano, 'Funcionários', 0, 0), (@Ano, 'Energéticos', 0, 0), (@Ano, 'Materia Prm/ Embgem', 0, 0), (@Ano, 'Transporte', 0, 0), (@Ano, 'Impostos', 0, 0), (@Ano, 'Investimentos', 0, 0), (@Ano, 'Bancarias/Financ', 0, 0), (@Ano, 'Vendas', 0, 0), (@Ano, 'Administrativo', 0, 0)");

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

        public DataTable MontarPlanilha(int Ano)
        {
            string queryString = "SELECT jan.pl_categoria AS categoria, jan.pl_proposta AS jan_proposta, jan.pl_realizado AS jan_realizado, fev.pl_proposta AS fev_proposta, fev.pl_realizado AS fev_realizado, mar.pl_proposta AS mar_proposta, mar.pl_realizado AS mar_realizado, abr.pl_proposta AS abr_proposta, abr.pl_realizado AS abr_realizado, mai.pl_proposta AS mai_proposta, mai.pl_realizado AS mai_realizado, jun.pl_proposta AS jun_proposta, jun.pl_realizado AS jun_realizado, jul.pl_proposta AS jul_proposta, jul.pl_realizado AS jul_realizado, ago.pl_proposta AS ago_proposta, ago.pl_realizado AS ago_realizado, stb.pl_proposta AS set_proposta, stb.pl_realizado AS set_realizado, otb.pl_proposta AS out_proposta, otb.pl_realizado AS out_realizado, nov.pl_proposta AS nov_proposta, nov.pl_realizado AS nov_realizado, dez.pl_proposta AS dez_proposta, dez.pl_realizado AS dez_realizado " +
                "FROM tbl_janeiro AS jan INNER JOIN tbl_fevereiro AS fev ON jan.pl_categoria = fev.pl_categoria INNER JOIN tbl_marco mar ON fev.pl_categoria = mar.pl_categoria INNER JOIN tbl_abril abr ON mar.pl_categoria = abr.pl_categoria INNER JOIN tbl_maio mai ON abr.pl_categoria = mai.pl_categoria INNER JOIN tbl_junho jun ON mai.pl_categoria = jun.pl_categoria INNER JOIN tbl_julho jul ON jun.pl_categoria = jul.pl_categoria INNER JOIN tbl_agosto ago ON jul.pl_categoria = ago.pl_categoria INNER JOIN tbl_setembro stb ON ago.pl_categoria = stb.pl_categoria INNER JOIN tbl_outubro otb ON stb.pl_categoria = otb.pl_categoria INNER JOIN tbl_novembro nov ON otb.pl_categoria = nov.pl_categoria INNER JOIN tbl_dezembro dez ON nov.pl_categoria = dez.pl_categoria WHERE jan.pl_ano = @Ano and fev.pl_ano = @Ano and mar.pl_ano = @Ano and abr.pl_ano = @Ano and mai.pl_ano = @Ano and jun.pl_ano = @Ano and jul.pl_ano = @Ano and ago.pl_ano = @Ano and stb.pl_ano = @Ano and otb.pl_ano = @Ano and nov.pl_ano = @Ano and dez.pl_ano = @Ano ";

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

            public DataTable ListarTotal(int Ano)
            {
            string queryString = "SELECT sum(jan.pl_proposta) AS jan_propTotal, sum(jan.pl_realizado) AS jan_realiTotal, " +
                "sum(fev.pl_proposta) AS fev_propTotal, sum(fev.pl_realizado) AS fev_realiTotal, " +
                "sum(mar.pl_proposta) AS mar_propTotal, sum(mar.pl_realizado) AS mar_realiTotal, " +
                "sum(abr.pl_proposta) AS abr_propTotal, sum(abr.pl_realizado) AS abr_realiTotal, " +
                "sum(mai.pl_proposta) AS mai_propTotal, sum(mai.pl_realizado) AS mai_realiTotal, " +
                "sum(jun.pl_proposta) AS jun_propTotal, sum(jun.pl_realizado) AS jun_realiTotal, " +
                "sum(jul.pl_proposta) AS jul_propTotal, sum(jul.pl_realizado) AS jul_realiTotal, " +
                "sum(ago.pl_proposta) AS ago_propTotal, sum(ago.pl_realizado) AS ago_realiTotal, " +
                "sum(stb.pl_proposta) AS set_propTotal, sum(stb.pl_realizado) AS set_realiTotal, " +
                "sum(otb.pl_proposta) AS out_propTotal, sum(otb.pl_realizado) AS out_realiTotal, " +
                "sum(nov.pl_proposta) AS nov_propTotal, sum(nov.pl_realizado) AS nov_realiTotal, " +
                "sum(dez.pl_proposta) AS dez_propTotal, sum(dez.pl_realizado) AS dez_realiTotal " +
                "FROM tbl_janeiro jan " +
                "INNER JOIN tbl_fevereiro fev " +
                "ON jan.pl_categoria = fev.pl_categoria AND jan.pl_ano = fev.pl_ano " +
                "INNER JOIN tbl_marco mar " +
                "ON fev.pl_categoria = mar.pl_categoria AND fev.pl_ano = mar.pl_ano " +
                "INNER JOIN tbl_abril abr " +
                "ON mar.pl_categoria = abr.pl_categoria AND mar.pl_ano = abr.pl_ano " +
                "INNER JOIN tbl_maio mai " +
                "ON abr.pl_categoria = mai.pl_categoria AND abr.pl_ano = mai.pl_ano " +
                "INNER JOIN tbl_junho jun " +
                "ON mai.pl_categoria = jun.pl_categoria AND mai.pl_ano = jun.pl_ano " +
                "INNER JOIN tbl_julho jul " +
                "ON jun.pl_categoria = jul.pl_categoria AND jun.pl_ano = jul.pl_ano " +
                "INNER JOIN tbl_agosto ago " +
                "ON jul.pl_categoria = ago.pl_categoria AND jul.pl_ano = ago.pl_ano " +
                "INNER JOIN tbl_setembro stb " +
                "ON ago.pl_categoria = stb.pl_categoria AND ago.pl_ano = stb.pl_ano " +
                "INNER JOIN tbl_outubro otb " +
                "ON stb.pl_categoria = otb.pl_categoria AND stb.pl_ano = otb.pl_ano " +
                "INNER JOIN tbl_novembro nov " +
                "ON otb.pl_categoria = nov.pl_categoria AND otb.pl_ano = nov.pl_ano " +
                "INNER JOIN tbl_dezembro dez " +
                "ON nov.pl_categoria = dez.pl_categoria AND nov.pl_ano = dez.pl_ano " +
                "WHERE jan.pl_ano = @Ano;";

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
