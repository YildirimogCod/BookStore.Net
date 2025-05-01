using Models;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddBook(Book book);
        void UpdateBook(int id,Book book);
        void DeleteBook(int id);
    }
}
