using md_Planilha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Planilha1._0.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            Session["Ano"] = Convert.ToString(Request["ano"]);
            Session["Mes"] = Convert.ToString(Request["mes"]);
            
            if (Convert.ToString(Session["Ano"]) == "vazio" || Convert.ToString(Session["Mes"]) == "vazio")
            {
                TempData["erro"] = "Insira o Valor do Mês e Ano";
                Response.Redirect("/home");
            }
            else
            {
            Response.Redirect("/valores");
            }
        }

        [HttpPost]
        public void CriarPlanilha()
        {
            try
            {
                var janeiro = new mdJaneiro();
                var cod = Session["Codigo"];
                janeiro.Ano = Convert.ToInt32(Request["ano"]);
                janeiro.ExisteAno(janeiro.Ano, Convert.ToInt32(cod));
                janeiro.NovaPlanilha(janeiro.Ano, Convert.ToInt32(cod));
                TempData["sucesso"] = "Planilha Criada com Sucesso!";
            }
            catch(Exception ex)
            {
                TempData["erro"] = ex.Message;
            }
            Response.Redirect("/home");
        }

        [HttpPost]
        public void AbrirPlanilha()
        {
            try
            {
                var janeiro = new mdJaneiro();
                Session["Ano"] = Convert.ToString(Request["ano"]);
                Response.Redirect("/planilha");
            }
            catch
            {
                Response.Redirect("/home");
            }
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}