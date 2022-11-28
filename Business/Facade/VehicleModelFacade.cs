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

        public VehicleModel Atualizar(VehicleModel vehicle)
        {
            _vehicleModelService.Update(vehicle);

            return vehicle;
        }

        public bool Excluir(int id)
        {
            try
            {
                _vehicleModelService.Delete(id);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public VehicleModel Incluir(VehicleModel vehiclemodel)
        { 
             
            _vehicleModelService.Insert(vehiclemodel);

            var result = _vehicleModelService.SelectAll().LastOrDefault();

            if(result != null)
            {
                return result;
            }
            else
            {
                return new VehicleModel();
            }

            
            
        }

        public List<VehicleModel> Listar()
        {
            return _vehicleModelService.SelectAll().ToList();
        }
    }
}
