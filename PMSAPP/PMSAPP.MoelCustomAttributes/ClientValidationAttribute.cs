using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PMSAPP.MoelCustomAttributes
{
    public class ClientValidationAttribute :
        ValidationAttribute
    {
        public ClientValidationAttribute()
        {
            this.ErrorMessage = "No appointment can be scheduled on Monday";
        }
        public override bool IsValid(object value)
        {
            Appointment appointment = value as Appointment;
            if (appointment == null || appointment.Date == null)
            {
                return true;
            }
            else
            {
                return !(appointment.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}