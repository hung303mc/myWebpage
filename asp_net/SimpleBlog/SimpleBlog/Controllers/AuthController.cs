using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if(form.Username != "Hung303mc")
            {
                ModelState.AddModelError("Username", "Your username is not cool :)");
                return View(form);
            }
            // Pass 'form' into view since it need info from our Models
            return Content("The form is valid");
        }
    }
}