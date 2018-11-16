using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online_Shopping.Models
{
    public class EditProducts
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Edit Description")]
        public string ProductDesc { get; set; }

        [Required(ErrorMessage = "Please Enter Revised Price")]
        [Display(Name = "New Unit Price")]
        public string ProductUnitPrice { get; set; }


        [Required(ErrorMessage = "Please Enter Unit")]
        [Display(Name = "Unit")]
        public string ProductUnit { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }
    }
}