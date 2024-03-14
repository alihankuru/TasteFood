using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class PartialSliderController : Controller
    {
        TasteContext context = new TasteContext();

      
        public ActionResult PartialSliderList()
        {
            var values = context.PartialSliders.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreatePartialSlider()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreatePartialSlider(PartialSlider partialSlider)
        {
            context.PartialSliders.Add(partialSlider);
            context.SaveChanges();
            return RedirectToAction("PartialSliderList");
        }
        public ActionResult DeletePartialSlider(int id)
        {
            var values = context.PartialSliders.Find(id);
            context.PartialSliders.Remove(values);
            context.SaveChanges();
            return RedirectToAction("PartialSliderList");
        }

        [HttpGet]
        public ActionResult UpdatePartialSlider(int id)
        {
            var value = context.PartialSliders.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePartialSlider(PartialSlider partialSlider)
        {
            var value = context.PartialSliders.Find(partialSlider.SliderId);
            value.Title = partialSlider.Title;
            value.ImageUrl = partialSlider.ImageUrl;
            value.SubTitle = partialSlider.SubTitle;
            value.Description = partialSlider.Description;  

            context.SaveChanges();

            return RedirectToAction("PartialSliderList");

        }

    }
}