using Mid.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace Mid.Controllers
{
    public class AdminController : Controller
    {
        private MIDEntities5 db = new MIDEntities5();
        // GET: Admin
        public ActionResult RequestFoodItemList()
        {
            var value = db.Request_Item.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult EmployeeRegistration() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeRegistration(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
        public ActionResult EmployeeList()
        {
            var value = db.Employees.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AssignEmployee(int id)
        { 
            var value = db.Request_Item.Find(id);
            ViewBag.Id = db.Employees.ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult AssignEmployee(Request_Item request_item) 
        {
            var ex = db.Request_Item.Find(request_item.ID);
            ex.EID = request_item.EID;
            ex.Status = "Waiting For Employee";
            db.SaveChanges();
            return RedirectToAction("RequestFoodItemList");
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}