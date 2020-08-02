using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View (movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
               new Movie {MovieName = "Harry Potter"},
               new Movie {MovieName = "Home Alone"}
            };

        }

        public ActionResult Random()
        {
            return View();
        }
    }
}



