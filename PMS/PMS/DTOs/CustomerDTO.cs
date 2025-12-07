using PMS.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z.\-\s]+[A-Za-z.]$", ErrorMessage = "Name can contain alphabets, spaces, dots & and dash.")]
        public string Name { get; set; }

        [EmailValidation]
        public string Email { get; set; }

        [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain space.")]
        [UserValidation]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [ConfirmPass]
        public string ConfPass { get; set; }
    }
}