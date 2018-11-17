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
            // Creating a Connection String
            string conString = WebConfigurationManager.AppSettings["dbcon"].ToString();

            // Creating a sql Connection using Connection String
            // It's Best Practice to Create the SQL Connection inside using
            // SqlConnection con = new SqlConnection(conString);

            using (SqlConnection con = new SqlConnection(conString))
            {
                //Opening sqlconnection
                con.Open();

                // Create the command and set its properties.
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "spInsertCategory";

                // Specifying the parameters for Stored Procedure
                //com.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = objcat.CategoryName;
                //com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = objcat.Desc;
                //com.Parameters.Add("@isActive", SqlDbType.Bit).Value = true;

                // Add the input parameter and set its properties.
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@CategoryName";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = objcat.CategoryName;

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@Description";
                parameter2.SqlDbType = SqlDbType.NVarChar;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = objcat.Desc;

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@isActive";
                parameter3.SqlDbType = SqlDbType.Bit;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = true ;

                // Add the parameter to the Parameters collection. 
                com.Parameters.Add(parameter);
                com.Parameters.Add(parameter2);
                com.Parameters.Add(parameter3);


                // Executing Stored Procedure
                com.ExecuteNonQuery();
            }

            return View();
        }

        public ActionResult ShowCategory()
        {

            return View();
        }
    }
}