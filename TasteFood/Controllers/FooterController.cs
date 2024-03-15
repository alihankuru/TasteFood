using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class FooterController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Contact
        public ActionResult FooterList()
        {
            var values = context.Footers.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateMessage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(Footer p)
        {
            context.Footers.Add(p);
            context.SaveChanges();
            return RedirectToAction("FooterList");


        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Footers.Find(id);
            context.Footers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("FooterList");


        }

    }
}