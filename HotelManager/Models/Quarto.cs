using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class Quarto
    {
        public int Numero { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal PrecoDiaria { get; set; }
        public bool Ocupado { get; private set; } = false;

        public void Ocupar()
        {
            Ocupado = true;
        }

        public void Liberar()
        {
            Ocupado = false;
        }
    }
}
