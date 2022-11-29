using Business.Facade;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelFacade _vehicleModelFacade;
        public VehicleModelController(IVehicleModelFacade  vehicleModelFacade)
        {

            _vehicleModelFacade = vehicleModelFacade;
        }

     
        [HttpGet]
        [Route("Listar")]
        public IEnumerable<VehicleModel> Listar()
        {
            return _vehicleModelFacade.Listar();
        }

        
        [HttpGet]
        [Route("ObterPorId")]
        public VehicleModel ObterPorId(int id)
        {
             return _vehicleModelFacade.SelectById(id);
        }

         
        [HttpPost]
        [Route("Incluir")]
        public VehicleModel Incluir([FromBody] VehicleModel model)
        {          
            return _vehicleModelFacade.Incluir(model);
        }

       
        [HttpPut]
        [Route("Atualizar")]
        public VehicleModel Atualizar( [FromBody] VehicleModel model)
        {
            return _vehicleModelFacade.Atualizar(model);
        }

         
        [HttpDelete]
        [Route("Excluir")]
        public bool Excluir(int id)
        {
            return _vehicleModelFacade.Excluir(id);
        }
    }
}
