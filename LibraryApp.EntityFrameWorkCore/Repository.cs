using System.Linq.Expressions;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.EntityFrameworkCore
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Insert(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }
        public IEnumerable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public async Task<T?> Get(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }
        public async Task<T?> Get(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(o => o.Id == id && o.IsActive);
        }
        public async Task<IEnumerable<T>> GetList()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public void Delete(T entity)
        {
            entity.Delete();
            _context.Set<T>().Update(entity);
        }
        public async Task Delete(Guid id)
        {
            T? entity = await Get(id);
            if(entity == null)
                throw new ApplicationException("Has already deleted or not found");
            entity.Delete();
            _context.Set<T>().Update(entity);
        }
    }
}