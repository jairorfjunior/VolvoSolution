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

        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleService.SelectAll().AsEnumerable();
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public Vehicle Get(int id)
        {
            return _vehicleService.SelectById(id);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] Vehicle model)
        {
            _vehicleService.Insert(model);
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vehicle model)
        {
            _vehicleService.Update(model);
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehicleService.Delete(id);
        }
    }
}
