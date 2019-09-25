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
        private List<Person> personData = new List<Person>
        {
           new Person { PersonId=1, FirstName="adam", LastName="sandler", Role = Role.Admin },
           new Person { PersonId=2, FirstName="mark", LastName="ruffelo", Role = Role.Guest },
           new Person { PersonId=3, FirstName="kit", LastName="harrington", Role = Role.User }
        };

        public ActionResult Index(int? id)
        {
            Person found = null;
            if (id.HasValue)
            {
                var list = personData.Where(p => p.PersonId == id.Value);
                if (list != null && list.Count() > 0)
                {
                    found = list.First();
                }
            }
            return this.View(found);
        }
        public ActionResult CreatePerson()
        {
            return this.View(new Person());
        }
        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return this.View("Index", model);
        }
        public ActionResult AddressSummaryView(
            [Bind(Prefix ="HomeAddress", Exclude ="Country,City")]AddressSummary summary)
        {
            return View(summary);
        }
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

        //public ActionResult Addresses(IList<AddressSummary> addresses)
        //{
        //    addresses = addresses ?? new List<AddressSummary>();
        //    return View(addresses);
        //}
        //public ActionResult Addresses()
        //{           
        //    IList<AddressSummary> addresses = new List<AddressSummary>();
        //    this.UpdateModel<IList<AddressSummary>>(addresses, new FormValueProvider(this.ControllerContext));
        //    return View(addresses);
        //}
        public ActionResult Addresses(FormCollection formCollection)
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            this.UpdateModel<IList<AddressSummary>>(addresses, formCollection);
            return View(addresses);
        }
    }
}