using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ModelBindingPractice.Infrastructure;

namespace ModelBindingPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ValueProviderFactories.Factories.Insert(0, new AddressSummaryValueProviderFactory());
        }
    }
}
