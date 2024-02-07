using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WebApplication1;
using WebApplication1.Controllers;

namespace TestProject
{
    public class CompanhiaCargaTest
    {
        [Theory]
        [InlineData("Allianz")]
        public void Processar_Allianz_Ok(string companhia)
        {
            // Use NSubstitute to create a mock of ICompanhiaCarga
            var companhiaCarga = NSubstitute.Substitute.For<Allianz>();
            // Use NSubstitute to configure the mock
            string expected = $"{companhia} - Processar";   
            //companhiaCarga.When(x => x.Processar()).Do(x => Console.WriteLine(expected));
            // Use NSubstitute to execute the mock
            companhiaCarga.Processar();
            // Use NSubstitute to assert the mock
            var processado = companhiaCarga.Received().Processar();
            // Use NSubstitute to assert the mock
            Assert.Equal(expected, processado);
        }

        [Theory]
        [InlineData("Azul")]
        public void Processar_Azul_Ok(string companhia)
        {
            // Use NSubstitute to create a mock of ICompanhiaCarga
            var companhiaCarga = NSubstitute.Substitute.For<Azul>();
            // Use NSubstitute to configure the mock
            string expected = $"{companhia} - Processar";
            //companhiaCarga.When(x => x.Processar()).Do(x => Console.WriteLine(expected));
            // Use NSubstitute to execute the mock
            companhiaCarga.Processar();
            // Use NSubstitute to assert the mock
            var processado = companhiaCarga.Received().Processar();
            // Use NSubstitute to assert the mock
            Assert.Equal(expected, processado);
        }

        [Theory]
        [InlineData("Azul")]
        [InlineData("Allianz")]
        public void Teste_Companhia_Carga_Controller_Ok(string companhia)
        {
            var companhias = new List<ICompanhiaCarga>
            {
                Substitute.For<Allianz>(),
                Substitute.For<Azul>(),
            };

            var controller = new CompanhiaCargaController(companhias);
            var rtn = controller.Processar(companhia);

            Assert.IsType<OkObjectResult>(rtn);
        }

        [Theory]
        [InlineData("Allianza")]
        public void Teste_Companhia_Carga_Controller_Nao_OK(string companhia)
        {
            var companhias = new List<ICompanhiaCarga>
            {
                Substitute.For<Allianz>(),
                Substitute.For<Azul>(),
            };

            var controller = new CompanhiaCargaController(companhias);
            var rtn = controller.Processar(companhia);

            Assert.IsNotType<OkObjectResult>(rtn);
        }

    }
}