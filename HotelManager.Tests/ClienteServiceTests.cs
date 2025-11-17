using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Models;
using HotelManager.Services;

namespace HotelManager.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public void DeveCadastrarClienteValido()
        {
            var service = new ClienteService();
            var cliente = new Cliente { Nome = "Clinton", Documento = "12345678901", Telefone = "99999-9999" };

            var resultado = service.Cadastrar(cliente);

            Assert.True(resultado);
            Assert.Single(service.ListarTodos());
        }

        [Fact]
        public void NaoDeveCadastrarClienteInvalido()
        {
            var service = new ClienteService();
            var cliente = new Cliente { Nome = "", Documento = "" };

            var resultado = service.Cadastrar(cliente);

            Assert.False(resultado);
            Assert.Empty(service.ListarTodos());
        }

        [Fact]
        public void NaoDeveCadastrarClienteDuplicado()
        {
            var service = new ClienteService();
            var cliente1 = new Cliente { Nome = "Clinton", Documento = "12345678901" };
            var cliente2 = new Cliente { Nome = "Outro", Documento = "12345678901" };

            service.Cadastrar(cliente1);
            var resultado = service.Cadastrar(cliente2);

            Assert.False(resultado);
            Assert.Single(service.ListarTodos());
        }
    }
}
