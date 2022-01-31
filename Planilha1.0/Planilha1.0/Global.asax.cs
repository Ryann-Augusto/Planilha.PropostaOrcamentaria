using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Planilha1._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null && cookie.Value != string.Empty)
            {
                FormsAuthenticationTicket ticket;
                try
                {
                    ticket = FormsAuthentication.Decrypt(cookie.Value);
                }
                catch
                {
                    return;
                }

                var perfis = ticket.UserData.Split(';');

                if (Context.User != null)
                {
                    Context.User = new GenericPrincipal(Context.User.Identity, perfis);
                }
            }
        }
    }
}
