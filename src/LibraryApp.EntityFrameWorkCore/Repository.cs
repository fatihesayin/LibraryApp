using System.Linq.Expressions;
using LibraryApp.Domain;
using LibraryApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.EntityFrameWorkCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet; 
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }
        public void Insert(IEnumerable<TEntity> entity)
        {
            _dbSet.AddRange(entity);
        }
        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
        public async Task<TEntity?> Get(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(o => o.Id == id && o.IsActive);
        }
        public async Task<IEnumerable<TEntity>> GetList()
        {
            return await _dbSet.ToListAsync();
        }
        public void Delete(TEntity entity)
        {
            entity.Delete();
            _dbSet.Update(entity);
        }
        public async Task Delete(Guid id)
        {
            TEntity? entity = await Get(id);
            if(entity == null)
                throw new ApplicationException("Has already deleted or not found");
            entity.Delete();
            _dbSet.Update(entity);
        }
    }
}