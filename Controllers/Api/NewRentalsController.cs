using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Domain;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private DatabaseContext _context;
        public NewRentalsController()
        {
            _context = new DatabaseContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(int customerId, int movieId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);
            var movies = _context.Movies.Where(m => m.ID == (movieId)).ToList();

            foreach(var movie in movies)
            {
                if (movie.NumberOfStock == 0)
                    return BadRequest("Movie is not available.");

                
                var rental = new NewRentals
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.NewRentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
