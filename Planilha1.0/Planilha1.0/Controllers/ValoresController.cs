using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using md_Planilha;

namespace Planilha1._0.Controllers
{
    public class ValoresController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var valores = new mdValores();
            var cod = Session["Codigo"];
            var ano = Session["Ano"].ToString();
            valores.Mes = Session["Mes"].ToString();
            valores.Ano = int.Parse(ano);
            ViewBag.Mes = valores.Mes;
            ViewBag.Ano = valores.Ano;
            ViewBag.planilhaValores = new mdValores().Lista(valores.Ano, valores.Mes, Convert.ToInt32(cod));
            return View();
        }

        [Authorize]
        public ActionResult Adicionar(int id)
        {
            var valores = new mdValores();
            var cod = Session["Codigo"];
            valores.Mes = Session["Mes"].ToString();
            ViewBag.Valores = mdValores.BuscaPorId(id, valores.Mes, Convert.ToInt32(cod));
            return View();
        }
        public void Modificar(int id)
        {
            try
            {
                //Janeiro
                var valores = new mdValores();
                var cod = Session["Codigo"];
                valores.Mes = Session["Mes"].ToString();
                var plValores = mdValores.BuscaPorId(id, valores.Mes, Convert.ToInt32(cod));
                plValores.Proposta = decimal.Parse(Request["proposta"].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                plValores.Realizado = decimal.Parse(Request["realizado"].Replace(",", "."), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                plValores.Mes = Session["Mes"].ToString();
                plValores.alter(plValores.Mes, Convert.ToInt32(cod));
                TempData["sucesso"] = "Pagina alterada com sucesso";
            }
            catch(Exception err)
            {
                TempData["erro"] = "Pagina não pode alterada"+ err;
            }
            Response.Redirect("/valores");
        }
    }
}