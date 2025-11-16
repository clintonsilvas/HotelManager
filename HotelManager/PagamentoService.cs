using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    public class PagamentoService
    {
        public bool EfetuarPagamento(Reserva reserva, decimal valorPago)
        {
            decimal valorTotal = reserva.PrecoTotal;

            if (valorPago < valorTotal)
                return false;

            reserva.MarcarComoPaga();
            return true;
        }
    }
}
