using Infrastructure.Core;
using System.Linq.Expressions;

namespace Business.Core
{

    public class ServiceGeneric<TEntity> : IServiceGeneric<TEntity> where TEntity : class
    {
        private readonly IRepositoryGeneric<TEntity> _repository;

        public ServiceGeneric(IRepositoryGeneric<TEntity> repository)
        {
            _repository = repository;
        }

         
        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _repository.Delete(predicate);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public TEntity Find(params object[] Keys)
        {
            return _repository.Find(Keys);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _repository.Find(where);
        }

        public IQueryable<TEntity> GetIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetIncluding(includeProperties);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);

        }
 

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Select(predicate);
        }

        public IQueryable<TEntity> SelectAll()
        {
            return _repository.SelectAll();
        }

        public TEntity SelectById(int id)
        {
            return _repository.SelectById(id);
        }


        public async Task<List<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SelectAsync(predicate);
        }

        public async Task<List<TEntity>> SelectAsyncAll()
        {
            return await _repository.SelectAsyncAll();
        }

        public async Task<TEntity> SelectAsyncById(object id)
        {
            return await _repository.SelectAsyncById(id);
        }
    }

}
