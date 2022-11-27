
using Application.Controllers;
using Business.Facade;
using Business.Interfaces;
using Business.Services;
using Castle.Core.Logging;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetTopologySuite.Index.HPRtree;

namespace Tests
{
  
    public class VehicleTest
    {
     
        private readonly  IVehicleFacade _vehicleFacade;

        public VehicleTest()
        {           
            _vehicleFacade = new VehicleFacade(new Mock<IVehicleService>().Object, new Mock<IVehicleModelService>().Object);
        }

        [Fact]
        public void Post_Incluir()
        {
            var veiculoController = new VehicleController(_vehicleFacade);

            var veiculo = new Vehicle();
            var result = veiculoController.Incluir(veiculo);
              
            Assert.NotNull(result);
          
             
        }

        [Fact]
        public void Get_Listar()
        {
            var vehicleList = Dados() as List<Vehicle>;
 

            var veiculoController = new VehicleController(_vehicleFacade);

            
            var result = veiculoController.Listar();

          
            Assert.NotNull(result);
            Assert.Equal(Dados().Count(), result.Count());


        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Post_Excluir(int value)
        {
            var veiculoController = new VehicleController(_vehicleFacade);

            var veiculo = new Vehicle();
            var result = veiculoController.Excluir(value);


            Assert.True(result);
           

        }


        [Fact]  
        public void Post_ValidID()
        {
           var exception = Assert.Throws<ArgumentException>(() => _vehicleFacade.Incluir(new Vehicle() {   IdVehicleModel = 1, VehicleDescription = "Teste"}));

            Assert.True(true);
        }

        [Theory(DisplayName = "Vehicle estão preenchidos")]
        [MemberData(nameof(Dados))]
        public void Verify_Content(Vehicle vehicle)
        {
             
            Assert.NotEmpty(vehicle.VehicleDescription);
            Assert.IsType<Vehicle>(vehicle);

        }


        public static IEnumerable<object[]> Dados()
        {

            yield return new object[] {   1,   1,  "Teste4" };
            yield return new object[] {   2,   1,  "Teste1" };
            yield return new object[] {   3,   2,  "Teste2" };
            yield return new object[] {   4,   3,  "Teste3" };


        }


    }
}
