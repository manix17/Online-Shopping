using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Shopping.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "UserName can only be Alphabetic")]
        public string Name { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage ="Please Enter UserName")]
        [RegularExpression("^[a-zA-Z0-9]+$",ErrorMessage = "UserName can only be AlphaNumeric")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords does'nt Match")]
        public string ConfirmPassword { get; set; }
    }
}