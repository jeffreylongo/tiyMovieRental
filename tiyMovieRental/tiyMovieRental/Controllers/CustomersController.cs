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

        //get customer for edit. 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = new CustomersServices().GetCustomer(id);
            return View(customer);
        }

        //edit customer
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var updatedCustomer = new Customers
            {
                Name = collection["Name"],
                PhoneNumber = int.Parse(collection["PhoneNumber"]),
                Email = collection["Email"],
                Id = id
            };
            //save to database
            //display correct page. 
            new CustomersServices().EditCustomer(updatedCustomer, id);
            return RedirectToAction("Index");
        }

        //get customer for delete. 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = new CustomersServices().GetCustomer(id);
            return View(customer);
        }

        //delete customer
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            new CustomersServices().DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }

}