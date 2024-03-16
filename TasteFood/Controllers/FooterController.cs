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
        public ActionResult UpdateFooter(int id)
        {
            var value = context.Footers.Find(id);


            return View(value);
        }


        public ActionResult UpdateFooter(Footer p)
        {
            var value = context.Footers.Find(p.FooterId);
            value.Description = p.Description;
            value.SocialMedia1 = p.SocialMedia1;
            value.SocialMedia2 = p.SocialMedia2;
            value.SocialMedia3 = p.SocialMedia3;
            context.SaveChanges();
            return RedirectToAction("FooterList");

        }




    }
}