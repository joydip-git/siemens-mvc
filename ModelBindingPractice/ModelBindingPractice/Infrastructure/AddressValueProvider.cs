using ModelBindingPractice.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingPractice.Infrastructure
{
    public class AddressValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
           return prefix.ToLower().IndexOf("city") > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (this.ContainsPrefix(key))
            {
                ValueProviderResult result = new ValueProviderResult("Bangalore", "Banaglore", CultureInfo.InvariantCulture);
                return result;
            }
            else
                return null;
        }
    }
}