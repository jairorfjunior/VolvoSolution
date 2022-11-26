using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {

            _vehicleModelService = vehicleModelService;
        }

        // GET: api/<VehicleModelController>
        [HttpGet]
        public IEnumerable<VehicleModel> Get()
        {
            return _vehicleModelService.SelectAll().AsEnumerable();
        }

        // GET api/<VehicleModelController>/5
        [HttpGet("{id}")]
        public VehicleModel Get(int id)
        {
            return _vehicleModelService.SelectById(id);
        }

        // POST api/<VehicleModelController>
        [HttpPost]
        public void Post([FromBody] VehicleModel model)
        {
            _vehicleModelService.Insert(model);
        }

        // PUT api/<VehicleModelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VehicleModel model)
        {
            _vehicleModelService.Update(model);
        }

        // DELETE api/<VehicleModelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehicleModelService.Delete(id);
        }
    }
}
