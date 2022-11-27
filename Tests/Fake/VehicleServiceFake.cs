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
    public class VehicleServiceFake : IVehicleService
    {
        private readonly List<Vehicle> _vehicles;
        public VehicleServiceFake()
        {
            _vehicles = new List<Vehicle>()
            {
                new Vehicle()
                {
                     Id = 1,  IdVehicleModel = 1, VehicleDescription = "Teste"
                },
                new Vehicle()
                {
                     Id = 2, IdVehicleModel = 2 , VehicleDescription  = "Teste2"
                }
            };
        }

        public int Count()
        {
            return _vehicles.Count();  
        }

        public int Count(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _vehicles.Find(t=> t.Id == id);
        }

        public void Delete(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Vehicle Find(params object[] Keys)
        {
            throw new NotImplementedException();
        }

        public Vehicle Find(Expression<Func<Vehicle, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vehicle> GetIncluding(params Expression<Func<Vehicle, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle entity)
        {
            entity.Id = GeraId();
            _vehicles.Add(entity);
           
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vehicle> Select(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vehicle> SelectAll()
        {
            return _vehicles.AsQueryable();
        }

        public Task<List<Vehicle>> SelectAsync(Expression<Func<Vehicle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> SelectAsyncAll()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> SelectAsyncById(object id)
        {
            throw new NotImplementedException();
        }

        public Vehicle SelectById(int id)
        {
            var result = _vehicles.Where(x => x.Id == id).FirstOrDefault();

            if(result != null)
            {
                return result;
            }
            else
            {
                return new Vehicle();
            }
        }

        public void Update(Vehicle entity)
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
