using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return Content("U have authorization to access User from admin right!!!");
        }
    }
}