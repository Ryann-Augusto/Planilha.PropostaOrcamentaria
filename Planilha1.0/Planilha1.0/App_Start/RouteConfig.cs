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
                "janeiro",
                "janeiro",
                new { controller = "janeiro", action = "Index" }
            );

            routes.MapRoute(
                "janeiro_adicionar",
                "janeiro/{id}/adicionar",
                new { controller = "Janeiro", action = "Adicionar", id = 0}
            );

            routes.MapRoute(
                "janeiro_modificar",
                "janeiro/{id}/modificar",
                new { controller = "Janeiro", action = "Modificar", id = 0 }
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
