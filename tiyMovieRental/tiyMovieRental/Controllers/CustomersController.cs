using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiyMovieRental.Services;

namespace tiyMovieRental.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            //get all customers
            var customers = new CustomersServices().GetAllCustomers();
            //pass them to the view
            return View(customers);
        }
    }
}