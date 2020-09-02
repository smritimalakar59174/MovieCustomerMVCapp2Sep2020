using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerWithAuthMVC_app.Models.ViewModel;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Net;


namespace MovieCustomerWithAuthMVC_app.Controllers
{
    public class MoviesController : Controller
    {
        
        private ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var mov = _context.Movies.Include(c => c.Genre).ToList();
            return View(mov);
        }
        public ActionResult Details(int id)
        {
            var singleMovie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (singleMovie == null)
            {
                return HttpNotFound();
            }
            return View(singleMovie);
        }
        [HttpGet]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genre
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public ActionResult Create(Movie movie)//Model binding
        //{
        //    _context.Movies.Add(movie);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("New", viewModel);
            }
                if (movie.Id == 0) _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.GenreId = movie.GenreId;
                
                 
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var updateMov = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (updateMov == null)
            {
                return HttpNotFound();
            }
            var vm = new NewMovieViewModel
            {
                Movie = updateMov,
                Genres = _context.Genres.ToList()
            };
            return View("New", vm);
        }
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var movieTbl = _context.Movies.Find(id);
        //    _context.Movies.Remove(movieTbl);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}