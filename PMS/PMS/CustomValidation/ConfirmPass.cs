using PMS.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.CustomValidation
{
    public class ConfirmPass:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pass = validationContext.ObjectInstance as CustomerDTO; //Unboxing

            if (pass.Password != null && value != null)
            {
                if (pass.Password.Equals(value.ToString()))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Both Password must be Same");
        }
    }
}