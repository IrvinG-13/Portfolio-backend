namespace irvinPortfolio.Models
{
    public class MensajeContacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mensaje { get; set; } = null!;

        public bool Leido { get; set; } = false;
    }
}
