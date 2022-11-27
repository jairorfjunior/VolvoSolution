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

        public Vehicle Atualizar(Vehicle vehicle)
        {
            _vehicleService.Update(vehicle);

            return vehicle;
           
        }

        public bool Excluir(int id)
        {
            try
            {
                _vehicleService.Delete(id);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public Vehicle Incluir(Vehicle vehicle)
        {
            try
            {

                vehicle.VehicleModels = _vehicleModelService.Find(x => x.Id == vehicle.IdVehicleModel);

                if(vehicle.VehicleModels == null)
                    throw new InvalidOperationException("Não foi encontrado o modelo do veículo");                

                _vehicleService.Insert(vehicle);

                var result = _vehicleService.SelectAll().ToList().LastOrDefault();

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new Vehicle();
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Vehicle> Listar()
        {
            try
            {
                var result = _vehicleService.SelectAll().ToList();

                if(result != null)
                {
                    return result;
                }
                else
                {
                    return new List<Vehicle>();
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
