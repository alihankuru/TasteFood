using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Product
        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        
        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }


        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);


            return View(value);
        }


        public ActionResult UpdateAbout(About p)
        {
            var value = context.Abouts.Find(p.AboutId);
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
   
            value.Title = p.Title; 
            context.SaveChanges();
            return RedirectToAction("AboutList");


        }
    }
}