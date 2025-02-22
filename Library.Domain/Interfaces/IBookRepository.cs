
using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync(); 

    }
}
