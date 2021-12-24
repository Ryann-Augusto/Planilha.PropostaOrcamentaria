using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdUsuario
    {
        

        public static mdValores ObterCodigo(string Usuario)
        {
            var usuario = new mdValores();
            var codigoDb = new Dal_Planilha.UsuarioDal();
            
            foreach (DataRow row in codigoDb.ObterCodigo(Usuario).Rows)
            {
                usuario.CodigoUsuario= Convert.ToInt32(row["pl_codigo"]);
                usuario.NivelUsuario = Convert.ToInt32(row["pl_nivel"]);
            }
            return usuario;
        }

        

        public List<mdValores> ObterUsuarios()
        {
            var lista = new List<mdValores>();
            var planilhaDB = new Dal_Planilha.UsuarioDal();
            foreach (DataRow row in planilhaDB.ObterUsuarios().Rows)
            {
                var usuario = new mdValores();
                usuario.CodigoUsuario = Convert.ToInt32(row["pl_codigo"]);
                usuario.NomeUsuario = Convert.ToString(row["pl_usuario"]);
                usuario.SenhaUsuario = Convert.ToString(row["pl_senha"]);
                usuario.NivelUsuario = Convert.ToInt32(row["pl_nivel"]);

                lista.Add(usuario);
            }
            return lista;
        }

        public void CadUsuario(string Nome, string Senha, int Nivel)
        {
            new Dal_Planilha.UsuarioDal().CadUsuario(Nome, Senha, Nivel);
        }

        public void CriarTabelas(int Cod)
        {
            string[] tabela = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho", "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
            foreach (var tbl in tabela)
            {
                new Dal_Planilha.CriarTabelaDal().CriarTabelaMeses(Cod, tbl);
            }
            new Dal_Planilha.CriarTabelaDal().CriarTabelas(Cod);
        }

        public static mdValores BuscarUsuId(int Codigo)
        {
            var planilha = new mdValores();
            var planilhaDB = new Dal_Planilha.UsuarioDal();

            foreach (DataRow row in planilhaDB.BuscarUsuId(Codigo).Rows)
            {
                planilha.CodigoUsuario = Convert.ToInt32(row["pl_codigo"]);
                planilha.NomeUsuario = Convert.ToString(row["pl_usuario"]);
                planilha.SenhaUsuario = Convert.ToString(row["pl_senha"]);
                planilha.NivelUsuario = Convert.ToInt32(row["pl_nivel"]);
            }
            return planilha;
        }

        public void ApagarTabelas(int Cod)
        {
            string[] tabela = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho", "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro", "tbl_resultado", "tbl_total", "tbl_totalmeses" };
            foreach (var tbl in tabela)
            {
                new Dal_Planilha.CriarTabelaDal().ApagarTabela(Cod, tbl);
            }
        }

        public void AlterarNome(int Codigo, string Nome)
        {
            new Dal_Planilha.UsuarioDal().AlterarNome(Codigo, Nome);
        }

        public void AlterarTudo(int Codigo, string Nome, string Senha)
        {
            new Dal_Planilha.UsuarioDal().AlterarTudo(Codigo, Nome, Senha);
        }

        public void ApagarUsuario(int Cod)
        {
            new Dal_Planilha.UsuarioDal().ApagarUsuario(Cod);
        }
    }
}
