using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMSAPP.MoelCustomAttributes
{
    public class FutureDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && ((DateTime)value) > DateTime.Now;
        }        
    }
}