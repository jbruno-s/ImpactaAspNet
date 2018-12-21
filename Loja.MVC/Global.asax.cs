using Loja.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Loja.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_AcquireRequestState()
        {
            var cultura = CultureHelper.ObterCultureInfo();

            Thread.CurrentThread.CurrentCulture = cultura; //datas, moedas
            Thread.CurrentThread.CurrentUICulture = cultura;//habilita a usar os arquivos resx
        }
    }
}
