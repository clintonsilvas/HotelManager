namespace HotelManager
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public Cliente Cliente { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime Dia { get; set; }
        public DateTime? DataSaida { get; set; }
        public bool Paga { get; set; }

        public decimal PrecoTotal => Quarto.PrecoDiaria * CalcularDiarias();

        public int CalcularDiarias()
        {
            if (DataSaida == null)
                return 1; // O Samuel deixou com diária única

            return (DataSaida.Value - Dia).Days;
        }

        public void DefinirSaida(DateTime saida)
        {
            if (saida <= Dia)
                throw new ArgumentException("Data de saída inválida.");

            DataSaida = saida;
        }

        public void MarcarComoPaga()
        {
            Paga = true;
        }
    }
}
