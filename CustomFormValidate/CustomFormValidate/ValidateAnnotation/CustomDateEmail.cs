using CustomFormValidate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomFormValidate.ValidateAnnotation
{
        public class CustomDateEmail : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var obj = validationContext.ObjectInstance as RegexValidation;  // UNBOXING
                if (obj == null)
                    return ValidationResult.Success;

                // DOB
                if (obj.DOB == default(DateTime))
                    return new ValidationResult("You must provide a Date of Birth.");

                int age = DateTime.Today.Year - obj.DOB.Year;
                if (obj.DOB > DateTime.Today.AddYears(-age)) age--;
                if (age < 18)
                    return new ValidationResult("Age must be at least 18 years old.");

                //Email
                if (string.IsNullOrEmpty(obj.Email))
                    return new ValidationResult("You must provide an Email.");

                if (string.IsNullOrEmpty(obj.Id))
                    return new ValidationResult("Student ID must be provided first.");

                // Email Pattern
                string pattern = @"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$";
                if (!Regex.IsMatch(obj.Email, pattern))
                    return new ValidationResult("Email must follow xx-xxxxx-x@student.aiub.edu format.");

                if (!obj.Email.StartsWith(obj.Id))
                    return new ValidationResult("Email ID part must match the provided Student ID.");

                return ValidationResult.Success;
            }
        }
    
}