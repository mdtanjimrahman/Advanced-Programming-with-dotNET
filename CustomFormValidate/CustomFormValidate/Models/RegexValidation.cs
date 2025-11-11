using CustomFormValidate.ValidateAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomFormValidate.Models
{
    public class RegexValidation
    {
        [Required(ErrorMessage = "You must provide a Name.")]
        [RegularExpression(@"^[A-Za-z.\-\s]+[A-Za-z.]$", ErrorMessage = "Name can contain alphabets, spaces, dots & and dash.")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a Username.")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain space.")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must provide an ID.")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must follow the format xx-xxxxx-x")]
        [DisplayName("AIUB ID")]
        public string Id { get; set; }

        [CustomDateEmail(ErrorMessage = "Please Enter a DOB")]
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }

        [CustomDateEmail(ErrorMessage = "Please Enter an Email")]
        [DisplayName("AIUB Email")]
        public string Email { get; set; }



    }
}