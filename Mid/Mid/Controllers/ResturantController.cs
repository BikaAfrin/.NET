using Mid.EntityFramework;
using Mid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mid.Controllers
{
    public class ResturantController : Controller
    {
        private MIDEntities5 db = new MIDEntities5();
        // GET: Resturant
        public ActionResult FoodList()
        {
            String username = (String)Session["username"];
            var user = db.Resturants.FirstOrDefault(x => x.Username == username);
            var reqlist = db.Request_Item.Where(x => x.RID == user.ID);
            return View(reqlist.ToList());
        }
        [HttpGet]
        public ActionResult AddRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRequest(Request_ItemDTO request_itemdto)
        {
            Request_Item request_item = new Request_Item()
            {
                Name = request_itemdto.Name,
                Expiredate = request_itemdto.Expiredate,
                Status = request_itemdto.Status,
                RID = request_itemdto.RID,
                EID = request_itemdto.EID,
            };
            db.Request_Item.Add(request_item);
            db.SaveChanges();
            return RedirectToAction("FoodList");
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}