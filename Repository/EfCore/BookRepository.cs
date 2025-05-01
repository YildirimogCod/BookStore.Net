using Models;
using Repository.Contracts;

namespace Repository.EfCore
{
    public class BookRepository:GenericRepository<Book>,IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);

        public void UpdateOneBook(Book book) => Update(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public Book GetOneBook(int id) => FindByCondition(x => x.Id == id).FirstOrDefault();
      
    }
    
}
