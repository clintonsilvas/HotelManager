using System;
using System.Collections.Generic;

namespace HotelManager
{
    public class ReservaService
    {
        private readonly List<Reserva> _reservas = new();

        public void AdicionarReserva(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva));

            if (reserva.Quarto.Ocupado)
                throw new InvalidOperationException("O quarto já está ocupado.");

            reserva.Quarto.Ocupar();
            _reservas.Add(reserva);
        }

        public void EncerrarReserva(Reserva reserva)
        {
            if (!_reservas.Contains(reserva))
                throw new InvalidOperationException("Reserva não encontrada.");

            reserva.Quarto.Liberar();
            reserva.DefinirSaida(DateTime.Now);
            _reservas.Remove(reserva);
        }

        public int TotalReservas()
        {
            return _reservas.Count;
        }
    }
}
