using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentHub.Models;

namespace RentHub.Controllers.APIController
{
    public class MoviesController : ApiController
    {
        private readonly DataHouseContext _context;

        public MoviesController()
        {
            _context = new DataHouseContext();
        }

        // GET /api/movies
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }


        // GET /api/movies/1
        [HttpGet]
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movie;
        }

        // POST /api/movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        // PUT /api/movies?id=1
        [HttpPut]
        public Movie UpdateMovie(int id, Movie movie)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

            return movie;
        }

        // DELETE /api/movie?id=1
        [HttpDelete]
        public Movie DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return movieInDb;
        }
    }
}
