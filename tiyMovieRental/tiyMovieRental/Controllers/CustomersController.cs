using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiyMovieRental.Models;
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
        
        //this is my get for my putpost. 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //add new customer
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newCustomer = new Customers
            {
                Name = collection["Name"],
                PhoneNumber = int.Parse(collection["PhoneNumber"]),
                Email = collection["Email"],

            };
            new CustomersServices().AddCustomer(newCustomer);
            return RedirectToAction("Index");
        }
    }

}