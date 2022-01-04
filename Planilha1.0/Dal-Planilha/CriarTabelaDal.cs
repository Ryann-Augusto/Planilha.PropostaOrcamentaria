using MySql.Data.MySqlClient;
using System.Configuration;

namespace Dal_Planilha
{
    public class CriarTabelaDal
    {

        private string MysqlConn()
        {
            return ConfigurationManager.AppSettings["MysqlConn"];
        }

        public void CriarTabelas(int Cod)
        {

            MySqlCommand Categoria = new MySqlCommand("CREATE TABLE " + Cod + "tbl_categoria " +
                "(pl_codigo int primary key not null auto_increment, " +
                "pl_categoria varchar(30));");

            MySqlCommand AddCategoria = new MySqlCommand("INSERT INTO " + Cod + "tbl_categoria(pl_categoria) VALUES ('Faturamento'), ('Funcionários'), ('Energéticos'), ('Embalagem'), ('Transporte'), ('Impostos'), ('Investimentos'), ('Bancarias/Financ'), ('Vendas'), ('Administrativo');");

            MySqlCommand resultado = new MySqlCommand("CREATE TABLE " + Cod + "tbl_resultado " +
                "(pl_codigo int primary key not null auto_increment, " +
                "pl_propResultado decimal(10, 2) null, " +
                "pl_realiResultado decimal(10, 2) null, " +
                "pl_sobreFaturamento decimal(10, 2) null, " +
                "pl_contrib_Despesas decimal(10, 2) null, " +
                "pl_ano int(4) null, " +
                "cod_categoria int not null, " +
                "foreign key(cod_categoria) references " + Cod + "tbl_Categoria(pl_codigo))charset = utf8mb4;");

            MySqlCommand total = new MySqlCommand("CREATE TABLE " + Cod + "tbl_total " +
                "(pl_codigo int primary key auto_increment, " +
                "pl_totalProposta decimal(10, 2) null, " +
                "pl_totalRealizado decimal(10, 2) null, " +
                "pl_propostaTabResultado decimal(10, 2) null, " +
                "pl_realizadoTabResultado decimal(10, 2) null, " +
                "pl_ano int(4) not null)charset = utf8mb4;");

            MySqlCommand totalMeses = new MySqlCommand("CREATE TABLE " + Cod + "tbl_totalmeses " +
                "(pl_codigo int primary key auto_increment, " +
                "pl_totalPropostaMes decimal(10, 2) null, " +
                "pl_totalRealizadoMes decimal(10, 2) null, " +
                "pl_tabelaMes varchar(30) null, " +
                "pl_ano int(4) not null)charset = utf8mb4;");

            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                Categoria.Connection = conn;
                AddCategoria.Connection = conn;
                resultado.Connection = conn;
                total.Connection = conn;
                totalMeses.Connection = conn;


                conn.Open();

                Categoria.ExecuteNonQuery();
                AddCategoria.ExecuteNonQuery();
                resultado.ExecuteNonQuery();
                total.ExecuteNonQuery();
                totalMeses.ExecuteNonQuery();

                conn.Close();
            }
        }

        public void CriarTabelaMeses(int Cod, string Tbl)
        {
            MySqlCommand meses = new MySqlCommand("CREATE TABLE " + Cod + Tbl +
                "(pl_codigo int primary key not null auto_increment, " +
                "pl_ano int(4) not null, " +
                "pl_proposta decimal(10, 2) null, " +
                "pl_realizado decimal(10, 2) null, " +
                "cod_categoria int not null, " +
                "foreign key(cod_categoria) references " + Cod + "tbl_Categoria(pl_codigo)) " +
                "charset = utf8mb4; ");


            using (MySqlConnection conn = new MySqlConnection(MysqlConn()))
            {
                meses.Connection = conn;

                conn.Open();

                meses.ExecuteNonQuery();

                conn.Close();
            }
        }

        public void ApagarTabela(int Cod, string Tbl)
        {
            MySqlCommand cmd = new MySqlCommand("DROP TABLE " + Cod + Tbl);

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
