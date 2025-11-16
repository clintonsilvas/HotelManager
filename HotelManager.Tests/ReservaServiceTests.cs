using HotelManager.Models;
using HotelManager.Services;
using System;
using Xunit;

namespace HotelManager.Tests
{
    public class ReservaServiceTests
    {
        [Fact]
        public void DeveCadastrarReservaValida()
        {
            var service = new ReservaService();
            Reserva reserva = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "Clinton", Documento = "12345678901", Telefone = "99999-9999" },
                Quarto = new Quarto { Numero = 101, Tipo = "Simples" },
                DataEntrada = DateTime.Now.AddDays(1),
                DataSaida = DateTime.Now.AddDays(3)
            };

            var resultado = service.AdicionarReserva(reserva);

            Assert.True(resultado);
            Assert.Single(service.ListarTodas());
        }

        [Fact]
        public void NaoDeveCadastrarReservaComDataPassada()
        {
            var service = new ReservaService();
            Reserva reserva = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "João", Documento = "12345678901" },
                Quarto = new Quarto { Numero = 101 },
                DataEntrada = DateTime.Now.AddDays(-3),
                DataSaida = DateTime.Now.AddDays(-1)
            };

            var resultado = service.AdicionarReserva(reserva);

            Assert.False(resultado);
            Assert.Empty(service.ListarTodas());
        }

        [Fact]
        public void NaoDeveCadastrarReservaEmQuartoJaReservadoNoMesmoDia()
        {
            var service = new ReservaService();

            Quarto quarto = new Quarto { Numero = 101 };
            

            var reserva1 = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "Clinton", Documento = "12345678901", Telefone = "99999-9999" },                
                DataEntrada = DateTime.Now.AddDays(2),
                DataSaida = DateTime.Now.AddDays(4)
            };
            reserva1.Quarto = quarto;

            var reserva2 = new Reserva
            {
                IdReserva = 2,
                Cliente = new Cliente { Nome = "Luiz", Documento = "13576568662", Telefone = "99877-9281" },
                Quarto = new Quarto { Numero = 101 },
                DataEntrada = DateTime.Now.AddDays(2),
                DataSaida = DateTime.Now.AddDays(4)
            };
            reserva2.Quarto = quarto;

            var aux = service.AdicionarReserva(reserva1);
            var resultado = service.AdicionarReserva(reserva2);

            Assert.False(resultado);
            Assert.Single(service.ListarTodas());
        }

        [Fact]
        public void DeveEncerrarReservaExistente()
        {
            var service = new ReservaService();

            var reserva = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "Clinton", Documento = "12345678901", Telefone = "99999-9999" },
                Quarto = new Quarto { Numero = 101 },
                DataEntrada = DateTime.Now.AddDays(1),
                DataSaida = DateTime.Now.AddDays(2)
            };

            service.AdicionarReserva(reserva);
            reserva.MarcarComoPaga();

            var resultado = service.EncerrarReserva(reserva);

            Assert.True(resultado);
            Assert.Empty(service.ListarTodas());
        }

        [Fact]
        public void NaoDeveEncerrarReservaSemPagar()
        {
            var service = new ReservaService();
            var reserva = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "Clinton", Documento = "12345678901", Telefone = "99999-9999" },
                Quarto = new Quarto { Numero = 101 },
                DataEntrada = DateTime.Now.AddDays(1),
                DataSaida = DateTime.Now.AddDays(2)
            };
            var resultado = service.EncerrarReserva(reserva);
            Assert.False(resultado);
        }
        private Cliente CriarCliente() => new Cliente { Nome = "Luiz", Documento = "123456" };
        private Quarto CriarQuarto() => new Quarto { Numero = 10, PrecoDiaria = 200m };

        [Fact]
        public void DeveCalcularDiariasCorretamente()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                DataEntrada = new DateTime(2025, 1, 1),
                DataSaida = new DateTime(2025, 1, 4)
            };     
            Assert.Equal(3, reserva.CalcularDiarias());
        }

        [Fact]
        public void DeveCalcularPrecoTotalCorretamente()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                DataEntrada = new DateTime(2025, 12, 1),
                DataSaida = new DateTime(2025, 12, 3)
            };        
            Assert.Equal(400m, reserva.PrecoTotal); // 2 dias * 200
        }

        [Fact]
        public void DeveMarcarReservaComoPaga()
        {
            var reserva = new Reserva
            {
                Cliente = CriarCliente(),
                Quarto = CriarQuarto(),
                DataEntrada = DateTime.Today,
                DataSaida = DateTime.Today.AddDays(2)
            };
            reserva.MarcarComoPaga();
            Assert.True(reserva.Paga);
        }
    }
}
