using System.Linq.Expressions;
using LibraryApp.Domain;

namespace LibraryApp.EntityFrameworkCore
{
    public interface IRepository<T> where T : BaseEntity 
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entity);
        IEnumerable<T> Search(Expression<Func<T, bool>> expression);
        Task<T?> Get(Expression<Func<T, bool>> expression);
        Task<T?> Get(Guid id);
        Task<IEnumerable<T>> GetList();
        void Delete(T entity);
        Task Delete(Guid id);
    }
}