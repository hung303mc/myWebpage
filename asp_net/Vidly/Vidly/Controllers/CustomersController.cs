using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using NUnit.Framework;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        #region private_variable
        private ApplicationDbContext _context;
        #endregion

        #region public_method
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                // Simply Get receive information from customer, 
                // -> return again in form
                var viewModel = new NewCustomersViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", viewModel);
            }

            if (customer.Id == 0)
            {
                // similar 'git add'
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            // similar 'git commit'
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            // Entity Framework will not excute querry at this code
            // it's dereference excution
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomersViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomersViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        #endregion

        #region TDD

        [TestFixture]
        [Category("Category_for_test_fixture")]
        class Test
        {
            [SetUp]
            public void Setup()
            {
                // do nothing
            }

            [Test]
            [Category("category_for_test1")]
            public void Test1()
            {
                Assert.Pass("Just test Unit");
            }

            [Test]
            [Category("category_for_test2")]
            public void Test2()
            {
                Assert.AreEqual(0, 1, "Just test NUnit");
                Assert.Fail("Just test Unit");
            }


        }
        #endregion

    }
}