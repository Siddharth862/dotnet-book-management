using Dal_Book;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal_Book.Services
{
    // Made the class public and implemented the interface
    public class BookService : IBookService
    {
        private readonly BookContext _context;

        public BookService(BookContext context)
        {
            _context = context;
        }

        // Add a new book asynchronously
        public async Task<int> AddBook(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync();
        }

        // Delete a book by its ID asynchronously
        public async Task<int> DeleteBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null)
                return 0; // Or throw an exception

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync();
        }

        // Get a single book by its ID asynchronously
        // Returns a nullable Book? because FirstOrDefaultAsync can return null
        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
        }

        // Get all books asynchronously
        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // Update an existing book asynchronously
        public async Task<int> UpdateBook(Book book, int id)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (existingBook == null)
                return 0; // Or throw an exception

            // Update properties from the incoming book object
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.Price = book.Price;

            return await _context.SaveChangesAsync();
        }
    }
}