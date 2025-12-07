using PMS.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.CustomValidation
{
    public class EmailValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var email = value.ToString();
                var db = new PMSEntities();
                var obj = (from u in db.Customers
                           where u.Email.Equals(email)
                           select u).SingleOrDefault();

                if (obj == null)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("This Email already Exists");
                }
            }
            return new ValidationResult("Email Required");
        }
    }
}