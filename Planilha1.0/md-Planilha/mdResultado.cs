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
            string[] categoria = { "Faturamento", "Funcionários", "Energéticos", "Materia Prm/ Embgem", "Transporte", "Impostos", "Investimentos", "Bancarias/Financ", "Vendas", "Administrativo" };
            foreach (string Cat in categoria)
            {

                var planilhaDB = new Dal_Planilha.resultadoDal();
                foreach (DataRow row in planilhaDB.Resultados(Ano, Cat).Rows)
                {
                    var planilha = new mdJaneiro();
                    planilha.Categoria = Cat;
                    planilha.FaturamentoPropResult = Convert.ToDecimal(row["faturamento_Prop"]);
                    planilha.FaturamentoRealiResult = Convert.ToDecimal(row["faturamento_Reali"]);

                    lista.Add(planilha);

                    new Dal_Planilha.resultadoDal().AlterarResultado(Ano, Cat, planilha.FaturamentoPropResult, planilha.FaturamentoRealiResult);
                }
            }
            return lista;
        }

        public static mdJaneiro sobreFaturamento(int Ano)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.resultadoDal();

            foreach (DataRow row in planilhaDB.sobreFaturamento(Ano).Rows)
            {
                 
                planilha.SobreFuncionario = Convert.ToDecimal(row["Faturamento"]) / Convert.ToDecimal(row["Funcionarios"]);
            }
            return planilha;
        }
    }
}
