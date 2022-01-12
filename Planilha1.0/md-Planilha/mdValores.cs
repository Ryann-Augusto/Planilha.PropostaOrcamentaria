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
        List<mdValores> listarCat = new List<mdValores>();

        public List<mdValores> Lista(int ano, string mes, int Cod)
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

        public static mdValores CodigoCategoria(int Cod, string Cat)
        {
            var planilha = new mdValores();
            var planilhaDB = new Dal_Planilha.ValoresDal();
            foreach (DataRow row in planilhaDB.CodigoCategoria(Cod, Cat).Rows)
            {
                planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
            }
            return planilha;
        }

        public static mdValores BuscaPorId(int Codigo, string Mes, int Cod)
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

        public static mdValores BuscaCategoriaPorId(int Codigo, int Cod)
        {
            var planilha = new mdValores();
            var planilhaDB = new Dal_Planilha.ValoresDal();

            foreach (DataRow row in planilhaDB.BuscaCategoriaPorId(Codigo, Cod).Rows)
            {
                planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                planilha.Categoria = Convert.ToString(row["pl_categoria"]);
            }
            return planilha;
        }

        public List<mdValores> ListarCategorias(int Cod)
        {
            var lista = new List<mdValores>();
            var planilhaDB = new Dal_Planilha.ValoresDal();
            foreach (DataRow row in planilhaDB.ListaCategorias(Cod).Rows)
            {
                var planilha = new mdValores();
                planilha.Codigo = Convert.ToInt32((row["pl_codigo"]));
                planilha.Categoria = (row["pl_categoria"]).ToString();
                lista.Add(planilha);
            }
            return lista;
        }

        public void alterValues(string mes, int Cod)
        {
            new Dal_Planilha.ValoresDal().AlterarValores(this.Codigo, this.Proposta, this.Realizado, mes, Cod);
        }

        public void alterCategory(int id, string Categoria, int Cod)
        {
            new Dal_Planilha.ValoresDal().AlterarCategoria(id, Categoria, Cod);
        }

        public void NovaPlanilha(int Ano, int Cod)
        {
            var planilhaDB2 = new Dal_Planilha.ValoresDal();
            foreach (DataRow row in planilhaDB2.CodigoDeTodasCategorias(Cod).Rows)
            {
                var planilha = new mdValores();
                planilha.Codigo = Convert.ToInt32(row["pl_codigo"]);
                listarCat.Add(planilha);
            }

            foreach (var Cat in listarCat.ToArray())
            {
                new Dal_Planilha.CriarPlanilhaDal().NovaPlanilha(Ano, Cod, Cat.Codigo);
            }
            new Dal_Planilha.CriarPlanilhaDal().TotalMesesPlanilha(Ano, Cod);
        }

        public void ExcluirPlanilha(int Cod, int Ano)
        {
            new Dal_Planilha.CriarPlanilhaDal().ExcluirPlanilha(Cod, Ano);
        }

        public void AdicionarCategoriaNaPlanilha(int Ano, int Cod, int Cat)
        {
            new Dal_Planilha.CriarPlanilhaDal().NovaPlanilha(Ano, Cod, Cat);
        }

        public void AdicionarCategoria(int Cod, string Categoria)
        {
            new Dal_Planilha.ValoresDal().AdicionarCategoria(Cod, Categoria);
        }

        public void ExcluirCategoria(int Cod, int Id)
        {
            new Dal_Planilha.CriarPlanilhaDal().ExcluirCategoria(Cod, Id);
        }

        public void ExisteAno(int Ano, int Cod)
        {
            new Dal_Planilha.CriarPlanilhaDal().ExisteAno(Ano, Cod);
        }

        public List<mdValores> ParteUmMontarPlanilha(int Ano, int Cod)
        {

            var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
            foreach (DataRow row in planilhaDB.MontarPlanilhaParteUm(Ano, Cod).Rows)
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

                lista.Add(planilha);
            }
            return lista;
        }

        public List<mdValores> ParteDoisMontarPlanilha(int Ano, int Cod)
        {

            var planilhaDB = new Dal_Planilha.CriarPlanilhaDal();
            foreach (DataRow row in planilhaDB.MontarPlanilhaParteDois(Ano, Cod).Rows)
            {
                var planilha = new mdValores();
                planilha.Categoria = Convert.ToString(row["categoria"]);
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

        public List<mdValores> ListarTotalResultado(int Ano, int Cod)
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

        public List<mdValores> PrimeiroTotal(int Ano, int Cod)
        {
            string[] meses = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho" };
            foreach (string Mes in meses)
            {
                try
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
                catch
                {
                    throw new Exception("Não hà informações suficiente para montar a planilha!");
                }
            }
            return lista;
        }

        public List<mdValores> SegundoTotal(int Ano, int Cod)
        {
            string[] meses = { "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
            foreach (string Mes in meses)
            {

                try
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
                catch
                {
                    throw new Exception("Não hà informações suficiente para montar a planilha!");
                }
            }
            return lista;
        }

        public List<mdValores> PrimeiroResultado(int Ano, int Cod)
        {
            string[] meses = { "tbl_janeiro", "tbl_fevereiro", "tbl_marco", "tbl_abril", "tbl_maio", "tbl_junho" };
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

        public List<mdValores> SegundoResultado(int Ano, int Cod)
        {
            string[] meses = { "tbl_julho", "tbl_agosto", "tbl_setembro", "tbl_outubro", "tbl_novembro", "tbl_dezembro" };
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
    }
}