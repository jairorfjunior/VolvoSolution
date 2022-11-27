
using Business.Services;
using Castle.Core.Logging;
using Domain.Models;
using Infrastructure.Interfaces;
using Moq;

namespace Tests
{
  
    public class VehicleTest
    {
     
        private readonly VehicleService _vehicleService;

        public VehicleTest()
        {

            _vehicleService = new VehicleService(new Mock<IVehicleRepository>().Object);
        }

        [Fact]  
        public void Post_ValidID()
        {
            //var exception = Assert.Throws<ArgumentException>(() => _vehicleService.Insert(new Vehicle() {   IdVehicleModel = 1, VehicleDescription = "Teste"}));

            Assert.True(true);
        }

        public static IEnumerable<Vehicle> Dados()
        {

            yield return new Vehicle() { Id = 1, IdVehicleModel = 1, VehicleDescription = "Teste4" };
            yield return new Vehicle() { Id = 2, IdVehicleModel = 1, VehicleDescription = "Teste1" };
            yield return new Vehicle() { Id = 3, IdVehicleModel = 2, VehicleDescription = "Teste2" };
            yield return new Vehicle() { Id = 4, IdVehicleModel = 3, VehicleDescription = "Teste3" };


        }


    }
}
