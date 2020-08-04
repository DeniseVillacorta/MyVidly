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
    public class CustomerController : Controller
    {
        private DatabaseContext _context;
        public CustomerController()
        {
            _context = new DatabaseContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
        public ViewResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.CustomerBday = customer.CustomerBday;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            return View("CustomerForm", viewModel);
        }

       
        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customers == null)

                return HttpNotFound();
            else
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customers,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);

        }
    }
}
