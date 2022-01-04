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
            ViewBag.ano = Session["Ano"];
            var valores = new mdValores();
            var cod = Session["Codigo"];
            var ano = Session["Ano"].ToString();
            valores.Ano = int.Parse(ano);
            ViewBag.montarParteUm = new mdValores().ParteUmMontarPlanilha(valores.Ano, Convert.ToInt32(cod));
            ViewBag.montarParteDois = new mdValores().ParteDoisMontarPlanilha(valores.Ano, Convert.ToInt32(cod));
            ViewBag.primeiroTotal = new mdValores().PrimeiroTotal(valores.Ano, Convert.ToInt32(cod));
            ViewBag.segundoTotal = new mdValores().SegundoTotal(valores.Ano, Convert.ToInt32(cod));
            ViewBag.primeiroResultado = new mdValores().PrimeiroResultado(valores.Ano, Convert.ToInt32(cod));
            ViewBag.segundoResultado = new mdValores().SegundoResultado(valores.Ano, Convert.ToInt32(cod));
            ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(valores.Ano, Convert.ToInt32(cod));
            ViewBag.sobre = new mdResultado().sobreFaturamento(valores.Ano, Convert.ToInt32(cod));
            ViewBag.propResultado = mdResultado.TotalPropResultados(valores.Ano, Convert.ToInt32(cod));
            ViewBag.realiResultado = mdResultado.TotalRealiResultados(valores.Ano, Convert.ToInt32(cod));
            ViewBag.totalSobre = mdResultado.TotalSobreFaturamento(valores.Ano, Convert.ToInt32(cod));
            ViewBag.despesas = new mdResultado().contribDespesas(valores.Ano, Convert.ToInt32(cod));
            ViewBag.totaldespesas = mdResultado.TotalContribDespesas(valores.Ano, Convert.ToInt32(cod));
            ViewBag.propostaTabResultado = mdResultado.PropostaTabResultado(valores.Ano, Convert.ToInt32(cod));
            ViewBag.realizadoTabResultado = mdResultado.RealizadoTabResultado(valores.Ano, Convert.ToInt32(cod));
            ViewBag.metaProposta = mdResultado.MetaProposta(valores.Ano, Convert.ToInt32(cod));
            ViewBag.metaRealizada = mdResultado.MetaRealizada(valores.Ano, Convert.ToInt32(cod));

            return View();
        }

        [Authorize]
        public ActionResult Impressao()
        {
            try
            {
                ViewBag.usuario = Session["Usuario"];
                ViewBag.ano = Session["Ano"];
                var valores = new mdValores();
                var cod = Session["Codigo"];
                var ano = Session["Ano"].ToString();
                valores.Ano = int.Parse(ano);
                ViewBag.montarParteUm = new mdValores().ParteUmMontarPlanilha(valores.Ano, Convert.ToInt32(cod));
                ViewBag.montarParteDois = new mdValores().ParteDoisMontarPlanilha(valores.Ano, Convert.ToInt32(cod));
                ViewBag.primeiroTotal = new mdValores().PrimeiroTotal(valores.Ano, Convert.ToInt32(cod));
                ViewBag.segundoTotal = new mdValores().SegundoTotal(valores.Ano, Convert.ToInt32(cod));
                ViewBag.FaturamentoResult = new mdResultado().Listarfaturamento(valores.Ano, Convert.ToInt32(cod));
                ViewBag.primeiroResultado = new mdValores().PrimeiroResultado(valores.Ano, Convert.ToInt32(cod));
                ViewBag.segundoResultado = new mdValores().SegundoResultado(valores.Ano, Convert.ToInt32(cod));
                ViewBag.sobre = new mdResultado().sobreFaturamento(valores.Ano, Convert.ToInt32(cod));
                ViewBag.totalSobre = mdResultado.TotalSobreFaturamento(valores.Ano, Convert.ToInt32(cod));
                ViewBag.despesas = new mdResultado().contribDespesas(valores.Ano, Convert.ToInt32(cod));
                ViewBag.totaldespesas = mdResultado.TotalContribDespesas(valores.Ano, Convert.ToInt32(cod));
                ViewBag.propResultado = mdResultado.TotalPropResultados(valores.Ano, Convert.ToInt32(cod));
                ViewBag.realiResultado = mdResultado.TotalRealiResultados(valores.Ano, Convert.ToInt32(cod));
                ViewBag.propostaTabResultado = mdResultado.PropostaTabResultado(valores.Ano, Convert.ToInt32(cod));
                ViewBag.realizadoTabResultado = mdResultado.RealizadoTabResultado(valores.Ano, Convert.ToInt32(cod));
                ViewBag.metaProposta = mdResultado.MetaProposta(valores.Ano, Convert.ToInt32(cod));
                ViewBag.metaRealizada = mdResultado.MetaRealizada(valores.Ano, Convert.ToInt32(cod));
                return View();
            }
            catch (Exception ez)
            {
                TempData["erro"] = ez.Message;
                Response.Redirect("/planilha");
                return View();
            }
        }

        [Authorize]
        public ActionResult Graficos()
        {
            ViewBag.usuario = Session["Usuario"];
            ViewBag.ano = Session["Ano"];
            var valores = new mdValores();
            var cod = Session["Codigo"];
            var ano = Session["Ano"].ToString();
            valores.Ano = int.Parse(ano);

            var proposta = new List<decimal>();
            var realizado = new List<decimal>();

            foreach (var GrafDb in new mdGraficos().MontarGraficos(valores.Ano, Convert.ToInt32(cod)))
            {
                var Prop = GrafDb.Proposta;
                var Reali = GrafDb.Realizado;
                proposta.Add(Prop);
                realizado.Add(Reali);
            }
            ViewBag.Prop = proposta;
            ViewBag.Reali = realizado;
            return View();
        }
    }
}
