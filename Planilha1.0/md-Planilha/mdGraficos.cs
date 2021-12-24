using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdGraficos
    {

        List<mdValores> lista = new List<mdValores>();

        public List<mdValores> MontarGraficos(int Ano, int Cod)
        {
            string[] categoria = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho", "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
            foreach (string Mes in categoria)
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.GraficosDal();
                foreach (DataRow row in planilhaDB.MontarGraficos(Ano, Cod, Mes).Rows)
                {
                    planilha.Proposta = Convert.ToDecimal(row["proposta"]);
                    planilha.Realizado = Convert.ToDecimal(row["realizado"]);

                    lista.Add(planilha);

                }
            }
            return lista;
        }
    }
}
