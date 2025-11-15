using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    public class ReservaBasicaService
    {
        private readonly List<ReservaBasica> _reservas = new();

        //cadastro e remoção
        public bool cadastrarReserva(ReservaBasica reserva)
        {
            // validando se o cliente é inválido
            if (reserva.cliente == null || !reserva.cliente.EhValido())
                return false;

            // validade se a data já passou
            if (reserva.Dia < DateTime.Now)
                return false;

            // validando se já existe reserva no mesmo quarto e dia
            if (_reservas.Exists(r =>
                r.Dia.Date == reserva.Dia.Date &&
                r.quarto.Numero == reserva.quarto.Numero))
                return false;

            // validando se a reserva já existe
            if (_reservas.Exists(r => r.idReserva == reserva.idReserva))
                return false;

            // tudo ok, finaliza
            _reservas.Add(reserva);
            return true;
        }
        public bool cancelarReserva(int idReserva)
        {
            ReservaBasica reserva = _reservas.Find(r => r.idReserva == idReserva);

            if (reserva == null)
                return false;

            _reservas.Remove(reserva);
            return true;
        }


        //consultas
        public List<ReservaBasica> buscarPorCliente(Cliente cliente)
        {
            return _reservas.FindAll(r => r.cliente == cliente);
        }

        public List<ReservaBasica> buscarPorQuarto(Quarto quarto)
        {
            return _reservas.FindAll(r => r.quarto == quarto);
        }

        public List<ReservaBasica> BuscarPorPeriodo(DateTime dia)
        {
            return _reservas.FindAll(r => r.Dia == dia);
        }

        public List<ReservaBasica> listarTodas()
        {
            return _reservas;
        }



    }
}
