using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager;
using Xunit;

namespace HotelManager.Tests
{
   public class ReservaCompletaTests
    {
        private Cliente CriarCliente() => new Cliente { Nome = "Luiz", Documento = "123456" };
        private Quarto CriarQuarto() => new Quarto { Numero = 10, PrecoDiaria = 200m };

        [Fact]
        public void DeveCalcularDiariasCorretamente()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = new DateTime(2025, 1, 1)
            };

            reserva.DefinirSaida(new DateTime(2025, 1, 4));

            Assert.Equal(3, reserva.CalcularDiarias());
        }

        [Fact]
        public void DeveCalcularPrecoTotalCorretamente()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = new DateTime(2025, 1, 1)
            };

            reserva.DefinirSaida(new DateTime(2025, 1, 3));

            Assert.Equal(400m, reserva.PrecoTotal); // 2 dias * 200
        }

        [Fact]
        public void DeveLancarErroSeDataSaidaInvalida()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = new DateTime(2025, 1, 10)
            };

            Assert.Throws<ArgumentException>(() =>
                reserva.DefinirSaida(new DateTime(2025, 1, 9)));
        }

        [Fact]
        public void DeveMarcarReservaComoPaga()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = DateTime.Today
            };

            reserva.MarcarComoPaga();

            Assert.True(reserva.Paga);
        }

        [Fact]
        public void DeveAdicionarReservaValida()
        {
            var service = new ReservaService();
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = DateTime.Today
            };

            service.AdicionarReserva(reserva);

            Assert.Equal(1, service.TotalReservas());
        }

        [Fact]
        public void NaoDeveAdicionarSeQuartoOcupado()
        {
            var service = new ReservaService();
            var quarto = CriarQuarto();

            var r1 = new Reserva { Cliente = CriarCliente(), Quarto = quarto, Dia = DateTime.Today };
            var r2 = new Reserva { Cliente = CriarCliente(), Quarto = quarto, Dia = DateTime.Today };

            service.AdicionarReserva(r1);

            Assert.Throws<InvalidOperationException>(() =>
                service.AdicionarReserva(r2));
        }

        [Fact]
        public void DeveEncerrarReserva()
        {
            var service = new ReservaService();
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = DateTime.Today
            };

            service.AdicionarReserva(reserva);
            service.EncerrarReserva(reserva);

            Assert.Equal(0, service.TotalReservas());
            Assert.False(reserva.Quarto.Ocupado);
        }

        [Fact]
        public void DeveLancarErroAoEncerrarReservaInexistente()
        {
            var service = new ReservaService();
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                Dia = DateTime.Today
            };

            Assert.Throws<InvalidOperationException>(() =>
                service.EncerrarReserva(reserva));
        }
    }

}
