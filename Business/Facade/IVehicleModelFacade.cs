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
        void Incluir(VehicleModel vehicle);

        List<VehicleModel> ListarTodos();

        void Atualizar(VehicleModel vehicle);

        void Excluir(int id);
    }
}
