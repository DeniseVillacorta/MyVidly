using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Domain;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private DatabaseContext _context;
        public MovieController()
        {
            _context = new DatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.ID == 0)
            {
                _context.Movies.Add(movie);
                movie.DateAdded = DateTime.Now;
            }

            else
            {
                var movieInDB = _context.Movies.Single(c => c.ID == movie.ID);

                movieInDB.Name = movie.Name;
                movieInDB.ReleasedDate = movie.ReleasedDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberOfStock = movie.NumberOfStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }


        public ActionResult New()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new MovieViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.ID == id);

            if (movie == null)

                return HttpNotFound();
            else
            {
                var viewModel = new MovieViewModel(movie)
                {
                   
                    Genres = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }

        public ActionResult Details(int id)
        {
            
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);

            if (movie == null)
                
               return HttpNotFound();
                      
            return View(movie);

        }
        public ActionResult Random()
        {
            return View();
        }
    }
}



