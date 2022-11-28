using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facade
{
    public interface IVehicleModelFacade : IFacade<VehicleModel>
    {
        VehicleModel Incluir(VehicleModel vehicle);

        List<VehicleModel> Listar();

        VehicleModel Atualizar(VehicleModel vehicle);

        bool Excluir(int id);
    }
}
