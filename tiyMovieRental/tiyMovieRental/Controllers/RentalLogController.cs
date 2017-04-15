using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiyMovieRental.Models;
using tiyMovieRental.Services;

namespace tiyMovieRental.Controllers
{
    public class RentalLogController : Controller
    {
        // GET: Rental Log
        public ActionResult Index()
        {
            //get all logs
            var rentalLog = new RentalLogServices().GetAllMovies();
            //pass them to the view
            return View(rentalLog);
        }

        //this is my get for my putpost. 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //add new rental log
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newRentalLog = new RentalLog
            {
                CustomerId = int.Parse(collection["CustomerId"]),
                MovieId = int.Parse(collection["MovieId"]),
                DateCheckedOut = DateTime.Parse(collection["DateCheckedOut"]),
                DueDate = DateTime.Parse(collection["DueDate"]),

            };
            new RentalLogServices().AddRentalLog(newRentalLog);
            return RedirectToAction("Index");
        }
        //get log for edit. 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var rentalLog = new RentalLogServices().GetRentalLog(id);
            return View(rentalLog);
        }

        //edit log
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var updatedRentalLog = new RentalLog
            {
                CustomerId = int.Parse(collection["CustomerId"]),
                MovieId = int.Parse(collection["MovieId"]),
                DateCheckedOut = DateTime.Parse(collection["DateCheckedOut"]),
                DueDate = DateTime.Parse(collection["DueDate"]),
                Id = id
            };
            //save to database
            //display correct page. 
            new RentalLogServices().EditRentalLog(updatedRentalLog, id);
            return RedirectToAction("Index");
        }
        //get log for delete. 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rentalLog = new RentalLogServices().GetRentalLog(id);
            return View(rentalLog);
        }

        //delete log
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: fix this
            new RentalLogServices().DeleteRentalLog(id);
            return RedirectToAction("Index");
        }
    }
}