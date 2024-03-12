using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TasteFood.Context;
using TasteFood.Entites;

namespace TasteFood.Controllers
{
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var values=context.Admins.FirstOrDefault(x=>x.Username==p.Username&&x.Password==p.Password);
            if(values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, true);
                Session["a"]=values.Username;
                return RedirectToAction("ProductList", "Product");
            }


            return View();
        }
    }
}