using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBindingPractice.Models
{
    public class Address
    {
        public int HouseNo { get; set; }
        public string BuildingName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}