using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Services
{
    public class QuartoService
    {
        private readonly List<Quarto> _quartos = new();

        public bool Cadastrar(Quarto quarto)
        {
            if (quarto.Numero <= 0 || string.IsNullOrWhiteSpace(quarto.Tipo) || quarto.PrecoDiaria <= 0)
                return false;

            if (_quartos.Exists(q => q.Numero == quarto.Numero))
                return false;

            _quartos.Add(quarto);
            return true;
        }

        public Quarto? BuscarPorNumero(int numero)
        {
            return _quartos.Find(q => q.Numero == numero);
        }

        public bool OcuparQuarto(int numero)
        {
            var quarto = BuscarPorNumero(numero);
            if (quarto == null || quarto.Ocupado)
                return false;

            quarto.Ocupar();
            return true;
        }

        public bool LiberarQuarto(int numero)
        {
            var quarto = BuscarPorNumero(numero);
            if (quarto == null || !quarto.Ocupado)
                return false;

            quarto.Liberar();
            return true;
        }

        public List<Quarto> ListarTodos() => _quartos;
    }
}
