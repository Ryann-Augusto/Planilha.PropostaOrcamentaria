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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            Response.Cookies["Ano"]["Name"] = Convert.ToString(Request["ano"]);
            Response.Cookies["Mes"]["Name"] = Convert.ToString(Request["mes"]);
            
            if (Response.Cookies["Ano"]["Name"] == "vazio" || Response.Cookies["Mes"]["Name"] == "vazio")
            {
                TempData["erro"] = "Insira o Valor do Mês e Ano";
                Response.Redirect("/home");
            }
            else
            {
            Response.Redirect("/janeiro");
            }
        }

        [HttpPost]
        public void CriarPlanilha()
        {
            try
            {
                var janeiro = new mdJaneiro();
                janeiro.Ano = Convert.ToInt32(Request["ano"]);
                janeiro.ExisteAno(janeiro.Ano);
                janeiro.NovaPlanilha(janeiro.Ano);
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
            var janeiro = new mdJaneiro();
            Response.Cookies["Ano"]["Abrir"] = Convert.ToString(Request["ano"]);
            Response.Redirect("/planilha");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}