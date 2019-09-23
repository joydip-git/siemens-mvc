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

        [HttpGet]
        public ViewResult ShowProducts()
        {
            return this.View();
        }
        [HttpPost]
        //public ViewResult ShowProducts(string productName)
        public ViewResult ShowProducts(ShowProductsViewModel vm)
        {
            IEnumerable<Product> products = null;
            if (vm.SearchText != null)
            {
                products = new DataFetcher()
                    .GetAllRecords()
                    .Where(p => p.ProductName.Contains(vm.SearchText));
            }

            if (products != null && products.Count() > 0)
            {
                //this.ViewBag.Count = products.Count();
                //return this.View(products);
                vm.Products = products;
                return this.View(vm);
            }
            else
            {
                //this.ViewBag.ErrorMessage = "No products found";
                return this.View(vm);
            }
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