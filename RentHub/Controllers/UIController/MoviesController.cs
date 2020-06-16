using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHub.Models;
using RentHub.ViewModels;

namespace RentHub.Controllers.UIController
{
    public class MoviesController : Controller
    {

        private readonly DataHouseContext _context;

        public MoviesController()
        {
            _context = new DataHouseContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = GetMovieById(movie.Id);
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            if (GetMovieById(id) == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel(GetMovieById(id))
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            if (GetMovieById(id) == null)
                return HttpNotFound();

            _context.Movies.Remove(GetMovieById(id));
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        private Movie GetMovieById(int id)
        {
            return _context.Movies.Single(m => m.Id == id);
        }

       
    }
}