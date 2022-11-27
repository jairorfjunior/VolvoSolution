using Business.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Fake
{
    public class VehicleModelServiceFake : IVehicleModelService
    {
        private readonly List<VehicleModel> _VehicleModels;
        public VehicleModelServiceFake()
        {
            _VehicleModels = new List<VehicleModel>()
            {
                new VehicleModel()
                {
                     Id = 1,  VehicleModelDescription = "FH"
                },
                new VehicleModel()
                {
                     Id = 2,  VehicleModelDescription  = "FM"
                }
            };
        }

        public int Count()
        {
            return _VehicleModels.Count();
        }

        public int Count(Expression<Func<VehicleModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(VehicleModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _VehicleModels.Find(t => t.Id == id);
        }

        public void Delete(Expression<Func<VehicleModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public VehicleModel Find(params object[] Keys)
        {
            throw new NotImplementedException();
        }

        public VehicleModel Find(Expression<Func<VehicleModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VehicleModel> GetIncluding(params Expression<Func<VehicleModel, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(VehicleModel entity)
        {
            entity.Id = GeraId();
            _VehicleModels.Add(entity);

        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public IQueryable<VehicleModel> Select(Expression<Func<VehicleModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VehicleModel> SelectAll()
        {
            return _VehicleModels.AsQueryable();
        }

        public Task<List<VehicleModel>> SelectAsync(Expression<Func<VehicleModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleModel>> SelectAsyncAll()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> SelectAsyncById(object id)
        {
            throw new NotImplementedException();
        }

        public VehicleModel SelectById(int id)
        {
            var result = _VehicleModels.Where(x => x.Id == id).FirstOrDefault();

            if(result != null)
            {
                return result;
            }
            else
            {
                return new VehicleModel();
            }
        }

        public void Update(VehicleModel entity)
        {
            throw new NotImplementedException();
        }

        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
