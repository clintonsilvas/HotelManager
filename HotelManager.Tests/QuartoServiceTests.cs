using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Models;
using HotelManager.Services;

namespace HotelManager.Tests
{
    public class QuartoServiceTests
    {
        [Fact]
        public void DeveCadastrarQuartoValido()
        {
            var service = new QuartoService();
            var quarto = new Quarto { Numero = 101, Tipo = "Standard", PrecoDiaria = 150 };

            var resultado = service.Cadastrar(quarto);

            Assert.True(resultado);
            Assert.Single(service.ListarTodos());
        }

        [Fact]
        public void NaoDeveCadastrarQuartoDuplicado()
        {
            var service = new QuartoService();
            var quarto1 = new Quarto { Numero = 101, Tipo = "Standard", PrecoDiaria = 150 };
            var quarto2 = new Quarto { Numero = 101, Tipo = "Deluxe", PrecoDiaria = 250 };

            service.Cadastrar(quarto1);
            var resultado = service.Cadastrar(quarto2);

            Assert.False(resultado);
        }

        [Fact]
        public void DeveOcuparELiberarQuarto()
        {
            var service = new QuartoService();
            var quarto = new Quarto { Numero = 202, Tipo = "Deluxe", PrecoDiaria = 300 };

            service.Cadastrar(quarto);

            var ocupou = service.OcuparQuarto(202);
            var liberou = service.LiberarQuarto(202);

            Assert.True(ocupou);
            Assert.True(liberou);
        }
    }
}
