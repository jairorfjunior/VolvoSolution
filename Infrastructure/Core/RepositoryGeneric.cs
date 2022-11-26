
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Core
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {


        protected readonly VolvoContext _dbContexto;


        /// <summary>
        /// Construtor com passagem de parametro
        /// </summary>
        /// <param name="context"></param>
        public RepositoryGeneric(VolvoContext context)
        {
            _dbContexto = context;


        }

        public void Insert(T entity)
        {
            try
            {
                _dbContexto.Set<T>().Add(entity);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        public void Update(T entity)
        {
            try
            {

                _dbContexto.Set<T>().Update(entity);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void Delete(object id)
        {
            try
            {


                _dbContexto.Set<T>().Remove(SelectById(id));
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var entitiesToDelete = Select(predicate);
            foreach (var entity in entitiesToDelete)
            {
                if (_dbContexto.Entry(entity).State == EntityState.Detached)
                {
                    _dbContexto.Set<T>().Attach(entity);
                }
                _dbContexto.Set<T>().Remove(entity);
            }
        }

        public void Delete(T entity)
        {

            try
            {
                if (_dbContexto.Entry(entity).State == EntityState.Detached)
                {
                    _dbContexto.Set<T>().Attach(entity);
                }

                _dbContexto.Remove(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }




        /// <summary>
        /// Encontrar chaves
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>
        public T Find(params object[] Keys)
        {
            return _dbContexto.Set<T>().Find(Keys);
        }


        /// <summary>
        /// Encontrar o primeiro
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> where)
        {
            return _dbContexto.Set<T>().FirstOrDefault(where);
        }



        public IQueryable<T> Select(Expression<Func<T, bool>> predicate)
        {
            return _dbContexto.Set<T>().Where(predicate).AsQueryable();
        }


        public T SelectById(object id)
        {
            return _dbContexto.Set<T>().Find(id);
        }


        public IQueryable<T> SelectAll()
        {
            return _dbContexto.Set<T>().AsQueryable();
        }

        public int Save()
        {
            return _dbContexto.SaveChanges();
        }



        public int Count()
        {
            return _dbContexto.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbContexto.Set<T>().Count(predicate);
        }

        public void Dispose()
        {
            _dbContexto.Dispose();
        }


        public IQueryable<T> GetIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContexto.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public async Task<List<T>> SelectAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContexto.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> SelectAsyncAll()
        {
            return await _dbContexto.Set<T>().ToListAsync();
        }


        public async Task<T> SelectAsyncById(object id)
        {
            return await _dbContexto.Set<T>().FindAsync(id);
        }

    }
}
