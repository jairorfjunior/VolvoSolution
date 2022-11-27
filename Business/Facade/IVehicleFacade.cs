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
        Vehicle Incluir(Vehicle vehicle);

        List<Vehicle> Listar();

        Vehicle Atualizar(Vehicle vehicle);

        bool Excluir(int id);
    }
}
