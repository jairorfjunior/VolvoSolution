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

        // GET: api/<VehicleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_vehicleFacade.ListarTodos());
            }
            catch (Exception ex)
            {

                return BadRequest(new { result = false, message = ex.Message });
            }

        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_vehicleFacade.SelectById(id));
        }

        // POST api/<VehicleController>
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle model)
        {
            try
            {
                _vehicleFacade.Incluir(model);
                return Ok(new { result = true, message = "Registro incluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { result = false, message = ex.Message });
            }
           
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vehicle model)
        {
            try
            {
                _vehicleFacade.Atualizar(model);
                return Ok(new { result = true, message = "Registro alterado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { result = false, message = ex.Message });
            }
           
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _vehicleFacade.Excluir(id);
                return Ok(new { result = true, message = "Registro excluído com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { result = false, message = ex.Message });
            }

        }
    }
}
