using Application.Controllers;
using Business.Facade;
using Business.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   
    public class VehicleModelTest
    {

        private readonly IVehicleModelFacade _vehicleModelFacade;

        public VehicleModelTest()
        {
            _vehicleModelFacade = new VehicleModelFacade(new Mock<IVehicleModelService>().Object);
        }

        [Fact(DisplayName = "Incluir Modelos")]
        public void Post_Incluir()
        {
            var veiculoController = new VehicleModelController(_vehicleModelFacade);

            var veiculo = new VehicleModel() { Id = 1,  VehicleModelDescription = "XYZ" };

            var result = veiculoController.Incluir(veiculo);

            Assert.NotNull(result);




        }

        [Fact(DisplayName = "Atualizar Modelos")]
        public void Post_Atualizar()
        {
            var veiculoController = new VehicleModelController(_vehicleModelFacade);

            var veiculo = new VehicleModel() { Id = 1, VehicleModelDescription = "TESTE" };

            var result = veiculoController.Atualizar(veiculo);

            Assert.NotNull(result);


        }


        [Fact(DisplayName = "Listar Modelos")]
        public void Get_Listar()
        {


            var veiculoModelController = new VehicleModelController(_vehicleModelFacade);

            var result = veiculoModelController.Listar();


            Assert.NotNull(result);



        }


        [Theory(DisplayName = "Excluir Modelos")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Post_Excluir(int value)
        {
            var veiculoModelController = new VehicleModelController(_vehicleModelFacade);
            var result = veiculoModelController.Excluir(value);

            Assert.True(result);


        }

 
 


        public static IEnumerable<object[]> Dados()
        {

            yield return new object[] {  1, "Teste4" };
            yield return new object[] {  1, "Teste1" };
            yield return new object[] {  2, "Teste2" };
            yield return new object[] {  3, "Teste3" };


        }


    }
}
