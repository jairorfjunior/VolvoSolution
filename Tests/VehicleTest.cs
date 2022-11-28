
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

        [Fact(DisplayName = "Incluir Veículos")]
        public void Post_Incluir()
        {
            var veiculoController = new VehicleController(_vehicleFacade);

            var veiculo = new Vehicle() { Id = 1, IdVehicleModel = 2, VehicleDescription = "Teste", VehicleYearManufacture = 2019, VehicleYearModel = 2023 };
            
            var result = veiculoController.Incluir(veiculo);
              
            Assert.NotNull(result);
          
             
        }

        [Fact(DisplayName = "Atualizar Veículos")]
        public void Post_Atualizar()
        {
            var veiculoController = new VehicleController(_vehicleFacade);

            var veiculo = new Vehicle() { Id = 1, IdVehicleModel = 2, VehicleDescription = "Teste", VehicleYearManufacture = 2021, VehicleYearModel = 2023 };

            var result = veiculoController.Atualizar(veiculo);

            Assert.NotNull(result);


        }

        [Fact(DisplayName = "Listar Veículos")]
        public void Get_Listar()
        {

        
            var veiculoController = new VehicleController(_vehicleFacade);
            
            var result = veiculoController.Listar();
            

            Assert.NotNull(result);
            


        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Post_Excluir(int value)
        {
            var veiculoController = new VehicleController(_vehicleFacade);            
            var result = veiculoController.Excluir(value);

            Assert.True(result);
           

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
