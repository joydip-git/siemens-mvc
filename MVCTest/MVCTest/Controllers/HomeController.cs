using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index(int? x)
        {
            return $"hello....{(x.HasValue ? x.Value : 0)}";
        }
        public ActionResult GetContent()
        {
            return this.Content("welcome to mvc");
        }
        public ActionResult GetData()
        {
            return this.View();
        }

        public ActionResult GetJsonData()
        {
            return this.Json(new { Name = "Joydip", Id = 1 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRedirected()
        {
            return this.RedirectToRoute(new { controller = "Home", action = "GetJsonData" });
        }
        public ActionResult GetRedirectedAgain()
        {
            return this.Redirect("http://localhost:50228/Home/GetJsonData");
        }
    }
}