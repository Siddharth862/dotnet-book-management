using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal_Book.Services
{
    // This is the ASYNC version of the interface
    public interface IBookService
    {
        Task<List<Book>> GetBooks();

        Task<Book?> GetBookById(int id);

        Task<int> AddBook(Book book);

        Task<int> UpdateBook(Book book, int id);

        Task<int> DeleteBook(int id);
    }
}