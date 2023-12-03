using Microsoft.Ajax.Utilities;
using Mid.EntityFramework;
using Mid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mid.Controllers
{
    public class LoginController : Controller
    {
        private MIDEntities5 db = new MIDEntities5();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO logindto)
        {
            if (logindto.Type.Equals("Admin"))
            {
                var ad = (from a in db.Admins
                          where a.Username == logindto.Username
                          select a).SingleOrDefault();
                if (ad != null && ad.Password == logindto.Password)
                {
                    return RedirectToAction("RequestFoodItemList", "Admin");
                }

            }
            if (logindto.Type.Equals("Resturant"))
            {
                var res = (from r in db.Resturants
                           where r.Username == logindto.Username
                           select r).SingleOrDefault();
                if (res != null && res.Password == logindto.Password)
                {
                    Session["Username"] = logindto.Username;
                    Session["Type"] = logindto.Type;    
                    return RedirectToAction("FoodList","Resturant");
                }

            }
            if (logindto.Type.Equals("Employee"))
            {
                var em = (from e in db.Employees
                          where e.Username == logindto.Username
                          select e).SingleOrDefault();
                if (em != null && em.Password == logindto.Password)
                {
                    Session["Username"] = logindto.Username;
                    Session["Type"] = logindto.Type;
                    return RedirectToAction("Requestlist","Employee");
                }

            }
            return View(logindto);
        }
    }
}
        