using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbarInfo()
        {
            ViewBag.phone=context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(x => x.Description).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            var values=context.PartialSliders.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialBook(Reservation reservation)
        {
            try
            {
                // Check if the datetime value is within the valid range for datetime data type
                if (reservation.ReservationDate >= SqlDateTime.MinValue.Value && reservation.ReservationDate <= SqlDateTime.MaxValue.Value)
                {
                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                }
                else
                {
                    
                    ModelState.AddModelError("", "Datetime value is out of range.");
                }
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "An error occurred while processing your request.");
               
            }

            
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.image = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialMenu()
        {
            var values= context.Products.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();

            return PartialView(values);
        }

        public PartialViewResult PartialChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout2()
        {

            var values = context.Aboutts.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            var values=context.Footers.ToList();
            

            return PartialView(values);
        }

        public PartialViewResult PartialFooter2(Contact p)
        {
            try
            {
                // Ensure the DateTime property is within the valid range
                if (p.SendDate >= SqlDateTime.MinValue.Value && p.SendDate <= SqlDateTime.MaxValue.Value)
                {
                    // Handle the out-of-range condition appropriately
                    // Perhaps set a default value or log the issue
                }
                else
                {
                    p.SendDate = DateTime.UtcNow;
                    context.Contacts.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                // Log the exception or return an error message
            }

            return PartialView();
        }



    }
}