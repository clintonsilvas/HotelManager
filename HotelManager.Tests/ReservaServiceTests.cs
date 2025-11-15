using System;
using Xunit;

namespace HotelManager.Tests
{
    public class ReservaServiceTests
    {
        [Fact]
        public void DeveCadastrarReservaValida()
        {
            var service = new ReservaBasicaService();
            ReservaBasica reserva = new ReservaBasica
            {
                idReserva = 1,
                cliente = new Cliente { Nome = "Clinton", Documento = "12345678901", Telefone = "99999-9999" },
                quarto = new Quarto { Numero = 101, Tipo = "Simples" },
                Dia = DateTime.Now.AddDays(1)
            };

            bool resultado = service.cadastrarReserva(reserva);

            Assert.True(resultado);
            Assert.Single(service.listarTodas());
        }

        [Fact]
        public void NaoDeveCadastrarReservaComClienteInvalido()
        {
            var service = new ReservaBasicaService();
            ReservaBasica reserva = new ReservaBasica
            {
                idReserva = 1,
                cliente = new Cliente { Nome = "", Documento = "" },
                quarto = new Quarto { Numero = 101, Tipo = "Simples" },
                Dia = DateTime.Now.AddDays(1)
            };

            bool resultado = service.cadastrarReserva(reserva);

            Assert.False(resultado);
            Assert.Empty(service.listarTodas());
        }

        [Fact]
        public void NaoDeveCadastrarReservaComDataPassada()
        {
            var service = new ReservaBasicaService();
            ReservaBasica reserva = new ReservaBasica
            {
                idReserva = 1,
                cliente = new Cliente { Nome = "João", Documento = "12345678901" },
                quarto = new Quarto { Numero = 101 },
                Dia = DateTime.Now.AddDays(-1)
            };

            bool resultado = service.cadastrarReserva(reserva);

            Assert.False(resultado);
            Assert.Empty(service.listarTodas());
        }

        [Fact]
        public void NaoDeveCadastrarReservaEmQuartoJaReservadoNoMesmoDia()
        {
            var service = new ReservaBasicaService();

            var reserva1 = new ReservaBasica
            {
                idReserva = 1,
                cliente = new Cliente { Nome = "A", Documento = "111" },
                quarto = new Quarto { Numero = 101 },
                Dia = DateTime.Now.AddDays(2)
            };

            var reserva2 = new ReservaBasica
            {
                idReserva = 2,
                cliente = new Cliente { Nome = "B", Documento = "222" },
                quarto = new Quarto { Numero = 101 },
                Dia = reserva1.Dia
            };

            service.cadastrarReserva(reserva1);
            bool resultado = service.cadastrarReserva(reserva2);

            Assert.False(resultado);
            Assert.Single(service.listarTodas());
        }

        [Fact]
        public void NaoDeveCadastrarReservaComIdDuplicado()
        {
            var service = new ReservaBasicaService();

            var reserva1 = new ReservaBasica
            {
                idReserva = 1,
                cliente = new Cliente { Nome = "A", Documento = "111" },
                quarto = new Quarto { Numero = 101 },
                Dia = DateTime.Now.AddDays(2)
            };

            var reserva2 = new ReservaBasica
            {
                idReserva = 1, // mesmo ID
                cliente = new Cliente { Nome = "B", Documento = "222" },
                quarto = new Quarto { Numero = 102 },
                Dia = DateTime.Now.AddDays(3)
            };

            service.cadastrarReserva(reserva1);
            bool resultado = service.cadastrarReserva(reserva2);

            Assert.False(resultado);
            Assert.Single(service.listarTodas());
        }

        [Fact]
        public void DeveCancelarReservaExistente()
        {
            var service = new ReservaBasicaService();

            var reserva = new ReservaBasica
            {
                idReserva = 1,
                cliente = new Cliente { Nome = "A", Documento = "111" },
                quarto = new Quarto { Numero = 101 },
                Dia = DateTime.Now.AddDays(1)
            };

            service.cadastrarReserva(reserva);

            bool resultado = service.cancelarReserva(1);

            Assert.True(resultado);
            Assert.Empty(service.listarTodas());
        }

        [Fact]
        public void NaoDeveCancelarReservaInexistente()
        {
            var service = new ReservaBasicaService();

            bool resultado = service.cancelarReserva(99);

            Assert.False(resultado);
        }
    }
}
