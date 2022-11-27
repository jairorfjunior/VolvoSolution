using Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facade
{
    public interface IFacade<T> : IDisposable where T : class
    {
        void Insert(T entity);
        void Update(T entity);

        void Delete(int id);
        void Delete(Expression<Func<T, bool>> predicate);
        T Find(params object[] Keys);
        T Find(Expression<Func<T, bool>> where);
        IQueryable<T> Select(Expression<Func<T, bool>> predicate);
        IQueryable<T> SelectAll();

        T SelectById(int id);
     
    }
}
