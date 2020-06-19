using System;
using System.Linq;
using System.Web.Http;
using RentHub.Dtos;
using RentHub.Models;
using RentHub.Models.BusinessModels;

namespace RentHub.Controllers.APIController
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
