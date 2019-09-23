using PMSAPP.Entities;
using PMSAPP.UserInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSAPP.UserInterface.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ShowProducts()
        {
            //this.ViewBag.Data = "all products";
            this.ViewData["Data"] = new DataFetcher().GetAllRecords();
            return this.View();
        }
        [HttpGet]
        public ViewResult AddProduct()
        {
            return this.View();
        }
        [HttpPost]
        //public ViewResult AddProduct(FormCollection formCollection)
        public ViewResult AddProduct(Product product)
        {
            return this.View();
        }

        public ViewResult GetProduct()
        {
            return this.View(new Product { ProductName = "NA", ProductId = 0, CategoryId = 0, Description = "NA", Price = 0 });
        }
    }
}