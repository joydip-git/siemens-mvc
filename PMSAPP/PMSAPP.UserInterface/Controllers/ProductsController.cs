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
        private readonly IDataFetcher<Product> dataFetcher;
        public ProductsController(IDataFetcher<Product> dataFetcher)
        {
            this.dataFetcher = dataFetcher;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ShowProducts()
        {
            try
            {
                var products = dataFetcher.GetAllRecords();
                return this.View(new ShowProductsViewModel
                {
                    FilterText = "",
                    Products = products,
                    Properties =
                    GetProductProperties()
                });
            }
            catch (Exception ex)
            {
                return this.View(new ShowProductsViewModel
                {
                    FilterText = "",
                    Properties =
                    GetProductProperties()
                });
            }
        }

        private static List<string> GetProductProperties()
        {
            return typeof(Product)
                                .GetProperties()
                                .Select(pi => pi.Name)
                                .ToList<string>();
        }

        [HttpPost]
        public ViewResult ShowProducts(
           [Bind(Exclude = "Products")] ShowProductsViewModel vm)
        {
            //IEnumerable<Product> products = null;
            if (!string.IsNullOrEmpty(vm.FilterText))
            {
                vm.Products =
                    dataFetcher
                    .GetAllRecords()
                    .Where(p =>
                    p.ProductName.Contains(vm.FilterText));
            }
            return this.View(vm);
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
            try
            {
                if (ModelState.IsValid)
                {
                    var status = dataFetcher.AddData(product);
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }

        public ViewResult GetProduct()
        {
            return this.View(new Product { ProductName = "NA", ProductId = 0, CategoryId = 0, Description = "NA", Price = 0 });
        }

        public ActionResult DeleteProduct(int? id)
        {
            return this.RedirectToAction("ShowProducts");
        }
        public ActionResult UpdateProduct(int? id)
        {
            return this.RedirectToAction("ShowProducts");
        }
    }
}