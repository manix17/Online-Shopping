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

        [HttpPost]
        public JsonResult SaveFormtoDb(JQueryFormVM formData)
        {
            using (ShoppingDBEntities dbObj = new ShoppingDBEntities())
            {
                tblDemoJQueryForm tblDemoJQuery = new tblDemoJQueryForm
                {
                    Code = formData.code,
                    Name = formData.name,
                    DOB = formData.dob,
                    Gender = formData.gender,
                    Salary = formData.salary,
                    State = formData.state,
                    City = formData.city,
                    CreatedDate = DateTime.Now

                };

                dbObj.tblDemoJQueryForms.Add(tblDemoJQuery);
                dbObj.SaveChanges();

                var x = dbObj.tblDemoJQueryForms.OrderByDescending(m => m.id).First().id;

                tblLanguageInter inter = new tblLanguageInter();

                foreach (var y in formData.languages)
                {
                    inter.Id = x;
                    inter.languageId = y;

                    dbObj.tblLanguageInters.Add(inter);
                    dbObj.SaveChanges();
                }

            }
            return Json("saved");
        }

        [HttpGet]
        public JsonResult GetDbData()
        {
            using(ShoppingDBEntities dbObj = new ShoppingDBEntities())
            {
                JqueryTableDisplay tableDisplay = new JqueryTableDisplay
                {
                    Languages = new List<string>()
                };
                List<JqueryTableDisplay> jqueryTable = new List<JqueryTableDisplay>();


                var q = from tblMaster in dbObj.tblDemoJQueryForms
                        join tblInter in dbObj.tblLanguageInters on tblMaster.id equals tblInter.Id
                        join tblLang in dbObj.tblLanguages on tblInter.languageId equals tblLang.languageId
                        join states in dbObj.tblStates on tblMaster.State equals states.stateid
                        join cities in dbObj.tblCities on tblMaster.City equals cities.cityId
                        where (tblMaster.id == tblInter.Id) && (tblInter.languageId == tblLang.languageId)
                            && (tblMaster.State == states.stateid) && (tblMaster.City == cities.cityId)
                        select new {tblMaster.id, tblMaster.Name, tblMaster.DOB, tblMaster.Gender, states.stateid, states.stateName,
                                    tblMaster.Salary, cities.cityId, cities.cityName, tblLang.languageId, tblLang.languageName};
                var results = q.ToList();

                int i = -1;
                int j = 0;
                Nullable<int> last_id = null;

                foreach (var item in results)
                {

                    if (item.id != last_id)
                    {
                        jqueryTable.Add(tableDisplay);
                        i++;
                        jqueryTable[i].Name = item.Name;
                        jqueryTable[i].DOB = item.DOB;
                        jqueryTable[i].Salary = item.Salary;

                        if(item.Gender== 1)
                        {
                            jqueryTable[i].Gender = "Male";
                        }
                        else if (item.Gender == 2)
                        {
                            jqueryTable[i].Gender = "Female";
                        }
                        else if (item.Gender == 3)
                        {
                            jqueryTable[i].Gender = "Transgender";
                        }
                        else
                        {
                            jqueryTable[i].Gender = "Not Stated";
                        }

                        jqueryTable[i].State = item.stateName;
                        jqueryTable[i].City = item.cityName;

                        jqueryTable[i].Languages.Add("test");
                        jqueryTable[i].Languages[j] = item.languageName;
                        last_id = item.id;
                    }
                    else
                    {
                        j++;
                        jqueryTable[i].Languages.Add("test");
                        jqueryTable[i].Languages[j] = item.languageName;                  
                    }
                }

                var output = jqueryTable;

               return Json(output, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}