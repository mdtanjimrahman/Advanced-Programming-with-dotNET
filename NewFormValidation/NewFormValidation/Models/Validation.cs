using NewFormValidation.CustomAnnotation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewFormValidation.Models
{
    public class Validation
    {
        [Required(ErrorMessage = "You must provide your Aiub ID")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Id must be in a format of xx-xxxxx-x")]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "You must provide a name")]
        [RegularExpression(@"^[A-Za-z.\-\s]+[A-Za-z.]", ErrorMessage = "Name can contain alphabets, spaces, dots & and dash.")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Annotation(ErrorMessage = "Please Enter an Email")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [CheckDOB(ErrorMessage = "Please enter you DOB")]
        [DisplayName("DOB")]
        public DateTime? DOB { get; set; }
    }
}