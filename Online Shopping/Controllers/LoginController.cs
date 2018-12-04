using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;
using Online_Shopping_DAL;

namespace Online_Shopping.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel obj)
        {
            using(ShoppingDBEntities dbobj = new ShoppingDBEntities())
            {
               var result = dbobj.tblUsers.Where(x => x.UserName == obj.UserName).SingleOrDefault();
               if(result == null)
                {
                    ViewBag.alert1 = "UserName does'nt exist";
                    return View();
                }
               else if(result.UserName== obj.UserName && result.Password == obj.Password)
                {
                    
                    return RedirectToAction("UserScreen","Register", new {id = result.UserID, status = "login" });
                }
                else
                {
                    ViewBag.alert2 = "UserName and Password does'nt Match";
                    return View();
                }
            }
            
        }
    }
}