using Orion.Models;
using Orion.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.Services;

namespace Orion.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookViewModel
                {
                    Book = new Book(),
                    Genres = _context.Genre.ToList(),


                };
                return View("SaveBook", viewModel);
            }
            if (book.Id == 0)
            {
                try
                {
                    book.DateAdded = DateTime.Now;
                    _context.Book.Add(book);
                }
                catch (DbEntityValidationException e)
                {

                    Console.WriteLine(e);
                }
              
            }
            else
            {
                var bookInDB = _context.Book.Single(c => c.Id == book.Id);
                bookInDB.Title = book.Title;
                bookInDB.GenreId = book.GenreId;
                bookInDB.NumberInStock = book.NumberInStock;
                bookInDB.PublishedDate = book.PublishedDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        [Authorize (Roles = RoleName.CanManageBooks)]
        public ViewResult New()
        {
            var genres = _context.Genre.ToList();

            var viewModel = new BookViewModel
            {
                Genres = genres
            };

            return View("SaveBook", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = _context.Book.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookViewModel
            {
                Book = book,
                Genres = _context.Genre.ToList()
            };

            return View("SaveBook", viewModel);
        }


        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBooks))
            {
                return View("Index");
            }
            else
            {
                return View("ReadOnlyIndex");
            }
        
            
        }
        public ActionResult Detail(int id)
        {
            var book = _context.Book.Include(b => b.Genre).SingleOrDefault(m => m.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    }
}