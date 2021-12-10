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
            var codigo = new mdJaneiro();
            var codigoDb = new Dal_Planilha.UsuarioDal();
            
            foreach (DataRow row in codigoDb.ObterCodigo(Usuario).Rows)
            {
                codigo.CodigoEmpresa = Convert.ToInt32(row["pl_codigo"]); 
            }
            return codigo;
        }
    }
}
