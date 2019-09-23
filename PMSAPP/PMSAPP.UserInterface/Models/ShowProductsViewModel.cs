using PMSAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSAPP.UserInterface.Models
{
    public class ShowProductsViewModel
    {
        public string SearchText { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}