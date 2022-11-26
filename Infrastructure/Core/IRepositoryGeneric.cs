using System.Linq.Expressions;

namespace Infrastructure.Core
{
    public interface IRepositoryGeneric<T> : IDisposable where T : class
    {

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Delete(Expression<Func<T, bool>> predicate);
        T Find(params object[] Keys);
        T Find(Expression<Func<T, bool>> where);
        IQueryable<T> Select(Expression<Func<T, bool>> predicate);
        IQueryable<T> SelectAll();

        T SelectById(object id);

        Task<List<T>> SelectAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> SelectAsyncAll();
        Task<T> SelectAsyncById(object id);

        int Save();
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetIncluding(params Expression<Func<T, object>>[] includeProperties);

    }
}
