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
            new MoviesServices().AddMovie(newMovie);
            return RedirectToAction("Index");
        }

        //get movie for edit. 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = new MoviesServices().GetMovie(id);
            return View(movie);
        }

        //edit movie
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var updatedMovie = new Movies
            {
                Name = collection["Name"],
                YearReleased = int.Parse(collection["YearReleased"]),
                Director = collection["Director"],
                GenreId = int.Parse(collection["GenreId"]),
                Id = id
            };
            //save to database
            //display correct page. 
            new MoviesServices().EditMovie(updatedMovie, id);
            return RedirectToAction("Index");
        }

        //get movie for delete. 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = new MoviesServices().GetMovie(id);
            return View(movie);
        }

        //delete movie
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: fix this
            new MoviesServices().DeleteMovie(id);
            return RedirectToAction("Index");
        }

        //get the movie to check out. 
        [HttpGet]
        public ActionResult Open(int id)
        {
            var movie = new MoviesServices().GetMovie(id);
            return View(movie);
        }

        //post for check out movie
        [HttpPost]
        public ActionResult Open(int id, FormCollection collection)
        {
            new MoviesServices().CheckOutMovie(id);
            return RedirectToAction("Index");
        }
    }
}