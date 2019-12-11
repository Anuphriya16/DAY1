using MVCexample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCexample.CustomAttribute
{
    public class ValidBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.BirthDate >= DateTime.Now)
            {
                return new ValidationResult("Hey You are Not Born Yet, Don't Cheat");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}