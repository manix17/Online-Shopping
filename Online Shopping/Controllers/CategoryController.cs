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
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spInsertCategory";
            com.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = objcat.CategoryName;
            com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = objcat.Desc;
            com.Parameters.Add("@isActive", SqlDbType.Bit).Value = true;

            com.ExecuteNonQuery();
            return View();
        }
    }
}