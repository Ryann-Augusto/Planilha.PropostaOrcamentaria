using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Planilha1._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "valores",
                "valores",
                new { controller = "Valores", action = "Index" }
            );

            routes.MapRoute(
                "valores_alterar",
                "valores/{id}/alterar",
                new { controller = "Valores", action = "Alterar", id = 0}
            );

            routes.MapRoute(
                "valores_modificar",
                "valores/{id}/modificar",
                new { controller = "Valores", action = "Modificar", id = 0 }
            );

            routes.MapRoute(
                "valores_categoria",
                "valores/categoria",
                new { controller = "Valores", action = "Categoria" }
            );

            routes.MapRoute(
                "valores_alterarcategoria",
                "valores/{id}/alterarcategoria",
                new { controller = "Valores", action = "AlterarCategoria", id = 0 }
            );

            routes.MapRoute(
                "valores_modificarcategoria",
                "valores/{id}/modificarCategoria",
                new { controller = "Valores", action = "ModificarCategoria", id = 0 }
            );

            routes.MapRoute(
                "valores_adicionarcategoria",
                "valores/adicionarcategoria",
                new { controller = "Valores", action = "AdicionarCategoria" }
            );

            routes.MapRoute(
                "home_criar",
                "home/criar",
                new { controller = "Home", action = "Criar" }
            );          

            routes.MapRoute(
                "home_criarplanilha",
                "home/criarplanilha",
                new { controller = "Home", action = "CriarPlanilha" }
            );

            routes.MapRoute(
                "home_abrirplanilha",
                "home/abrirplanilha",
                new { controller = "Home", action = "AbrirPlanilha" }
            );

            routes.MapRoute(
                "planilha",
                "planilha",
                new { controller = "Planilha", action = "Index" }
            );

            routes.MapRoute(
                "planilha_impressao",
                "impressao",
                new { controller = "Planilha", action = "Impressao"}
                );

            routes.MapRoute(
                "planilha_graficos",
                "graficos",
                new { controller = "Planilha", action = "Graficos" }
                );

            routes.MapRoute(
                "conta_cadastrar",
                "cadastrar",
                new { controller = "Conta", action = "Cadastrar" }
                );

            routes.MapRoute(
                "conta_cadastro",
                "cadastro",
                new { controller = "Conta", action = "Cadastro" }
                );

            routes.MapRoute(
                "conta_editar",
                "conta/{id}/editar",
                new { controller = "Conta", action = "Editar", id = 0 }
                );

            routes.MapRoute(
                "conta_alterar",
                "conta/{id}/alterar",
                new { controller = "Conta", action = "Alterar", id = 0 }
                );

            routes.MapRoute(
                "conta_apagar",
                "conta/{id}/apagar",
                new { controller = "Conta", action = "Apagar", id = 0 }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
