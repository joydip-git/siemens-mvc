using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationPractice.Models;

namespace ValidationPractice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }
        [HttpPost]
        public ActionResult MakeBooking(Appointment appointment)
        {
            if (string.IsNullOrEmpty(appointment.ClientName))
            {
                this.ModelState.AddModelError(nameof(appointment.ClientName), "Please enter your name");
            }
            if (ModelState.IsValidField(nameof(appointment.Date)) && DateTime.Now > appointment.Date)
            {
                ModelState.AddModelError(nameof(appointment.Date), "Please enter a future date");
            }
            if (!appointment.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appointment.TermsAccepted), "You must accept the terms");
            }

            if (ModelState.IsValid)
                return View("Completed", appointment);
            else
                return View(appointment);
        }
    }
}