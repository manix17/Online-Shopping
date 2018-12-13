using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping.Models;
using Online_Shopping_DAL;
using Online_Shopping.ViewModel;

// Fetch + Merge = pull

namespace Online_Shopping.Controllers
{
    public class ProductController : Controller
    {

        [HttpGet]
        public ActionResult CreateProduct()
        {

            using (ShoppingDBEntities dbobj = new ShoppingDBEntities())
            {
                var products = dbobj.tblProducts.ToList();

                CreateProductVM objcreateProductVM = new CreateProductVM();
                objcreateProductVM.product = new tblProduct();
                objcreateProductVM.products = products;
                objcreateProductVM.ProductModel = new ProductModel();

                return View(objcreateProductVM);
            }

        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel obj)
        {
            //ProductDB.Insert(obj);

            using (ShoppingDBEntities objDBshopping = new ShoppingDBEntities())
            {
                try
                {
                    tblProduct objTblprod = new tblProduct
                    {

                        ProductName = obj.ProductName,
                        Description = obj.ProductDesc,
                        UnitPrice = Convert.ToInt32(obj.ProductUnitPrice),
                        Unit = obj.ProductUnit,
                        Category = obj.CategoryId.ToString(),
                        isActive = true,
                        CreatedDate = DateTime.Now
                    };

                    objDBshopping.tblProducts.Add(objTblprod);
                    objDBshopping.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
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
            if (TempData["dtlpage"] == null)
            {
                return RedirectToAction("ShowProduct");
            }
            else
            {
                int lid = id;
                return RedirectToAction("Details", "Product", new { id = lid });
            }
        }

        [HttpGet]
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

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (ShoppingDBEntities objdtl = new ShoppingDBEntities())
            {
                TempData["dtlpage"] = "true";
                var result = objdtl.tblProducts.Where(l => l.ProductID == id).SingleOrDefault();
                return View(result);
            }

        }


    }
}