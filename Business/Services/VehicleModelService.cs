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
        private readonly ILogger _logger; 
        public VehicleModelService(IVehicleModelRepository repository, ILogger<VehicleModelService> logger) : base(repository)
        {
            _rep = repository;
            _logger = logger;
        }
    }
}
