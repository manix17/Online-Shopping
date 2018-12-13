using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;

namespace Online_Shopping.Controllers
{
    public class DemoDropDownListController : Controller
    {
        
        public ActionResult Index()
        {
            List<Country> countries;
            

            return View();
        }
    }
}