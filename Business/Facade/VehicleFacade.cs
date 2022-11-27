using Business.Core;
using Business.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facade
{
    public class VehicleFacade : Facade<Vehicle>, IVehicleFacade
    {
        private readonly IVehicleService _vehicleService;
        private readonly IVehicleModelService _vehicleModelService;
        public VehicleFacade(IVehicleService vehicleService, IVehicleModelService vehicleModelService) : base(vehicleService)
        {
            _vehicleService = vehicleService;
            _vehicleModelService = vehicleModelService;
        }

        public void Atualizar(Vehicle vehicle)
        {
            _vehicleService.Update(vehicle);
           
        }

        public void Excluir(int id)
        {
            _vehicleService.Delete(id);
        }

        public void Incluir(Vehicle vehicle)
        {
            vehicle.VehicleModels = _vehicleModelService.Find(x => x.Id == vehicle.IdVehicleModel);
            _vehicleService.Insert(vehicle);
        }

        public List<Vehicle> ListarTodos()
        {
            return _vehicleService.SelectAll().ToList();
        }
    }
}
