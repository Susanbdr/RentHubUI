using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentHub.Models;
using RentHub.ViewModels;

namespace RentHub.Controllers.UIController
{
    public class GenresController : Controller
    {
        private readonly DataHouseContext _context;

        public GenresController()
        {
            _context = new DataHouseContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Genres
        public ActionResult Index()
        {
            return View(ListOfGenres());
        }

        public ActionResult New()
        {
            var viewModel = new GenreViewModel
            {
                Genre = new Genre()
            };

            return View("GenreForm", viewModel);
        }

        private List<Genre> ListOfGenres()
        {
            return _context.Genres.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GenreViewModel
                {
                    Genre = genre
                };

                return View("GenreForm", viewModel);
            }

            if(genre.Id == 0)
                _context.Genres.Add(genre);
            else
            {
                var genreInDb = GetGenreById(genre.Id);
                genreInDb.Name = genre.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }

        public ActionResult Edit(byte id)
        {
            if (GetGenreById(id) == null)
                return HttpNotFound();

            var viewModel = new GenreViewModel
            {
                Genre = GetGenreById(id)
            };

            return View("GenreForm", viewModel);
        }

        public ActionResult Delete(byte id)
        {
            if (GetGenreById(id) == null)
                return HttpNotFound();

            _context.Genres.Remove(GetGenreById(id));
            _context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }

        private Genre GetGenreById(byte id)
        {
            return _context.Genres.Single(g => g.Id == id);
        }
    }
}