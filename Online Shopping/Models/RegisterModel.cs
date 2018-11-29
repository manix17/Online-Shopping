using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Shopping.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage ="Please Enter UserName")]
        [RegularExpression("^[a-zA-Z0-9]+$",ErrorMessage = "UserName can only be AlphaNumeric")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords does'nt Match")]
        public string ConfirmPassword { get; set; }
    }
}