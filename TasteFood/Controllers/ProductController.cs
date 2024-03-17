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
    public class ProductController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Product

        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }


        [Authorize]
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.v=values;
            return View();


        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            p.IsActive = true;

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
            context.Products.Add(p);
            context.SaveChanges();

            // Redirect to the product list page
            return RedirectToAction("ProductList");
        }

        [Authorize]
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [Authorize]
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value=context.Products.Find(id);    

            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.v = categories;
            return View(value);


        }

        [Authorize]
        public ActionResult UpdateProduct(Product p)
        {
            var value = context.Products.Find(p.ProductId);
            value.IsActive = true;
            value.ProductName = p.ProductName;
            value.ImageUrl=p.ImageUrl;
            value.Price= p.Price;
            value.Description=p.Description;
            value.CategoryId = p.CategoryId;
            context.SaveChanges();
            return RedirectToAction("ProductList");


        }


    }
}