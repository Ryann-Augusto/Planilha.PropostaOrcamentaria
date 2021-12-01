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
        // GET: Planilha
        public ActionResult Index()
        {
            try
            {
                var janeiro = new mdJaneiro();
                var ano = Request.Cookies["Ano"]["Abrir"].ToString();
                janeiro.Ano = int.Parse(ano);
                ViewBag.planilhaGeral = new mdJaneiro().ListarTodos(janeiro.Ano);
                ViewBag.valorTotal = new mdJaneiro().ListarTotal(janeiro.Ano);
                ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(janeiro.Ano);
                ViewBag.sobre = mdResultado.sobreFaturamento(janeiro.Ano);
            }
            catch
            {
                Response.Redirect("/home");
                return View();
            }
            return View();
        }

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
