using Orion.Dtos;
using Orion.Models;
using Orion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orion.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateBookRentals(BookRentalDto newRental)
        {

           
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            var books = _context.Book.Where(
               b => newRental.BooksIds.Contains(b.Id)).ToList();

            foreach (var book in books)
            {
                if (book.NumberInStock == 0)
                    return BadRequest("Book is not available.");

                book.NumberInStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }

    }
}
