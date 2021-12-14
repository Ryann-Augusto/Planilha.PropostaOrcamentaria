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
        

        public static mdJaneiro ObterCodigo(string Usuario)
        {
            var usuario = new mdJaneiro();
            var codigoDb = new Dal_Planilha.UsuarioDal();
            
            foreach (DataRow row in codigoDb.ObterCodigo(Usuario).Rows)
            {
                usuario.CodigoUsuario= Convert.ToInt32(row["pl_codigo"]);
                usuario.NivelUsuario = Convert.ToInt32(row["pl_nivel"]);
            }
            return usuario;
        }

        

        public List<mdJaneiro> ObterUsuarios()
        {
            var lista = new List<mdJaneiro>();
            var planilhaDB = new Dal_Planilha.UsuarioDal();
            foreach (DataRow row in planilhaDB.ObterUsuarios().Rows)
            {
                var usuario = new mdJaneiro();
                usuario.CodigoUsuario = Convert.ToInt32(row["pl_codigo"]);
                usuario.NomeUsuario = Convert.ToString(row["pl_usuario"]);
                usuario.SenhaUsuario = Convert.ToString(row["pl_senha"]);
                usuario.NivelUsuario = Convert.ToInt32(row["pl_nivel"]);

                lista.Add(usuario);
            }
            return lista;
        }
    }
}
