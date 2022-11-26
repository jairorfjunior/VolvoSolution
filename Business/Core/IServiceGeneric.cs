using System.Linq.Expressions;

namespace Business.Core
{
    public interface IServiceGeneric<T> : IDisposable where T : class
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

        Task<List<T>> SelectAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> SelectAsyncAll();
        Task<T> SelectAsyncById(object id);
        T SelectById(object id);
        Int32 Save();
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetIncluding(params Expression<Func<T, object>>[] includeProperties);

    }

}
