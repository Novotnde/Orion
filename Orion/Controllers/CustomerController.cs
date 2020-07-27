using Orion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure.MappingViews;
using Orion.ViewModel;
using Orion.Services;

namespace Orion.Controllers
{
    
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomerController()
        { 
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        } 
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),


                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            _context.Customers.Add(customer);
            else
            {
                var custInDB = _context.Customers.Single(c => c.Id == customer.Id);
                custInDB.Name = customer.Name;
                custInDB.Birthdate = customer.Birthdate;
                custInDB.MembershipType = customer.MembershipType;
                custInDB.IsSubscibedToNewsletter = customer.IsSubscibedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Index()
        {
            //var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View();
           
        }
        public ActionResult DetailCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }


    }
}