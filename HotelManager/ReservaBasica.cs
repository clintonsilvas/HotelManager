using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    public class ReservaBasica
    {
        //Apenas reserva básica de diaria
        public int idReserva { get; set; }
        public Cliente cliente{ get; set; }
        public Quarto quarto { get; set; }
        public DateTime Dia { get; set; }
        public decimal precoTotal { get; set; }

    }
}
