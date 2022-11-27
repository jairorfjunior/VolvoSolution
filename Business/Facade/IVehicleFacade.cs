using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facade
{
    public interface IVehicleFacade : IFacade<Vehicle>
    {
        void Incluir(Vehicle vehicle);

        List<Vehicle> ListarTodos();

        void Atualizar(Vehicle vehicle);

        void Excluir(int id);
    }
}
