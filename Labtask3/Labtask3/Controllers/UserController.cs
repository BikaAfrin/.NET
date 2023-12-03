using Labtask3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labtask3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public static class myGlobalVariable
        {
            public static List<Product> Products = new List<Product>();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var db = new labtask3Entities4();
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            var db = new labtask3Entities4();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult PList()
        {
            var db = new labtask3Entities4();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var db = new labtask3Entities4();
            var data = db.Users.Find(ID);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var db = new labtask3Entities4();
            var data = db.Users.Find(user.ID);
            data.Name = user.Name;
            data.Phone = user.Phone;
            data.Email = user.Email;
            data.Type = user.Type;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult AddToCart(int Id)
        {
            var db = new labtask3Entities4();
            var data = db.Products.Find(Id);
            data.Quantity = 1;
            myGlobalVariable.Products.Add(data);
            return RedirectToAction("PList");
        }
        public ActionResult PDetails(int Id)
        {

            var db = new labtask3Entities4();
            var data = db.Products.Find(Id);
            return View(data);
        }
        public ActionResult Cart()
        {
            return View(myGlobalVariable.Products);
        }
        public ActionResult OConfirm()
        {
            return View();
        }
        /*public ActionResult FinallyConfirmed()
        {
            return View();
        }*/
    }

   
}