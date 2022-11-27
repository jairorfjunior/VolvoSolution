using Business.Core;
using Business.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Business.Services
{
    public class VehicleModelService : ServiceGeneric<VehicleModel>, IVehicleModelService
    {
        private readonly IVehicleModelRepository _rep;
        
        public VehicleModelService(IVehicleModelRepository repository) : base(repository)
        {
            _rep = repository;
        
        }
    }
}
