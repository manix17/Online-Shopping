using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_DAL;
using Online_Shopping.Models;
using System.Web.Mvc;

namespace Online_Shopping.ViewModel
{
    public class CreateProductVM
    {
        public tblProduct product { get; set; }
        public IEnumerable<tblProduct> products { get; set; }
        public ProductModel ProductModel { get; set; }
        
    }
}