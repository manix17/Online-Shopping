using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;
using Online_Shopping.ViewModel;

namespace Online_Shopping.Controllers
{
    public class DemoJQueryController : Controller
    {
        
        public ActionResult JqueryTest()
        {
            return View();
        }

        [HttpGet]
        public ActionResult JSONResult()
        {
            return Json(new
            {
                msg = "message from server"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JSONResultPost(RegisterModel rm)
        {
            return Json(new
            {
                msg = "message from server"
            });
        }

        [HttpGet]
        public ActionResult JqueryDropdown()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetStates()
        {
            var states = new List<StatesViewmodel>() {
            new StatesViewmodel { state = "Uttar Pradesh", stateid = 1 },
            new StatesViewmodel { state = "Madhya Pradesh", stateid = 2 }
            };

            //var ss = new StatesViewmodel { state = "Uttar Pradesh", stateid = 1 };
            //states.Add(ss);
            
           
            
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDistricts(string state)
        {
            var dists = new List<string>();
            if(state == "1")
            {
                dists.Add("Ballia");
                dists.Add("Varanasi");
            }
            else if (state == "2")
            {
                dists.Add("Indore");
                dists.Add("Jabalpur");
            }

            
            return Json(dists, JsonRequestBehavior.AllowGet);
        }


    }
}