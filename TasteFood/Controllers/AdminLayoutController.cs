using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;

namespace TasteFood.Controllers
{
    
    public class AdminLayoutController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            
            ViewBag.NotificationIsReadByFalseCount=context.Notifications.Where(x=>x.IsRead==false).Count();

            var values = context.Notifications.Where(x=>x.IsRead==false).ToList();
            return PartialView(values);
        }

       

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult NotificationStatusChangeTrue(int id)
        {
            var values = context.Notifications.Find(id);
            values.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("NotificationList", "Notification");
        }

        public ActionResult NotificationStatusChangeFalse(int id)
        {
            var values = context.Notifications.Find(id);
            values.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("NotificationList", "Notification");
        }

        public PartialViewResult PartialProfile()
        {
            ViewBag.v = Session["name"];
            ViewBag.a=Session["img"];
            var value = context.Admins.Find(Session["id"]);
            
            return PartialView(value);
        }

    }
}