using NewFormValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFormValidation.Models
{
    public class CheckDOB : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objDOB = validationContext.ObjectInstance as Validation; //Unboxing

            //DOB
            if (objDOB.DOB == default(DateTime))
                return new ValidationResult("You must provide a DOB");

            int age = DateTime.Today.Year - objDOB.DOB.Value.Year;
            if (age < 18)
                return new ValidationResult("You must be above 18 years old");

            if (objDOB.DOB.Value.Year > DateTime.Today.Year)
                return new ValidationResult("Invalid Date of Birth");

            return ValidationResult.Success;
        }
    }
}