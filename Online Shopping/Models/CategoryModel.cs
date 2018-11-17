using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Shopping.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Please Enter Category Name")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Desc { get; set; }
    }
}