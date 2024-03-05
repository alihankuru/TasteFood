using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;

namespace TasteFood.Controllers
{
    public class NotificationController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Notification
        public ActionResult NotificationList()
        {
            var values = context.Notifications.ToList();    
            return View(values);
        }
    }
}