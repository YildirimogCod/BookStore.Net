using Models;

namespace Repository.Contracts
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);
        Book GetOneBook(int id);
    }
}
