using System;
using System.Collections.Generic;
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
            TempData["regStatus"] = "Registratio";
            return RedirectToAction("ShowProduct");
        }
    }
}