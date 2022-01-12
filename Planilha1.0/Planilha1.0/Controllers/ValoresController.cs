using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using md_Planilha;
using Planilha1._0.Models;

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
        public ActionResult Alterar(int id)
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
                plValores.alterValues(plValores.Mes, Convert.ToInt32(cod));
                TempData["sucesso"] = "Valores alterados com sucesso";
            }
            catch
            {
                TempData["erro"] = "Os valores não foram alterados";
            }
            Response.Redirect("/valores");
        }
        public ActionResult Categoria()
        {
            var valores = new mdValores();
            var cod = Session["Codigo"];
            ViewBag.categoria = valores.ListarCategorias(Convert.ToInt32(cod));
            return View();
        }

        public ActionResult AlterarCategoria(int id)
        {
            var cod = Session["Codigo"];
            ViewBag.alterarCategoria = mdValores.BuscaCategoriaPorId(id, Convert.ToInt32(cod));
            return View();
        }

        public void ModificarCategoria(int id)
        {
            try
            {
                var categoria = Request["categoria"].ToString();
                var cod = Session["Codigo"];
                var valores = new mdValores();

                if (categoria.Trim().Length == 0)
                {
                    TempData["erro"] = "Insira um valor para a categoria";
                }
                else
                {
                    valores.alterCategory(id, categoria, Convert.ToInt32(cod));
                    TempData["sucesso"] = "Categoria alterada com sucesso";
                }
            }
            catch
            {
                TempData["erro"] = "Categoria não foi alterada";
            }
            Response.Redirect("/valores/categoria");
        }

        public void AdicionarCategoria()
        {
            try
            {
                var valores = new mdValores();
                var cod = Session["Codigo"];
                var categoria = Request["categoria"];

                if (categoria.Trim().Length == 0)
                {
                    TempData["erro"] = "Insira um valor para a categoria";
                }
                else
                {
                    valores.AdicionarCategoria(Convert.ToInt32(cod), categoria);
                    var CodigoCategoria = mdValores.CodigoCategoria(Convert.ToInt32(cod), categoria);

                    int[] Anos = { 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028 };
                    foreach (var Ano in Anos)
                    {
                        var achou = new ValidaCategoria().ProcurarCategoria(Convert.ToInt32(cod), Ano);
                        if (achou)
                        {
                            valores.AdicionarCategoriaNaPlanilha(Ano, Convert.ToInt32(cod), CodigoCategoria.Codigo);
                        }
                    }
                    TempData["sucesso"] = "Categoria adicionada com sucesso";
                }
            }
            catch
            {
                TempData["erro"] = "Categoria não foi adicionada";
            }

            Response.Redirect("/valores/categoria");
        }

        public void ExcluirCategoria(int id)
        {
            try
            {
                var cod = Convert.ToInt32(Session["Codigo"]);
                var valores = new mdValores();
                valores.ExcluirCategoria(cod, id);
                TempData["sucesso"] = "Categoria excluida!!";
            }
            catch (Exception err)
            {
                TempData["erro"] = "Categoria não pode ser excluida" + err;
            }
            Response.Redirect("/valores/categoria");
        }
    }
}