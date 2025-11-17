using HotelManager.Models;
using System;
using System.Collections.Generic;

namespace HotelManager.Services
{
    public class ReservaService
    {
        private readonly List<Reserva> _reservas = new();

        public bool AdicionarReserva(Reserva reserva)
        {
            if (reserva == null || reserva.Cliente == null || reserva.Quarto == null)
                return false;

            if (reserva.DataEntrada >= reserva.DataSaida)
                return false;

            if (reserva.DataEntrada < DateTime.Today)
                return false;

            if (reserva.Quarto.Ocupado)
                return false;

            reserva.Quarto.Ocupar();
            _reservas.Add(reserva);
            return true;
        }

        public bool EncerrarReserva(Reserva reserva)
        {
            if (!_reservas.Contains(reserva))
                return false;

            if (!reserva.Paga)
                return false;

            reserva.Quarto.Liberar();            
            _reservas.Remove(reserva);
            return true;
        }

        public int TotalReservas()
        {
            return _reservas.Count;
        }
        public List<Reserva> BuscarPorCliente(Cliente cliente)
        {
            return _reservas.FindAll(r => r.Cliente == cliente);
        }

        public List<Reserva> BuscarPorQuarto(Quarto quarto)
        {
            return _reservas.FindAll(r => r.Quarto == quarto);
        }

        public List<Reserva> BuscarPorPeriodo(DateTime dia)
        {
            return _reservas.FindAll(r => r.DataEntrada == dia);
        }

        public List<Reserva> ListarTodas()
        {
            return _reservas;
        }
    }
}
