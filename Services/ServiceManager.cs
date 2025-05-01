using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _bookService = new Lazy<IBookService>(() => new BookService(unitOfWork));

        }
        public IBookService BookService => _bookService.Value;
    }
}
