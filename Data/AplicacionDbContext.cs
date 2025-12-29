using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using irvinPortfolio.Models;
namespace irvinPortfolio.Data
{
    public class AplicacionDbContext: DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options) { }

        public required DbSet<ModeloProyecto> modeloProyectos { get; set; }
        public required DbSet<Usuario> modeloUsuarios { get; set; }
        public required DbSet<MensajeContacto> modeloMensajeContacto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //------------------Tabla Usuario------------------------//
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios"); // Nombre de tabla en SQL
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Rol).IsRequired();
                entity.Property(u => u.FechaCreacion).IsRequired();


                // Seed del usuario Admin
                entity.HasData(new Usuario
                {
                    Id = 1,
                    Username = "Admin",
                    PasswordHash = "Panama0513", // Solo para prueba, luego se debe hashear
                    Rol = "Admin",
                    FechaCreacion = DateTime.Now
                });
            });

            //------------------Tabla Proyecto------------------------//
            modelBuilder.Entity<ModeloProyecto>(entity =>
            {
                entity.ToTable("Proyectos");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Titulo).IsRequired();
                entity.Property(p => p.Descripcion).IsRequired();
                entity.Property(p => p.Tecnologias).IsRequired();
                entity.Property(p => p.ImagenUrl).IsRequired(false);
                entity.Property(p => p.RepoUrl).IsRequired(false);
                entity.Property(p => p.DemoUrl).IsRequired(false);
                entity.Property(p => p.Destacado).HasDefaultValue(false);
                entity.Property(p => p.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });

            //------------------Tabla MensajeContacto------------------------//
            modelBuilder.Entity<MensajeContacto>(entity =>
            {
                entity.ToTable("MensajesContacto");
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Nombre).IsRequired();
                entity.Property(m => m.Email).IsRequired();
                entity.Property(m => m.Mensaje).IsRequired();
                entity.Property(m => m.FechaEnvio).IsRequired();
                entity.Property(m => m.Leido).HasDefaultValue(false);
            });
        }

    }
}
