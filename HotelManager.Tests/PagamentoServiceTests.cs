using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HotelManager;

namespace HotelManager.Tests
{
    public class PagamentoServiceTests
    {
        [Fact]
        public void EfetuarPagamento_ComValorSuficiente_DeveMarcarComoPago()
        {
            Reserva reserva = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "Maria", Documento = "01234567890", Telefone = "91234-5678" },
                Quarto = new Quarto { Numero = 101, Tipo = "Deluxe", PrecoDiaria = decimal.Parse("250") },
                Dia = DateTime.Now.AddDays(1)
            };
            var pagamento = new PagamentoService();

            bool resultado = pagamento.EfetuarPagamento(reserva, 250);

            Assert.True(resultado);
            Assert.True(reserva.Paga);
        }

        [Fact]
        public void EfetuarPagamento_ComValorInsuficiente_DeveFalhar()
        {
            Reserva reserva = new Reserva
            {
                IdReserva = 1,
                Cliente = new Cliente { Nome = "Maria", Documento = "01234567890", Telefone = "91234-5678" },
                Quarto = new Quarto { Numero = 101, Tipo = "Deluxe", PrecoDiaria = decimal.Parse("250") },
                Dia = DateTime.Now.AddDays(1)
            };
            var pagamento = new PagamentoService();

            bool resultado = pagamento.EfetuarPagamento(reserva, 100);

            Assert.False(resultado);
            Assert.False(reserva.Paga);
        }
    }
}
