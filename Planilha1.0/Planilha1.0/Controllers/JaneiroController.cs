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
            var cod = Session["Codigo"];
            var ano = Session["Ano"].ToString();
            janeiro.Mes = Session["Mes"].ToString();
            janeiro.Ano = int.Parse(ano);
            ViewBag.usuario = Session["Usuario"];
            ViewBag.Mes = janeiro.Mes;
            ViewBag.Ano = janeiro.Ano;
            ViewBag.planilhaJaneiro = new mdJaneiro().Lista(janeiro.Ano, janeiro.Mes, Convert.ToInt32(cod));
            return View();
        }

        [Authorize]
        public ActionResult Adicionar(int id)
        {
            var janeiros = new mdJaneiro();
            var cod = Session["Codigo"];
            janeiros.Mes = Session["Mes"].ToString();
            ViewBag.Janeiro = mdJaneiro.BuscaPorId(id, janeiros.Mes, Convert.ToInt32(cod));
            return View();
        }
        public void Modificar(int id)
        {
            try
            {
                //Janeiro
                var janeiros = new mdJaneiro();
                var cod = Session["Codigo"];
                janeiros.Mes = Session["Mes"].ToString();
                var plJaneiro = mdJaneiro.BuscaPorId(id, janeiros.Mes, Convert.ToInt32(cod));
                plJaneiro.Proposta = decimal.Parse(Request["proposta"].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                plJaneiro.Realizado = decimal.Parse(Request["realizado"].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                plJaneiro.Mes = Session["Mes"].ToString();
                plJaneiro.alter(plJaneiro.Mes, Convert.ToInt32(cod));
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