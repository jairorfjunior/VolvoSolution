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

        // GET: api/<VehicleModelController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_vehicleModelFacade.ListarTodos());
        }

        // GET api/<VehicleModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_vehicleModelFacade.SelectById(id));
        }

        // POST api/<VehicleModelController>
        [HttpPost]
        public void Post([FromBody] VehicleModel model)
        {          
            _vehicleModelFacade.Incluir(model);
        }

        // PUT api/<VehicleModelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VehicleModel model)
        {
            _vehicleModelFacade.Atualizar(model);
        }

        // DELETE api/<VehicleModelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehicleModelFacade.Excluir(id);
        }
    }
}
