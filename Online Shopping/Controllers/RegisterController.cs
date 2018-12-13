using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;
using Online_Shopping_DAL;
using Online_Shopping.ViewModel;

namespace Online_Shopping.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            RegisterVM objVM = new RegisterVM();

            objVM.UserCnfPwd = new RegisterModel();
            objVM.User = new tblUser();

            using(ShoppingDBEntities objDB = new ShoppingDBEntities())
            {
                List<tblProfile> objprof =  objDB.tblProfiles.ToList();
                objVM.Profile = new SelectList(objprof, "profileId", "profileName");
            }

            return View(objVM);
        }

        [HttpPost]
        public ActionResult Register(RegisterVM obj)
        {
            if (!ModelState.IsValid)
            {
                RegisterVM objVM = new RegisterVM();

                objVM.UserCnfPwd = new RegisterModel();
                objVM.User = new tblUser();

                using (ShoppingDBEntities objDB = new ShoppingDBEntities())
                {
                    List<tblProfile> objprof = objDB.tblProfiles.ToList();
                    objVM.Profile = new SelectList(objprof, "profileId", "profileName");
                }

                return View(objVM);
            }


            using (ShoppingDBEntities dbObjck = new ShoppingDBEntities())
            {


                if (dbObjck.tblUsers.Any(x => x.UserName == obj.UserCnfPwd.UserName))
                {
                    ViewBag.alert = "User Already exists, Choose Another UserName";

                    RegisterVM objVM = new RegisterVM();

                    objVM.UserCnfPwd = new RegisterModel();
                    objVM.User = new tblUser();

                    using (ShoppingDBEntities objDB = new ShoppingDBEntities())
                    {
                        List<tblProfile> objprof = objDB.tblProfiles.ToList();
                        objVM.Profile = new SelectList(objprof, "profileId", "profileName");
                    }

                    return View(objVM);
                }

                else
                {

                    tblUser userobj = new tblUser
                    {
                        UserName = obj.UserCnfPwd.UserName,
                        Password = obj.UserCnfPwd.Password,
                        RegistrationDate = DateTime.Now,
                        Name = obj.UserCnfPwd.Name,
                        profileId = obj.User.profileId
                    };

                    dbObjck.tblUsers.Add(userobj);
                    dbObjck.SaveChanges();
                    ModelState.Clear();

                    int userId = dbObjck.tblUsers.Max(x => x.UserID);
                    
                    

                    return RedirectToAction("UserScreen", new {id = userId, status = "register" });
                }

                
            }
        }

        public ActionResult UserScreen( int id, string status)
        {
            
            TempData["Status"] = status;
            using (ShoppingDBEntities dbobj = new ShoppingDBEntities())
            {
                var result = dbobj.tblUsers.Where(x => x.UserID == id).SingleOrDefault();
                return View(result);
            }
            
        }

    }
}