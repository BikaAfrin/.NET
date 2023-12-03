using Mid.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mid.Controllers
{
    public class EmployeeController : Controller
    {
        private MIDEntities5 db = new MIDEntities5();
        // GET: Employee
        public ActionResult Requestlist()
        {
            String username = (String)Session["username"];
            var user = db.Employees.FirstOrDefault(x => x.Username == username);
            var reqlist = db.Request_Item.Where(x => x.EID == user.ID);
            return View(reqlist.ToList());
        }
        public ActionResult Collectfood(int ID)
        {
            var ex = db.Request_Item.Find(ID);
            ex.Status = "Confirmed";
            db.SaveChanges();
            return RedirectToAction("Requestlist");
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}