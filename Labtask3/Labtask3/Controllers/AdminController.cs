using Labtask3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labtask3.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult PList()
        {
            var db = new labtask3Entities4();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult PCreate()
        {
            var db = new labtask3Entities4();
            return View();
        }
        [HttpPost]
        public ActionResult PCreate(Product product)
        {
            var db = new labtask3Entities4();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("PList");
        }
        public ActionResult PDelete(int ID)
        {
            var db = new labtask3Entities4();
            var deleteID = db.Products.Find(ID);
            db.Products.Remove(deleteID);
            db.SaveChanges();
            return RedirectToAction("PList");
        }
        [HttpGet]
        public ActionResult PEdit(int ID)
        {
            var db = new labtask3Entities4();
            var data = db.Products.Find(ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult PEdit(Product product)
        {
            var db = new labtask3Entities4();
            var data = db.Products.Find(product.ID);
            data.Name = product.Name;
            data.Price = product.Price;
            data.Quantity = product.Quantity;
            data.CID = product.CID;
            db.SaveChanges();
            return RedirectToAction("PList");
        }
        public ActionResult CList()
        {
            var db = new labtask3Entities4();
            var data = db.Categories.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult CCreate()
        {
            var db = new labtask3Entities4();
            return View();
        }
        [HttpPost]
        public ActionResult CCreate(Category category)
        {
            var db = new labtask3Entities4();
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("CList");
        }
        public ActionResult CDelete(int ID)
        {
            var db = new labtask3Entities4();
            var deleteID = db.Categories.Find(ID);
            db.Categories.Remove(deleteID);
            db.SaveChanges();
            return RedirectToAction("CList");
        }
        [HttpGet]
        public ActionResult CEdit(int ID)
        {
            var db = new labtask3Entities4();
            var data = db.Categories.Find(ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult CEdit(Category category)
        {
            var db = new labtask3Entities4();
            var data = db.Categories.Find(category.ID);
            data.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("CList");
        }
        public ActionResult OEdit(int ID)
        {
            var db = new labtask3Entities4();
            var data = db.Orders.Find(ID);
            data.Status = "Confirmed";
            db.SaveChanges();
            return RedirectToAction("OList");
        }
        public ActionResult OList()
        {
            var db = new labtask3Entities4();
            var data = db.Orders.ToList();
            return View(data);
        }
        public ActionResult ODelete(int ID)
        {
            var db = new labtask3Entities4();
            var deleteID = db.Orders.Find(ID);
            db.Orders.Remove(deleteID);
            db.SaveChanges();
            return RedirectToAction("OList");
        }
        public ActionResult UList()
        {
            var db = new labtask3Entities4();
            var data = db.Users.ToList();
            return View(data);
        }
        public ActionResult UDelete(int ID)
        {
            var db = new labtask3Entities4();
            var deleteID = db.Users.Find(ID);
            db.Users.Remove(deleteID);
            db.SaveChanges();
            return RedirectToAction("UList");
        }

    }
}