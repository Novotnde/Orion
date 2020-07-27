using AutoMapper;
using Orion.Dtos;
using Orion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using Orion.Services;

namespace Orion.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<BookDto> GetBooks(string query = null)
        {
            var bookQuery = _context.Book
                .Include(m => m.Genre)
                .Where(m => m.NumberInStock > 0);

            if (!String.IsNullOrWhiteSpace(query))
                bookQuery = bookQuery.Where(m => m.Title.Contains(query));

            return bookQuery
                .ToList().
               Select(Mapper.Map<Book, BookDto>);
        }
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);
            if (book == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Book.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<BookDto, Book>(bookDto, bookInDb);
            bookInDb.Title = bookDto.Title;
            bookInDb.PublishedDate = bookDto.PublishedDate;
            bookInDb.NumberInStock = bookDto.NumberInStock;
            bookInDb.GenreId = bookDto.GenreId;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Book.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Book.Remove(bookInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}