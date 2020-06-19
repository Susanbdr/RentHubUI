using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using RentHub.Dtos;
using RentHub.Models;
using RentHub.Models.BusinessModels;

namespace RentHub.Controllers.APIController
{
    public class GenresController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/genres
        [HttpGet]
        public IHttpActionResult GetGenres()
        {
            return Ok(_context.Genres.ToList().Select(Mapper.Map<Genre, GenreDto>));
        }

        // GET /api/genres/1
        [HttpGet]
        public IHttpActionResult GetGenre(byte id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genre == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Genre, GenreDto>(genre));
        }

        // POST /api/genres
        [HttpPost]
        public IHttpActionResult CreateGenre(GenreDto genreDto)
        {
           if(!ModelState.IsValid)
               throw new HttpResponseException(HttpStatusCode.BadRequest);

           var genre = Mapper.Map<GenreDto, Genre>(genreDto);
           _context.Genres.Add(genre);
           _context.SaveChanges();

           return Created(new Uri(Request.RequestUri + "/" + genre.Id), genreDto);
        }

        // PUT /api/genres/1
        [HttpPut]
        public IHttpActionResult UpdateGenre(byte id, GenreDto genreDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genreInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(genreDto, genreInDb);

            _context.SaveChanges();

            return Ok(genreDto);
        }

        // DELETE /api/genres/i
        [HttpDelete]
        public IHttpActionResult DeleteGenre(byte id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);

            if(genreInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Genres.Remove(genreInDb);

            return Ok(_context.SaveChanges());
        }
    }
}
