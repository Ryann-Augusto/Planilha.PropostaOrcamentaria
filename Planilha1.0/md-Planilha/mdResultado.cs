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

        public List<mdJaneiro> Listarfaturamento(int Ano, int Cod)
        {
            int[] categoria = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {

                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.Resultados(Ano, Cat, Cod).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.Categoria = Convert.ToString(row["categoria"]);
                    planilha.FaturamentoPropResult = Convert.ToDecimal(row["faturamento_Prop"]);
                    planilha.FaturamentoRealiResult = Convert.ToDecimal(row["faturamento_Reali"]);

                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarResultado(Ano, Cod, Cat, planilha.FaturamentoPropResult, planilha.FaturamentoRealiResult);
                }
            }
            return lista;
        }

        public static mdJaneiro TotalPropResultados(int Ano, int Cod)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalPropResultados(Ano, Cod).Rows)
            {
                planilha.PropResultado = Convert.ToDecimal(row["PropResultado"]);

                new Dal_Planilha.resultadoDal().AlterarTotalProposta(Ano, Cod, planilha.PropResultado);
            }
            return planilha;
        }

        public static mdJaneiro TotalRealiResultados(int Ano, int Cod)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalRealiResultados(Ano, Cod).Rows)
            {
                planilha.RealiResultado = Convert.ToDecimal(row["RealiResultado"]);

                new Dal_Planilha.resultadoDal().AlterarTotalRealizado(Ano, Cod, planilha.RealiResultado);
            }
            return planilha;
        }

        public List<mdJaneiro> sobreFaturamento(int Ano, int Cod)
        {
            var planilhaDB = new Dal_Planilha.resultadoDal();

            int[] categoria = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {
                foreach (DataRow row in planilhaDB.sobreFaturamento(Ano, Cod, Cat ).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.SobreFaturamento = Convert.ToDecimal(row["sobreFaturamento"]);
                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarSobreFat(Ano, Cod, Cat, planilha.SobreFaturamento);
                }
            }
            return lista;
        }

        public static mdJaneiro TotalSobreFaturamento(int Ano, int Cod)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalSobreFaturamento(Ano, Cod).Rows)
            {
                planilha.TotalSobreFaturamento = Convert.ToDecimal(row["Total_SobreFaturamento"]);
            }
            return planilha;
        }

        public List<mdJaneiro> contribDespesas(int Ano, int Cod)
        {
            var planilhaDB = new Dal_Planilha.resultadoDal();

            int[] categoria = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int Cat in categoria)
            {
                foreach (DataRow row in planilhaDB.contribuicaoDespesas(Ano, Cod, Cat).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.ContribuicaoDespesas = Convert.ToDecimal(row["contribDespesas"]);
                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarContribDespesas(Ano, Cod, Cat, planilha.ContribuicaoDespesas);
                }
            }
            return lista;
        }

        public static mdJaneiro TotalContribDespesas(int Ano, int Cod)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();
            foreach (DataRow row in planilhaDB.totalContribDespesas(Ano, Cod).Rows)
            {
                planilha.TotalContribDespesas = Convert.ToDecimal(row["totalContribDespesas"]);
            }
            return planilha;
        }
    }
}
