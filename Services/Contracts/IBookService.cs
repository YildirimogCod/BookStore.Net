using Models;
using Models.Dtos;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddBook(Book book);
        void UpdateBook(int id,UpdateBookRequest updateBook);
        void DeleteBook(int id);
    }
}
