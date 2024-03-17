using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;

namespace TasteFood.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext(); 
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.v1 = context.Categories.Count();
            ViewBag.v2 = context.Products.Count();
            ViewBag.v3 = context.Chefs.Count();
            ViewBag.v4 = context.Reservations.Where(x => x.ReservationStatus == "Aktif").Count();

            ViewBag.mesaj = context.Contacts.Count();
            ViewBag.rezevasyon = context.Reservations.Count();
            ViewBag.müşteri = context.Testimonials.Count();
            ViewBag.productprice = Convert.ToInt32(context.Products.Max(x => x.Price));
            var value = context.Reservations.Take(5).ToList();

            return View(value);
        }
    }
}