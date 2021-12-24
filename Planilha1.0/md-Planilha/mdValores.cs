using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md_Planilha
{
    public class mdValores : mdModelo
    {
        List<mdValores> lista = new List<mdValores>();

        public List<mdValores> Lista(int ano, string mes, int Cod)
        {
            try
            {
                var lista = new List<mdValores>();
                var planilhaDB = new Dal_Planilha.ValoresDal();
                foreach (DataRow row in planilhaDB.Lista(ano, mes, Cod).Rows)
                {
                    var planilha = new mdValores();
                    planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                    planilha.Categoria = Convert.ToString(row["pl_categoria"]);
                    planilha.Proposta = Convert.ToDecimal(row["pl_proposta"]);
                    planilha.Realizado = Convert.ToDecimal(row["pl_realizado"]);

                    lista.Add(planilha);
                }
                return lista;

            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }

        public static mdValores BuscaPorId(int Codigo, string Mes, int Cod)
        {
            try
            {
                var planilha = new mdValores();
                var planilhaDB = new Dal_Planilha.ValoresDal();

                foreach (DataRow row in planilhaDB.BuscaPorId(Codigo, Mes, Cod).Rows)
                {
                    planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                    planilha.Categoria = Convert.ToString(row["pl_categoria"]);
                    planilha.Proposta = Convert.ToDecimal(row["pl_proposta"]);
                    planilha.Realizado = Convert.ToDecimal(row["pl_realizado"]);
                }
                return planilha;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }


        public void alter(string mes, int Cod)
        {
            try
            {
                new Dal_Planilha.ValoresDal().Alterar(this.Codigo, this.Proposta, this.Realizado, mes, Cod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NovaPlanilha(int Ano, int Cod)
        {
            try
            {
                new Dal_Planilha.CriarPlanilhaDal().NovaPlanilha(Ano, Cod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void ExisteAno(int Ano, int Cod)
        {
            try
            {
                new Dal_Planilha.CriarPlanilhaDal().ExisteAno(Ano, Cod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<mdValores> ListarTodos(int Ano, int Cod)
        {
            try
            {
                var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                foreach (DataRow row in planilhaDB.MontarPlanilha(Ano, Cod).Rows)
                {
                    var planilha = new mdValores();
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
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }
        public List<mdValores> ListarTotal(int Ano, int Cod)
        {
            try
            {
                string[] meses = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho", "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
                foreach (string Mes in meses)
                {

                    var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                    foreach (DataRow row in planilhaDB.ListarTotal(Ano, Cod, Mes).Rows)
                    {
                        var planilha = new mdValores();
                        planilha.TotalProposta = Convert.ToDecimal(row["jan_propTotal"]);
                        planilha.TotalRealizado = Convert.ToDecimal(row["jan_realiTotal"]);
                        lista.Add(planilha);

                        new Dal_Planilha.CriarPlanilhaDal().AlterarTotalPropReali(Ano, Cod, Mes, planilha.TotalProposta, planilha.TotalRealizado);
                    }
                }
                return lista;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }
        public List<mdValores> ListarTotalResultado(int Ano, int Cod)
        {
            try
            {
                string[] meses = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho", "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
                foreach (string Mes in meses)
                {

                    var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
                    foreach (DataRow row in planilhaDB.ListarTotalResultado(Ano, Cod, Mes).Rows)
                    {
                        var planilha = new mdValores();
                        planilha.TotalPropResultado = Convert.ToDecimal(row["totalProp_result"]);
                        planilha.TotalRealiResultado = Convert.ToDecimal(row["totalReali_result"]);
                        lista.Add(planilha);
                    }
                }
                return lista;
            }
            catch (Exception ez)
            {
                ez = new Exception("Não hà informações suficiente para montar a planilha!");
                throw new Exception(ez.Message);
            }
        }
    }
}