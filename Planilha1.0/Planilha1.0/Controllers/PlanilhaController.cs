using md_Planilha;
using Planilha1._0.Models;
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
                ViewBag.usuario = Session["Usuario"];
                var janeiro = new mdJaneiro();
                var cod = Session["Codigo"];
                var ano = Session["Ano"].ToString();
                janeiro.Ano = int.Parse(ano);
                ViewBag.planilhaGeral = new mdJaneiro().ListarTodos(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.valorTotal = new mdJaneiro().ListarTotal(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.sobre = new mdResultado().sobreFaturamento(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.propResultado = mdResultado.TotalPropResultados(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.realiResultado = mdResultado.TotalRealiResultados(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.totalSobre = mdResultado.TotalSobreFaturamento(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.despesas = new mdResultado().contribDespesas(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.totaldespesas = mdResultado.TotalContribDespesas(janeiro.Ano, Convert.ToInt32(cod));
                ViewBag.realizadoTotal = new mdJaneiro().ListarTotalRealizado(janeiro.Ano, Convert.ToInt32(cod));
                return View();
            
        }

        [Authorize]
        public ActionResult Impressao()
        {
            var janeiro = new mdJaneiro();
            var cod = Session["Codigo"];
            var ano = Session["Ano"].ToString();
            janeiro.Ano = int.Parse(ano);
            ViewBag.planilhaGeral = new mdJaneiro().ListarTodos(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.valorTotal = new mdJaneiro().ListarTotal(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.sobre = new mdResultado().sobreFaturamento(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.propResultado = mdResultado.TotalPropResultados(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.realiResultado = mdResultado.TotalRealiResultados(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.totalSobre = mdResultado.TotalSobreFaturamento(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.despesas = new mdResultado().contribDespesas(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.totaldespesas = mdResultado.TotalContribDespesas(janeiro.Ano, Convert.ToInt32(cod));
            ViewBag.realizadoTotal = new mdJaneiro().ListarTotalRealizado(janeiro.Ano, Convert.ToInt32(cod));
            return View();
        }
    }
}
