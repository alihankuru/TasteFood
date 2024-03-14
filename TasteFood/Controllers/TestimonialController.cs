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
    public class TestimonialController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Product
        public ActionResult TestimonialList()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
          

            return View();
        }


        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial p)
        {
          

            // Check if a file was uploaded
            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                string fileName = Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(fileName);
                string relativePath = "~/Template/tasteit-master/images/" + fileName;

                // Map the virtual path to the physical file path
                string absolutePath = Server.MapPath(relativePath);

                // Save the file to the server
                file.SaveAs(absolutePath);

                // Set the ImageUrl property of the product
                p.ImageUrl = Url.Content(relativePath);
            }
            else
            {
                // Handle the case where no file was uploaded
                // For example, you might set a default image URL
                p.ImageUrl = "/Template/tasteit-master/images/";
            }

            // Add the product to the context and save changes
            context.Testimonials.Add(p);
            context.SaveChanges();

            // Redirect to the product list page
            return RedirectToAction("TestimonialList");
        }


        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }


        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);

      
            return View(value);
        }


        public ActionResult UpdateTestimonial(Testimonial p)
        {
            var value = context.Testimonials.Find(p.TestimonialId);
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");


        }

    }
}