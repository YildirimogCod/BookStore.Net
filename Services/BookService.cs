using Models;
using NLog;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookService:IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggingService _logger;
        public BookService(IUnitOfWork unitOfWork,ILoggingService logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
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
               _logger.Error($"Book with id {id} not found for update");
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
                _logger.Error($"Book with id {id} not found for deletion");
                throw new Exception("Book not found");
            }
        }
    }
}

