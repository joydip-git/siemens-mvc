using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ModelBindingPractice.Infrastructure;
using ModelBindingPractice.Models;

namespace ModelBindingPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ValueProviderFactories.Factories.Insert(0, new AddressSummaryValueProviderFactory());
            ModelBinders.Binders.Add(
                typeof(Employee),
                new EmployeeModelBinder());
            ModelBinders.Binders.Add(
                typeof(AddressSummary),
                new AddressSummaryModelBinder());
        }
    }
    /*
    public class MyHandler : IHttpHandler
    {
        public bool IsReusable => throw new NotImplementedException();

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
    */
}
