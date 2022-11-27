using Business.Core;
using Domain.Models;
using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facade
{
    public class Facade<TEntity> : IFacade<TEntity> where TEntity : class
    {
        private readonly IServiceGeneric<TEntity> _service;

        public Facade(IServiceGeneric<TEntity> service)
        {
            _service = service;
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _service.Delete(predicate);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public TEntity Find(params object[] Keys)
        {
            return _service.Find(Keys);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            _service.Insert(entity);
        }

  
        public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _service.Select(predicate);
        }

        public IQueryable<TEntity> SelectAll()
        {
            return _service.SelectAll();
        }

        public TEntity SelectById(int id)
        {
            return _service.SelectById(id);
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }
    }
}
