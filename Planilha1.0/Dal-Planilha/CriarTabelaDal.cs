using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Planilha
{
    public class CriarTabelaDal
    {

        private string MysqlConn()
        {
            return ConfigurationManager.AppSettings["MysqlConn"];
        }

        public void CriarTabela(int Cod, string Tbl)
        {
            MySqlCommand jan = new MySqlCommand("CREATE TABLE "+Cod+Tbl+
                "(pl_codigo int primary key not null auto_increment, " +
                "pl_ano int(4) not null, " +
                "pl_proposta decimal(10, 2) null, " +
                "pl_realizado decimal(10, 2) null, " +
                "cod_categoria int not null, " +
                "foreign key(cod_categoria) references tbl_Categoria(pl_codigo)) " +
                "charset = utf8mb4; ");
            
            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                jan.Connection = conn;
                conn.Open();
                jan.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ApagarTabela(int Cod, string Tbl)
        {
            MySqlCommand cmd = new MySqlCommand("DROP TABLE "+Cod+Tbl+";");
        }
    }
}
