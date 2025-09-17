using Microsoft.AspNetCore.Mvc;
using Dal_Book.Services; // Using the service layer
using Pal_Book.Models;    // Using the ViewModel
using System.Threading.Tasks;
using System.Linq;
using Dal_Book;           // Using the data model

namespace Pal_Book.Controllers
{
    public class BookController : Controller
    {
        // Inject the interface, not the concrete class
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        // Action is now async
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooks();
            var bookViewModels = books.Select(b => new BookViewModel
            {
                BookId = b.BookId,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                Price = b.Price
            }).ToList();
            return View(bookViewModels);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bModel = new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price
            };
            return View(bModel);
        }

        // GET: Book/Create (Renamed for convention)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel bModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bModel);
            }
            var book = new Book
            {
                Title = bModel.Title,
                Author = bModel.Author,
                Genre = bModel.Genre,
                Price = bModel.Price
            };
            await _bookService.AddBook(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bModel = new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price
            };
            return View(bModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel bModel)
        {
            if (id != bModel.BookId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    BookId = bModel.BookId,
                    Title = bModel.Title,
                    Author = bModel.Author,
                    Genre = bModel.Genre,
                    Price = bModel.Price
                };
                await _bookService.UpdateBook(book, id);
                return RedirectToAction(nameof(Index));
            }
            return View(bModel);
        }

        // GET: Book/Delete/5 (Renamed for convention)
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bModel = new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price
            };
            return View(bModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")] // Use ActionName to match the GET method
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}