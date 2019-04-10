using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Index
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();                        

            return View(movies);
        }

        public ActionResult Detail(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
    }
}