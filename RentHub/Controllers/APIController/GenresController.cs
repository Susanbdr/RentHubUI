using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using RentHub.Models;

namespace RentHub.Controllers.APIController
{
    public class GenresController : ApiController
    {
        private readonly DataHouseContext _context;

        public GenresController()
        {
            _context = new DataHouseContext();
        }

        // GET /api/genres
        [HttpGet]
        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        // GET /api/genres/1
        [HttpGet]
        public Genre GetGenre(byte id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genre == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return genre;
        }

        // POST /api/genres
        [HttpPost]
        public Genre CreateGenre(Genre genre)
        {
           if(!ModelState.IsValid)
               throw new HttpResponseException(HttpStatusCode.BadRequest);

           _context.Genres.Add(genre);
           _context.SaveChanges();

           return genre;
        }

        // PUT /api/genres/1
        [HttpPut]
        public Genre UpdateGenre(byte id, Genre genre)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genreInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            genreInDb.Name = genre.Name;

            _context.SaveChanges();

            return genre;
        }

        // DELETE /api/genres/i
        [HttpDelete]
        public Genre DeleteGenre(byte id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genreInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Genres.Remove(genreInDb);
            _context.SaveChanges();

            return genreInDb;
        }
    }
}
