using Business.Interfaces;
using Domain.Models;

namespace Business.Facade
{
    public class VehicleModelFacade : Facade<VehicleModel>, IVehicleModelFacade
    {
        private readonly IVehicleModelService _vehicleModelService;
        public VehicleModelFacade(IVehicleModelService  vehicleModelService) : base(vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        public void Atualizar(VehicleModel vehicle)
        {
            _vehicleModelService.Update(vehicle);
        }

        public void Excluir(int id)
        {
            _vehicleModelService.Delete(id);
        }

        public void Incluir(VehicleModel vehicle)
        {
            _vehicleModelService.Insert(vehicle);
        }

        public List<VehicleModel> ListarTodos()
        {
            return _vehicleModelService.SelectAll().ToList();
        }
    }
}
