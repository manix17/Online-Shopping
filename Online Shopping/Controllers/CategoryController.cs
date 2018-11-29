using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Online_Shopping.Models;


namespace Online_Shopping.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryModel objcat)
        {
            string conString = WebConfigurationManager.AppSettings["dbcon"].ToString();
            //Insert insert1 = new Insert();
            //Online_Shopping_DAL.Insert.Category();
            //insert1.Category(objcat, conString);
            return View();
        }
    }
}