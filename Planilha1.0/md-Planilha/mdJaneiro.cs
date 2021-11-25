using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdJaneiro : mdModelo
    {
        List<mdJaneiro> lista = new List<mdJaneiro>();

        public List<mdJaneiro> Lista(int ano, string mes)
        {
            var lista = new List<mdJaneiro>();
            var planilhaDB = new Dal_Planilha.JaneiroDal();
            foreach (DataRow row in planilhaDB.Lista(ano, mes).Rows)
            {
                var planilha = new mdJaneiro();
                planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                planilha.Categoria = Convert.ToString(row["pl_categoria"]);
                planilha.Proposta = Convert.ToDecimal(row["pl_proposta"]);
                planilha.Realizado = Convert.ToDecimal(row["pl_realizado"]);

                lista.Add(planilha);
            }
            return lista;
        }

        public static mdJaneiro BuscaPorId(int Codigo, string Mes)
        {
            var planilha = new mdJaneiro();
            var planilhaDB = new Dal_Planilha.JaneiroDal();

            foreach (DataRow row in planilhaDB.BuscaPorId(Codigo, Mes).Rows)
            {
                planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                planilha.Categoria = Convert.ToString(row["pl_categoria"]);
                planilha.Proposta = Convert.ToDecimal(row["pl_proposta"]);
                planilha.Realizado = Convert.ToDecimal(row["pl_realizado"]);
            }
            return planilha;
        }
       
        public void alter(string mes)
        {
            new Dal_Planilha.JaneiroDal().Alterar(this.Codigo, this.Proposta, this.Realizado, mes);
        }

        public void NovaPlanilha(int Ano)
        {
            new Dal_Planilha.CriarPlanilhaDal().NovaPlanilha(Ano);
        }

        public void ExisteAno(int Ano)
        {
            try
            {
                new Dal_Planilha.CriarPlanilhaDal().ExisteAno(Ano);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<mdJaneiro> ListarTodos(int Ano)
        {
            
            var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
            foreach (DataRow row in planilhaDB.MontarPlanilha(Ano).Rows)
            {
                var planilha = new mdJaneiro();
                planilha.Categoria = Convert.ToString(row["categoria"]);
                planilha.JanProposta = Convert.ToDecimal(row["jan_proposta"]);
                planilha.JanRealizado = Convert.ToDecimal(row["jan_realizado"]);
                planilha.FevProposta = Convert.ToDecimal(row["fev_proposta"]);
                planilha.FevRealizado = Convert.ToDecimal(row["fev_realizado"]);
                planilha.MarProposta = Convert.ToDecimal(row["mar_proposta"]);
                planilha.MarRealizado = Convert.ToDecimal(row["mar_realizado"]);
                planilha.AbrProposta = Convert.ToDecimal(row["abr_proposta"]);
                planilha.AbrRealizado = Convert.ToDecimal(row["abr_realizado"]);
                planilha.MaiProposta = Convert.ToDecimal(row["mai_proposta"]);
                planilha.MaiRealizado = Convert.ToDecimal(row["mai_realizado"]);
                planilha.JunProposta = Convert.ToDecimal(row["jun_proposta"]);
                planilha.JunRealizado = Convert.ToDecimal(row["jun_realizado"]);
                planilha.JulProposta = Convert.ToDecimal(row["jul_proposta"]);
                planilha.JulRealizado = Convert.ToDecimal(row["jul_realizado"]);
                planilha.AgoProposta = Convert.ToDecimal(row["Ago_proposta"]);
                planilha.AgoRealizado = Convert.ToDecimal(row["Ago_realizado"]);
                planilha.SetProposta = Convert.ToDecimal(row["set_proposta"]);
                planilha.SetRealizado = Convert.ToDecimal(row["set_realizado"]);
                planilha.OutProposta = Convert.ToDecimal(row["out_proposta"]);
                planilha.OutRealizado = Convert.ToDecimal(row["out_realizado"]);
                planilha.NovProposta = Convert.ToDecimal(row["nov_proposta"]);
                planilha.NovRealizado = Convert.ToDecimal(row["nov_realizado"]);
                planilha.DezProposta = Convert.ToDecimal(row["dez_proposta"]);
                planilha.DezRealizado = Convert.ToDecimal(row["dez_realizado"]);

                lista.Add(planilha);
            }
            return lista;
        }
        public List<mdJaneiro> ListarTotal(int Ano)
        {
            var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
            foreach (DataRow row in planilhaDB.ListarTotal(Ano).Rows)
            {
                var planilha = new mdJaneiro();
                planilha.TotalPropJaneiro = Convert.ToDecimal(row["jan_propTotal"]);
                planilha.TotalRealiJaneiro = Convert.ToDecimal(row["jan_realiTotal"]);
                planilha.TotalPropFevereiro = Convert.ToDecimal(row["fev_propTotal"]);
                planilha.TotalRealiFevereiro = Convert.ToDecimal(row["fev_realiTotal"]);
                planilha.TotalPropMarco = Convert.ToDecimal(row["mar_propTotal"]);
                planilha.TotalRealiMarco = Convert.ToDecimal(row["mar_realiTotal"]);
                planilha.TotalPropAbril = Convert.ToDecimal(row["abr_propTotal"]);
                planilha.TotalRealiAbril = Convert.ToDecimal(row["abr_realiTotal"]);
                planilha.TotalPropMaio = Convert.ToDecimal(row["mai_propTotal"]);
                planilha.TotalRealiMaio = Convert.ToDecimal(row["mai_realiTotal"]);
                planilha.TotalPropJunho = Convert.ToDecimal(row["jun_propTotal"]);
                planilha.TotalRealiJunho = Convert.ToDecimal(row["jun_realiTotal"]);
                planilha.TotalPropJulho = Convert.ToDecimal(row["jul_propTotal"]);
                planilha.TotalRealiJulho = Convert.ToDecimal(row["jul_realiTotal"]);
                planilha.TotalPropAgosto = Convert.ToDecimal(row["ago_propTotal"]);
                planilha.TotalRealiAgosto = Convert.ToDecimal(row["ago_realiTotal"]);
                planilha.TotalPropSetembro = Convert.ToDecimal(row["set_propTotal"]);
                planilha.TotalRealiSetembro = Convert.ToDecimal(row["set_realiTotal"]);
                planilha.TotalPropOutubro = Convert.ToDecimal(row["out_propTotal"]);
                planilha.TotalRealiOutubro = Convert.ToDecimal(row["out_realiTotal"]);
                planilha.TotalPropNovembro = Convert.ToDecimal(row["nov_propTotal"]);
                planilha.TotalRealiNovembro = Convert.ToDecimal(row["nov_realiTotal"]);
                planilha.TotalPropDezembro = Convert.ToDecimal(row["dez_propTotal"]);
                planilha.TotalRealiDezembro = Convert.ToDecimal(row["dez_realiTotal"]);

                lista.Add(planilha);
            }
            return lista;
        }
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
                }
            }
            return lista;
        }
    }
}
