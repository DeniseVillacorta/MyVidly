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

        public ViewResult Index()
        {
           var indexMovies = _context.Movies.Include(m => m.Genre).ToList();
            return View (indexMovies);
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



