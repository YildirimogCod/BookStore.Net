using AutoMapper;
using Models;
using Models.Dtos;
using Models.Exceptions;
using NLog;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookService:IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggingService _logger;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork,ILoggingService logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
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

        public void UpdateBook(int id,UpdateBookRequest updateBook)
        {
            var entity = _unitOfWork.BookRepository.GetOneBook(id);
            if (entity == null)
                throw new BookNotFoundException(id);
            _mapper.Map<Book>(entity);
            _unitOfWork.BookRepository.Update(entity);
                _unitOfWork.Save();
               
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

