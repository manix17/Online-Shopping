using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;
using Online_Shopping_DAL;

namespace Online_Shopping.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel obj)
        {
            using (ShoppingDBEntities dbObjck = new ShoppingDBEntities())
            {


                if (dbObjck.tblUsers.Any(x => x.UserName == obj.UserName))
                {
                    ViewBag.alert = "User Already exists";
                    return View();
                }

                else
                {

                    tblUser userobj = new tblUser
                    {
                        UserName = obj.UserName,
                        Password = obj.Password,
                        RegistrationDate = DateTime.Now
                    };

                    dbObjck.tblUsers.Add(userobj);
                    dbObjck.SaveChanges();
                    ModelState.Clear();

                    return View();
                }


            }
        }
    }
}