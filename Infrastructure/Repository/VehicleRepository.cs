using Domain.Models;
using Infrastructure.Contexts;
using Infrastructure.Core;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public class VehicleRepository : RepositoryGeneric<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VolvoContext context) : base(context)
        {
        }
    }
}
