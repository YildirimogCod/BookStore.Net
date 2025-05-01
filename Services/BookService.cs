using Models;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookService:IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _unitOfWork.BookRepository.FindAll();

        }

        public Book GetBookById(int id)
        {
            return _unitOfWork.BookRepository.GetOneBook(id);
        }

        public Book AddBook(Book book)
        {
            _unitOfWork.BookRepository.Create(book);
            _unitOfWork.Save();
            return book;
        }

        public void UpdateBook(int id,Book book)
        {
            var entity = _unitOfWork.BookRepository.GetOneBook(id);
            if (entity != null)
            {
                entity.Title = book.Title;
                entity.Price = book.Price;
                _unitOfWork.BookRepository.Update(entity);
                _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Book not found");
            }

        }

        public void DeleteBook(int id)
        {
            var entity = _unitOfWork.BookRepository.GetOneBook(id);
            if (entity != null)
            {
                _unitOfWork.BookRepository.Delete(entity);
                _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}
