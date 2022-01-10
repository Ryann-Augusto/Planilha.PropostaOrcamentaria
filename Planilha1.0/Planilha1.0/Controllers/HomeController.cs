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
                var valores = new mdValores();
                var cod = Convert.ToInt32(Session["Codigo"]);
                valores.Ano = Convert.ToInt32(Request["ano"]);
                if (cod == 0)
                {
                    TempData["erro"] = "Sessão encerrada";
                    Response.Redirect("/conta/login");
                }
                else if (valores.Ano == 0)
                {
                    TempData["erro"] = "Insira um Ano";
                }
                else
                {
                    valores.ExisteAno(valores.Ano, Convert.ToInt32(cod));
                    valores.NovaPlanilha(valores.Ano, Convert.ToInt32(cod));
                    TempData["sucesso"] = "Planilha Criada com Sucesso!";
                }
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
                int Ano = Convert.ToInt32(Request["ano"]);

                if (Ano == 0)
                {
                    throw new Exception("Insira um Ano!");
                }
                Session["Ano"] = Ano;
                Response.Redirect("/planilha");

                
            }
            catch(Exception ez)
            {
                Response.Redirect("/home");
                TempData["erro"] = ez.Message;
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