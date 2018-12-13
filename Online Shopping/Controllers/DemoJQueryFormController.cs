using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_DAL;
using Online_Shopping.ViewModel;

namespace Online_Shopping.Controllers
{
    public class DemoJQueryFormController : Controller
    {
        // GET: DemoJ
        public ActionResult JqueryForm()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDefaultValues()
        {
            using(ShoppingDBEntities dbObj = new ShoppingDBEntities())
            {
                FormDefaultValuesVM formDefault = new FormDefaultValuesVM();
                formDefault.LanguagesKnown = dbObj.tblLanguages.ToList();
                formDefault.States = dbObj.tblStates.ToList();
                formDefault.Cities = dbObj.tblCities.ToList();

                return Json(formDefault, JsonRequestBehavior.AllowGet);
            }

           
        }

        [HttpPost]
        public JsonResult GetCityByState(int state)
        {
            using(ShoppingDBEntities shoppingDB = new ShoppingDBEntities())
            {
                var cities = shoppingDB.tblCities.Where(x => x.stateId == state).ToList();
                return Json(cities);
            }
            
        }
    }
}