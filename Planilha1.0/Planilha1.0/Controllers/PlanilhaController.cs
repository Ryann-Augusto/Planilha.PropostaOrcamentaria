using md_Planilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planilha1._0.Controllers
{
    public class PlanilhaController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {

                var janeiro = new mdJaneiro();
                var ano = Request.Cookies["Ano"]["Abrir"].ToString();
                janeiro.Ano = int.Parse(ano);
                ViewBag.planilhaGeral = new mdJaneiro().ListarTodos(janeiro.Ano);
                ViewBag.valorTotal = new mdJaneiro().ListarTotal(janeiro.Ano);
                ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(janeiro.Ano);
                ViewBag.sobre = new mdResultado().sobreFaturamento(janeiro.Ano);
                ViewBag.propResultado = mdResultado.TotalPropResultados(janeiro.Ano);
                ViewBag.realiResultado = mdResultado.TotalRealiResultados(janeiro.Ano);
                ViewBag.totalSobre = mdResultado.TotalSobreFaturamento(janeiro.Ano);
                ViewBag.despesas = new mdResultado().contribDespesas(janeiro.Ano);
                ViewBag.totaldespesas = mdResultado.TotalContribDespesas(janeiro.Ano);
                ViewBag.realizadoTotal = new mdJaneiro().ListarTotalRealizado(janeiro.Ano);
                return View();
            
        }

        [Authorize]
        public ActionResult Impressao()
        {
            var janeiro = new mdJaneiro();
            var ano = Request.Cookies["Ano"]["Abrir"].ToString();
            janeiro.Ano = int.Parse(ano);
            ViewBag.planilhaGeral = new mdJaneiro().ListarTodos(janeiro.Ano);
            ViewBag.valorTotal = new mdJaneiro().ListarTotal(janeiro.Ano);
            ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(janeiro.Ano);
            return View();
        }
    }
}
