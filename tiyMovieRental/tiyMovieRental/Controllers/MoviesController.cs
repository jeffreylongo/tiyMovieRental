using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tiyMovieRental.Models;
using tiyMovieRental.Services;

namespace tiyMovieRental.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            //get all gifts
            var movies = new MoviesServices().GetAllMovies();
            //pass them to the view
            return View(movies);
        }

        //this is my get for my putpost. 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //add new movie
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            var newMovie = new Movies
            {
                Name = collection["Name"],
                YearReleased = int.Parse(collection["YearReleased"]),
                Director = collection["Director"],
                GenreId = int.Parse(collection["GenreId"]),

            };
            // TODO: Put into db
            new MoviesServices().AddMovie(newMovie);
            return RedirectToAction("Index");
        }
    }
}