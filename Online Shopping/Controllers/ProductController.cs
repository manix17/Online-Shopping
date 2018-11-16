using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;

// Fetch + Merge = pull

namespace Online_Shopping.Controllers
{
    public class ProductController : Controller
    {
       
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel obj)
        {
            using (ShoppingDBEntities objDBshopping = new ShoppingDBEntities())
            {
                try
                {
                    tblProduct objTblprod = new tblProduct();

                    objTblprod.ProductName = obj.ProductName;
                    objTblprod.Description = obj.ProductDesc;
                    objTblprod.UnitPrice = Convert.ToInt32(obj.ProductUnitPrice);
                    objTblprod.Unit = obj.ProductUnit;
                    objTblprod.Category = obj.CategoryId;
                    objTblprod.isActive = true;

                    objDBshopping.tblProducts.Add(objTblprod);
                    objDBshopping.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            TempData["regStatus"] = "Registration";
            return RedirectToAction("ShowProduct");
        }

        [HttpGet]
        public ActionResult ShowProduct()
        {
            using (ShoppingDBEntities dbobj = new ShoppingDBEntities())
            {
                List<tblProduct> result = dbobj.tblProducts.Where(x => x.isActive == true).ToList();
                return View(result);
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (ShoppingDBEntities dbobjdel = new ShoppingDBEntities())
            {
                tblProduct result = dbobjdel.tblProducts.Where(c => c.ProductID == id).SingleOrDefault();
                dbobjdel.tblProducts.Remove(result);
                dbobjdel.SaveChanges();
            }
            return RedirectToAction("ShowProduct");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (ShoppingDBEntities dbobjedt = new ShoppingDBEntities())
            {
                tblProduct result = dbobjedt.tblProducts.Where(c => c.ProductID == id).SingleOrDefault();
                ViewBag.productName = result.ProductName;
                ViewBag.productDesc = result.Description;
                ViewBag.productUnitPrice = result.UnitPrice;
                ViewBag.productUnit = result.Unit;
                ViewBag.productCategory = result.Category;

                TempData["ProductID"] = id;
                TempData.Keep();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(EditProducts obje)
        {
            int id = (int)TempData["ProductID"];
            using (ShoppingDBEntities objDBedt = new ShoppingDBEntities())
            {

                var result = objDBedt.tblProducts.Where(y => y.ProductID == id).FirstOrDefault();

                //result.ProductName = obje.ProductName;
                result.Description = obje.ProductDesc;
                result.UnitPrice = Convert.ToInt32(obje.ProductUnitPrice);
                result.Unit = obje.ProductUnit;
                //result.Category = obje.CategoryId;

                objDBedt.Entry(result).State = EntityState.Modified;
                objDBedt.SaveChanges();

                TempData["editStatus"] = "Successful";

            }
            return RedirectToAction("ShowProduct");
        }

        public ActionResult VirtualDelete(int id)
        {
            using (ShoppingDBEntities vdelobj = new ShoppingDBEntities())
            {
                var result = vdelobj.tblProducts.Where(y => y.ProductID == id).FirstOrDefault();
                result.isActive = false;

                vdelobj.Entry(result).State = EntityState.Modified;
                vdelobj.SaveChanges();
                TempData["delStatus"] = "Successful";
            }
            return RedirectToAction("ShowProduct");
        }

        public ActionResult Details(int id)
        {
            using(ShoppingDBEntities objdtl = new ShoppingDBEntities())
            {
                var result = objdtl.tblProducts.Where(l => l.ProductID == id).SingleOrDefault();
                return View(result);
            }
                
        }
    }
}