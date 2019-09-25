using ModelBindingPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingPractice.Infrastructure
{
    public class EmployeeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var req = controllerContext.HttpContext.Request;
            var id = int.Parse(req.Form.Get("Id"));
            var firstName = req.Form.Get("FirstName");
            var lastName = req.Form.Get("LastName");
            var address = req.Form.Get("Address");
            IList<string> nameParts = new List<string> { firstName, lastName };
            var fullName = string.Join(",", nameParts);
            return new Employee
            {
                FullName = fullName,
                Id = id,
                Address = address
            };
        }
    }
}