using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class ProfileController : Controller
    {
        TasteContext context = new TasteContext();


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.v = Session["name"];

            var value = context.Admins.Find(Session["id"]);
            return View(value);

        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value = context.Admins.Find(admin.AdminId);
            value.Username = admin.Username;
            value.Name = admin.Name;
            value.Surname = admin.Surname;
            value.Password = admin.Password;
            if (admin.ImageUrl != null)
            {
                value.ImageUrl = admin.ImageUrl;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Profile");

        }

    }
}