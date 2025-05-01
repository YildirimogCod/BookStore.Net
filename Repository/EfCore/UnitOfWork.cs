    using Repository.Contracts;

    namespace Repository.EfCore
    {
        public class UnitOfWork:IUnitOfWork
        {
            private readonly AppDbContext _context;
            private Lazy<IBookRepository> _bookRepository;
            public UnitOfWork(AppDbContext context)
            {
                _context = context;
                _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
            }

            public IBookRepository BookRepository => _bookRepository.Value;
            public void Save()
            {
                _context.SaveChanges(); 
            }
        }
    }
