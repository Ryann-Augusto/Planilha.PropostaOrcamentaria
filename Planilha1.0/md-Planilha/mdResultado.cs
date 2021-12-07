using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdResultado
    {
        List<mdJaneiro> lista = new List<mdJaneiro>();

        public List<mdJaneiro> Listarfaturamento(int Ano)
        {
            int[] categoria = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {

                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.Resultados(Ano, Cat).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.Categoria = Convert.ToString(row["categoria"]);
                    planilha.FaturamentoPropResult = Convert.ToDecimal(row["faturamento_Prop"]);
                    planilha.FaturamentoRealiResult = Convert.ToDecimal(row["faturamento_Reali"]);

                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarResultado(Ano, Cat, planilha.FaturamentoPropResult, planilha.FaturamentoRealiResult);
                }
            }
            return lista;
        }

        public static mdJaneiro TotalPropResultados(int Ano)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalPropResultados(Ano).Rows)
            {
                planilha.PropResultado = Convert.ToDecimal(row["PropResultado"]);

                new Dal_Planilha.resultadoDal().AlterarTotalProposta(Ano, planilha.PropResultado);
            }
            return planilha;
        }

        public static mdJaneiro TotalRealiResultados(int Ano)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalRealiResultados(Ano).Rows)
            {
                planilha.RealiResultado = Convert.ToDecimal(row["RealiResultado"]);

                new Dal_Planilha.resultadoDal().AlterarTotalRealizado(Ano, planilha.RealiResultado);
            }
            return planilha;
        }

        public List<mdJaneiro> sobreFaturamento(int Ano)
        {
            var planilhaDB = new Dal_Planilha.resultadoDal();

            int[] categoria = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {
                foreach (DataRow row in planilhaDB.sobreFaturamento(Ano, Cat).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.SobreFaturamento = Convert.ToDecimal(row["sobreFaturamento"]);
                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarSobreFat(Ano, Cat, planilha.SobreFaturamento);
                }
            }
            return lista;
        }

        public static mdJaneiro TotalSobreFaturamento(int Ano)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalSobreFaturamento(Ano).Rows)
            {
                planilha.TotalSobreFaturamento = Convert.ToDecimal(row["Total_SobreFaturamento"]);
            }
            return planilha;
        }

        public List<mdJaneiro> contribDespesas(int Ano)
        {
            var planilhaDB = new Dal_Planilha.resultadoDal();

            int[] categoria = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {
                foreach (DataRow row in planilhaDB.contribuicaoDespesas(Ano, Cat).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.ContribuicaoDespesas = Convert.ToDecimal(row["contribDespesas"]);
                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarContribDespesas(Ano, Cat, planilha.ContribuicaoDespesas);
                }
            }
            return lista;
        }

        public static mdJaneiro TotalContribDespesas(int Ano)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalContribDespesas(Ano).Rows)
            {
                planilha.TotalContribDespesas = Convert.ToDecimal(row["totalContribDespesas"]);
            }
            return planilha;
        }
    }
}
