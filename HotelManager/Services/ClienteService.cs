using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes = new();

        public bool Cadastrar(Cliente cliente)
        {
            if (!cliente.EhValido()) return false;
            if (_clientes.Exists(c => c.Documento == cliente.Documento))
                return false;

            _clientes.Add(cliente);
            return true;
        }

        public Cliente? BuscarPorDocumento(string documento)
        {
            return _clientes.Find(c => c.Documento == documento);
        }

        public List<Cliente> ListarTodos()
        {
            return _clientes;
        }
    }
}
