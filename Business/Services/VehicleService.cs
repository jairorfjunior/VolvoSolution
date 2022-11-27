using Business.Core;
using Business.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Business.Services
{
    public class VehicleService : ServiceGeneric<Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _rep;
        private readonly ILogger _logger;
        public VehicleService(IVehicleRepository repository, ILogger<VehicleService> logger) : base(repository)
        {
            _rep = repository;
            _logger = logger;
        }
    }
}
