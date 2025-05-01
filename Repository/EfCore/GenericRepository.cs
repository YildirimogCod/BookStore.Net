using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.EfCore
{
    public abstract class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
