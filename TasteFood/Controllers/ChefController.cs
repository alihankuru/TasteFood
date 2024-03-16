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
    public class ChefController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Product
        public ActionResult Index()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

        public ActionResult ChefList()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateChef()
        {


            return View();
        }


        [HttpPost]
        public ActionResult CreateChef(Chef p)
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
            context.Chefs.Add(p);
            context.SaveChanges();

            // Redirect to the product list page
            return RedirectToAction("ChefList");
        }


        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }


        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);


            return View(value);
        }


        public ActionResult UpdateChef(Chef p)
        {
            var value = context.Chefs.Find(p.ChefId);
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            context.SaveChanges();
            return RedirectToAction("ChefList");


        }
    }
}