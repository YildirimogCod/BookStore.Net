using AutoMapper;
using NLog;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        
        public ServiceManager(IUnitOfWork unitOfWork,ILoggingService logger,IMapper mapper)
        {
            _bookService = new Lazy<IBookService>(() => new BookService(unitOfWork,logger,mapper));

        }
        public IBookService BookService => _bookService.Value;
    }
}
