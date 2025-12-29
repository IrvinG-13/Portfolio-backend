namespace irvinPortfolio.Models
{
    public class ModeloProyecto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Tecnologias { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
        public string RepoUrl { get; set; } = null!;
        public string DemoUrl { get; set; } = null!;
        public bool Destacado { get; set; } = false;

    }
}
