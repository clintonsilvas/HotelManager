namespace HotelManager.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public Quarto Quarto { get; set; } = new Quarto();
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public bool Paga { get; set; } = false;

        public decimal PrecoTotal => Quarto.PrecoDiaria * CalcularDiarias();

        public int CalcularDiarias()
        {
            return (DataSaida - DataEntrada).Days;
        }       

        public void MarcarComoPaga()
        {
            Paga = true;
        }
    }
}
