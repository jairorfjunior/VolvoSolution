using Domain.Models;
using Infrastructure.Contexts;
using Infrastructure.Core;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository
{
    public class VehicleModelRepository : RepositoryGeneric<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(VolvoContext context) : base(context)
        {
        }
    }
}
