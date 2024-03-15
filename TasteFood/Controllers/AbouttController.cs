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
    public class AbouttController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Product
        public ActionResult AbouttList()
        {
            var values = context.Aboutts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAboutt()
        {


            return View();
        }


        [HttpPost]
        public ActionResult CreateAboutt(Aboutt p)
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
                p.ImageUrl2 = Url.Content(relativePath);
            }
            else
            {
                // Handle the case where no file was uploaded
                // For example, you might set a default image URL
                p.ImageUrl = "/Template/tasteit-master/images/";
                p.ImageUrl2 = "/Template/tasteit-master/images/";
            }

            // Add the product to the context and save changes
            context.Aboutts.Add(p);
            context.SaveChanges();

            // Redirect to the product list page
            return RedirectToAction("AbouttList");
        }


        public ActionResult DeleteAboutt(int id)
        {
            var value = context.Aboutts.Find(id);
            context.Aboutts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AbouttList");
        }


        [HttpGet]
        public ActionResult UpdateAboutt(int id)
        {
            var value = context.Aboutts.Find(id);


            return View(value);
        }


        public ActionResult UpdateAboutt(Aboutt p)
        {
            var value = context.Aboutts.Find(p.AbouttId);
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            value.ImageUrl2 = p.ImageUrl2;

          
            value.Title = p.Title;
            value.Title2 = p.Title2;
            context.SaveChanges();
            return RedirectToAction("AbouttList");


        }
    }
}