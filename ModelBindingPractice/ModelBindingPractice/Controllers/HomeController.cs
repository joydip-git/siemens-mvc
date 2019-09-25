using ModelBindingPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingPractice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult ShowNames(IList<string> names)
        public ActionResult ShowNames(string[] names)
        {

            //this.Request.Form[""]
            //this.RouteData.Values[]
            //this.Request.QueryString[]
            //this.Request.Files
            //names = names ?? new List<string>();
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult Addresses(IList<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();
            return View(addresses);
        }
    }
}