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
    public class ImpressaoDal
    {
        private string MysqlConn()
        {
            //Chama a string de conexao dentro do Web.Config do projeto.
            return ConfigurationManager.AppSettings["MysqlConn"];
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
    }
}
