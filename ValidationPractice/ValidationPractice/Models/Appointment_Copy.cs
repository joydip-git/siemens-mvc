using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ValidationPractice.Models
{
    public class Appointment_Copy : IValidatableObject
    {
        public string ClientName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }
            if (DateTime.Now > Date)
                errors.Add(new ValidationResult("please enter a future date"));

            if (errors.Count == 0 && Date.DayOfWeek == DayOfWeek.Monday)
                errors.Add(new ValidationResult("appointment can't be scheduled on Monday"));

            if (!TermsAccepted)
                errors.Add(new ValidationResult("you must accept the terms and conditions properly"));

            return errors;
        }
    }
}