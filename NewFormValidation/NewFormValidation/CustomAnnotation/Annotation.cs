using NewFormValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NewFormValidation.CustomAnnotation
{
    public class Annotation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as Validation; //Unboxing
            if (obj == null)
            {
                return ValidationResult.Success;
            }

            //Email
            if (string.IsNullOrEmpty(obj.Id))
                return new ValidationResult("Student Id must be provided first");

            if (string.IsNullOrEmpty(obj.Email))
                return new ValidationResult("Must provide an Email");

            string emailpattern = @"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$";
            if(!Regex.IsMatch(obj.Email, emailpattern))
                return new ValidationResult("Email must follow xx-xxxxx-x@student.aiub.edu");

            if (!obj.Email.StartsWith(obj.Id))
                return new ValidationResult("Your email id must be same as your student ID");

            return ValidationResult.Success;
        }
    }
}