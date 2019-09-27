using PMSAPP.Entities;
using PMSAPP.UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSAPP.UserInterface.Controllers
{
    public class ProductAsyncController : Controller
    {
        //new DI for async class objects
        private readonly IDataFetcherAsync<Product> dataFetcher;
        public ProductAsyncController(IDataFetcherAsync<Product> dataFetcher)
        {
            this.dataFetcher = dataFetcher;
        }
        // GET: ProductAsync
        public ActionResult Index()
        {
            return View();
        }
    }
}