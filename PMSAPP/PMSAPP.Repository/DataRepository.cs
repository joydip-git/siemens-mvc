//using PMSAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAPP.Repository
{
    /*
    public static class DataRepository
    {
        static HashSet<Category> categories;
        static HashSet<Product> products;

        static DataRepository()
        {
            categories = new HashSet<Category>
            {
                new Category { CategoryId = 2, CategoryName = "Mobiles" },
                new Category { CategoryId = 1, CategoryName = "Laptops" },
                new Category { CategoryId = 3, CategoryName = "Books" },
            };
            products = new HashSet<Product>
            {
                new Product { ProductId = 102, ProductName = "dell xps", Description="new laptop from dell", Price=67000, CategoryInfo = categories.Where(c=>c.CategoryId==1).First()},
                 new Product { ProductId = 101, ProductName = "one plus 7", Description="new mobile from one plus", Price=34000, CategoryInfo = categories.Where(c=>c.CategoryId==2).First()},
                  new Product { ProductId = 100, ProductName = "the alchemist", Description="new book from paul coelho", Price=699, CategoryInfo = categories.Where(c=>c.CategoryId==3).First()}
            };
        }
        public static IEnumerable<Category> GetCategories()
        {
            return categories;
        }
        public static IEnumerable<Product> GetProducts()
        {
            return products;
        }

    }
    */
}
