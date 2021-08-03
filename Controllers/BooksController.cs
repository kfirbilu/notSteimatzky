using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;
using System.Security.Cryptography.X509Certificates;
using BooksStore.Tweeter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using BooksStore.Tweeter;
using BooksStore.Views.Books;
using Tweetinvi.Parameters;

namespace BooksStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksStoreContext _context;

        //The paths to the images
        private const string _staticImagesRoute = "wwwroot/img/";

        public BooksController(BooksStoreContext context)
        {
            _context = context;
        }


        // GET: Books
        public async Task<IActionResult> Index()
        {
            var booksContext = _context.Books.Include(b => b.Genre);
            return View(await booksContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName");
            return View();
        }





        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, [Bind("BookId,BookName,Author,Publication,Price,Summary,PictureName,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("", "You must enter book picture");
                }
                else if (GetAllBooks.Where(b => b.BookName == book.BookName).Count() == 0)
                {
                    // get the image name and save the path to the saved pictures
                    var filePath = _staticImagesRoute + file.FileName;

                    // save the image name to the pictureName property so we get it later for the view
                    book.PictureName = "/img/" + file.FileName;

                    // save the picture to the static path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // save book
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    
                    

                    // Tweet to Twitter
                    Tweeter.Twitter twitter = new Twitter(Twitter.APIkeycon, Twitter.APIsecretKeycon, Twitter.AccessToken,
                        Twitter.AccessTokenSecret);
                    twitter.TweetText("Check out our new book!! -> " + book.BookName, string.Empty);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "The book already exist");
                }

            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreId", "GenreName", book.GenreId);
            return View(book);
        }





        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", book.GenreId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, byte[] rowVersion, [Bind("BookId,BookName,Author,Publication,Price,Summary,PictureName,GenreId")] Book book, IFormFile file)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // case the user put new image to update
                if (file != null)
                {
                    // Set full path to file 
                    string FileToDelete = _staticImagesRoute + book.PictureName,
                           fileToUpdate = _staticImagesRoute + file.FileName;

                    // put the new picture name to product object
                    book.PictureName = "/img/" + file.FileName;

                    // save the picture to the static path
                    using (var stream = new FileStream(fileToUpdate, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }


                var bookToUpdate = await _context.Books.FindAsync(id);

                if (bookToUpdate == null)
                {
                    Book deletedBook = new Book();
                    await TryUpdateModelAsync(deletedBook);
                    ModelState.AddModelError(string.Empty,
                        "Unable to save changes. The book was deleted by another user.");
                    ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", deletedBook.GenreId);
                    return View(deletedBook);
                }

                _context.Entry(bookToUpdate).Property("RowVersion").OriginalValue = rowVersion;

                if (await TryUpdateModelAsync<Book>(
                    bookToUpdate,
                    "",
                    s => s.BookName, s => s.Author, s => s.Price, s => s.GenreId, s => s.Publication, s => s.Summary))
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        var exceptionEntry = ex.Entries.Single();
                        var clientValues = (Book)exceptionEntry.Entity;
                        var databaseEntry = exceptionEntry.GetDatabaseValues();
                        if (databaseEntry == null)
                        {
                            ModelState.AddModelError(string.Empty,
                                "Unable to save changes. The book was deleted by another user.");
                        }
                        else
                        {
                            var databaseValues = (Book)databaseEntry.ToObject();

                            if (databaseValues.BookName != clientValues.BookName)
                            {
                                ModelState.AddModelError("Name", $"Current value: {databaseValues.BookName}");
                            }
                            if (databaseValues.Price != clientValues.Price)
                            {
                                ModelState.AddModelError("Price", $"Current value: {databaseValues.Price:c}");
                            }

                            if (databaseValues.Publication != clientValues.Publication)
                            {
                                ModelState.AddModelError("Publication", $"Current value: {databaseValues.Publication:e}");
                            }
                            if (databaseValues.Summary != clientValues.Summary)
                            {
                                ModelState.AddModelError("Summary", $"Current value: {databaseValues.Summary:f}");
                            }

                            if (databaseValues.Genre != clientValues.Genre)
                            {
                                Genre databaseGenre = await _context.Genres.FirstOrDefaultAsync(i => i.GenreId == databaseValues.GenreId);
                                ModelState.AddModelError("GenreName", $"Current value: {databaseGenre?.GenreName}");
                            }

                            ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                    + "was modified by another user after you got the original value. The "
                                    + "edit operation was canceled and the current values in the database "
                                    + "have been displayed. If you still want to edit this record, click "
                                    + "the Save button again. Otherwise click the Back to List hyperlink.");
                            bookToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                            ModelState.Remove("RowVersion");
                        }
                    }
                }
                ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", bookToUpdate.GenreId);
                return View(bookToUpdate);
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", book.GenreId);
            return View(book);
        }

        public IActionResult List(string genreName)
        {
            IEnumerable<Book> books;
            string currentGenre;

            if (string.IsNullOrEmpty(genreName))
            {
                books = GetAllBooks.OrderBy(c => c.BookId);
                currentGenre = "All Genre";
            }

            else
            {
                books = GetAllBooks.Where(c => c.Genre.GenreName == genreName);
                currentGenre = _context.Genres.FirstOrDefault(c => c.GenreName == genreName)?.GenreName;
            }

            return View(new BookListView 
            {
                Books = books,
                CurrentGenre = currentGenre
            });
        }

        public async Task<IActionResult> SearchAutoComplete(string term)
        {
            var query = from p in _context.Books
                        where p.BookName.Contains(term)
                        select new { id = p.BookId, label = p.BookName, value = p.BookName };

            return Json(await query.ToListAsync());
        }

        public IActionResult SearchTerm(string term)
        {
            var query = from p in _context.Books
                        where p.BookName.Contains(term)
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListView
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult SearchAuthor(string author)
        {
            var query = from p in _context.Books
                        where p.Author.Contains(author)
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListView 
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult SearchPublication(string publication)
        {
            var query = from p in _context.Books
                        where p.Publication.Contains(publication)
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListView 
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult SearchUnderPrice(double price)
        {
            var query = from p in _context.Books
                        where p.Price <= price
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListView 
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult ViewBook(int bookId)
        {
            IEnumerable<Book> books = GetAllBooks.Where(b => b.BookId == bookId);

            return View("List", new BookListView 
            {
                Books = books,
                CurrentGenre = "Search Results"
            });
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre).AsNoTracking()
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }

            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "The record you attempted to delete "
                    + "was modified by another user after you got the original values. "
                    + "The delete operation was canceled and the current values in the "
                    + "database have been displayed. If you still want to delete this "
                    + "record, click the Delete button again. Otherwise "
                    + "click the Back to List hyperlink.";
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Book book)
        {
            try
            {
                if (await _context.Books.AnyAsync(m => m.BookId == book.BookId))
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = book.BookId });
            }
        }



        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }


        // Gets all the books from the DB

        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                return _context.Books.Include(c => c.Genre);
            }
        }

    }
}
