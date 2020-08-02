using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ViewResult Index()
        {
            var indexCustomers = GetCustomer();

            return View(indexCustomers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomer().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);


        }
        private IEnumerable<Customer> GetCustomer()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Denise Villacorta"},
                new Customer {Id = 2, Name = "Ravni Arador"},
            };

        }
    }
} 