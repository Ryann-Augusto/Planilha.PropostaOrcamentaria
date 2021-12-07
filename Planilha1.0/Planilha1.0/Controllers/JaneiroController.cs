using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using md_Planilha;

namespace Planilha1._0.Controllers
{
    public class JaneiroController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var janeiro = new mdJaneiro();
            var ano = Request.Cookies["Ano"]["Name"].ToString();
            janeiro.Mes = Request.Cookies["Mes"]["Name"].ToString();
            janeiro.Ano = int.Parse(ano);
            ViewBag.Mes = janeiro.Mes;
            ViewBag.Ano = janeiro.Ano;
            ViewBag.planilhaJaneiro = new mdJaneiro().Lista(janeiro.Ano, janeiro.Mes);
            return View();
        }

        [Authorize]
        public ActionResult Adicionar(int id)
        {
            var janeiros = new mdJaneiro();
            janeiros.Mes = Request.Cookies["Mes"]["Name"].ToString();
            ViewBag.Janeiro = mdJaneiro.BuscaPorId(id, janeiros.Mes);
            return View();
        }
        public void Modificar(int id)
        {
            try
            {
                //Janeiro
                var janeiros = new mdJaneiro();
                janeiros.Mes = Request.Cookies["Mes"]["Name"].ToString();
                var plJaneiro = mdJaneiro.BuscaPorId(id, janeiros.Mes);
                plJaneiro.Proposta = decimal.Parse(Request["proposta"].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                plJaneiro.Realizado = decimal.Parse(Request["realizado"].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                plJaneiro.Mes = Request.Cookies["Mes"]["Name"].ToString();
                plJaneiro.alter(plJaneiro.Mes);
                TempData["sucesso"] = "Pagina alterada com sucesso";
            }
            catch(Exception err)
            {
                TempData["erro"] = "Pagina não pode alterada"+ err;
            }
            Response.Redirect("/janeiro");
        }
    }
}