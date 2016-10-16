using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            
            return View(db.Product.Where(p=>p.ProductName.Contains("White")));
        }
        
        public ActionResult Create()
        {
            var p = new Product()
            {
                ProductName = "White",
                Active = true,
                Price = 10,
                Stock = 5
            };

            db.Product.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var p = db.Product.Find(id);
            db.Product.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var p = db.Product.Find(id);
            return View(p);
        }

        public ActionResult update(int id)
        {
            var p = db.Product.Find(id);

            p.ProductName += "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException("欄位:" + error.PropertyName + " " + 
                            "錯誤訊息:" + error.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult updateAll()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            foreach(var item in data)
            {
                if (item.Price.HasValue)
                {
                    item.Price = item.Price.Value * 1.2m;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        

    }
}