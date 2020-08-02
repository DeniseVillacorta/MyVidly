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
        public ActionResult Random()
        {
            var movie = new Movie { MovieName = "Harry Potter" };
            var customer = new List<Customer>
            {
                new Customer {CustomerName = "Denise Villacorta"},
                new Customer {CustomerName = "Ravni Arador"},
            };

            var viewModel = new RandomViewModel
            {
                Movie = movie,
                Customers = customer
            };
            return View(viewModel);
          
        }
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }
    }
}