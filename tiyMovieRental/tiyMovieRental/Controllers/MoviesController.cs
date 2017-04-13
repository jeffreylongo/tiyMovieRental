using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}