using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

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
            var movies = _context.Movies.Include(c => c.Genre).ToList();                        

            return View(movies);
        }

        public ActionResult Detail(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var newModel = new NewMoviesViewModel()
            {
                Movie = movie,
                Genre = _context.Genres.ToList()
            };

            return View("New", newModel);
        }
        public ActionResult New()
        {
            var oGenres = _context.Genres.ToList();
            var viewModel = new NewMoviesViewModel
            {
                Movie = new Movie(),
                Genre = oGenres
            };
            return View(viewModel);
        }

        [HttpPost]
        public  ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                // simply return input info from form
                var newModel = new NewMoviesViewModel()
                {
                    Movie = movie,
                    Genre = _context.Genres.ToList()
                };
                return View("New", newModel);
            }
            
            // New
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var currentMovie = _context.Movies.Single(m => m.Id == movie.Id);
                currentMovie.Name = movie.Name;
                currentMovie.GenreId = movie.GenreId;
                currentMovie.ReleaseDate = movie.ReleaseDate;
                currentMovie.NumInStock = movie.NumInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}