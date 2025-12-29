namespace irvinPortfolio.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Rol { get; set; } = "Admin";
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
