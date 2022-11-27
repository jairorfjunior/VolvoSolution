using Business.Facade;
using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicleFacade _vehicleFacade;
        public VehicleController(IVehicleFacade vehicleFacade)
        {
            _vehicleFacade = vehicleFacade;
        }

       
        [HttpGet]
        [Route("Listar")]
        public IEnumerable<Vehicle> Listar()
        {
           
            return _vehicleFacade.Listar();
             
        }
         
       
        [HttpGet]
        [Route("ObterPorId")]
        public Vehicle ObterPorId(int id)
        {
            return _vehicleFacade.SelectById(id);
        }

        
        [HttpPost]
        [Route("Incluir")]
        public Vehicle Incluir([FromBody] Vehicle model)
        {
             
              return  _vehicleFacade.Incluir(model);
                
           
        }

       
        [HttpPut]
        [Route("Atualizar")]
        public Vehicle Atualizar( [FromBody] Vehicle model)
        {
              return _vehicleFacade.Atualizar(model);
                
           
        }
 
        [HttpDelete]
        [Route("Excluir")]
        public bool Excluir(int id)
        {
           
             return   _vehicleFacade.Excluir(id);
                
        }
    }
}
