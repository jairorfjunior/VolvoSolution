using Business.Core;
using Business.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Business.Services
{
    public class VehicleService : ServiceGeneric<Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _rep;
        public VehicleService(IVehicleRepository repository) : base(repository)
        {
            _rep = repository;
        }
    }
}
