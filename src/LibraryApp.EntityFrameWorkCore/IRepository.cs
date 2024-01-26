using System.Linq.Expressions;
using LibraryApp.Domain;

namespace LibraryApp.EntityFrameWorkCore
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> Get(Guid id);
        Task<IEnumerable<TEntity>> GetList();
        IQueryable<TEntity> GetQueryable();
        void Delete(TEntity entity);
        Task Delete(Guid id);
    }
}