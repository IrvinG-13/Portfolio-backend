using irvinPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace irvinPortfolio.Data
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            : base(options) { }

        public DbSet<ModeloProyecto> modeloProyectos { get; set; } = null!;
        public DbSet<Usuario> modeloUsuarios { get; set; } = null!;
        public DbSet<MensajeContacto> modeloMensajeContacto { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ------------------ Usuario ------------------
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Username)
                      .IsRequired();

                entity.Property(u => u.PasswordHash)
                      .IsRequired();

                entity.Property(u => u.Rol)
                      .IsRequired();

                entity.Property(u => u.FechaCreacion)
                      .IsRequired();

                // ⚠️ IMPORTANTE: DateTime en UTC (PostgreSQL exige esto)
                entity.HasData(new Usuario
                {
                    Id = 1,
                    Username = "Admin",
                    PasswordHash = "Panama0513", // luego puedes cambiarlo por hash real
                    Rol = "Admin",
                    FechaCreacion = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                });
            });

            // ------------------ Proyecto ------------------
            modelBuilder.Entity<ModeloProyecto>(entity =>
            {
                entity.ToTable("Proyectos");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Titulo)
                      .IsRequired();

                entity.Property(p => p.Descripcion)
                      .IsRequired();

                entity.Property(p => p.Tecnologias)
                      .IsRequired();

                entity.Property(p => p.ImagenUrl)
                      .IsRequired(false);

                entity.Property(p => p.RepoUrl)
                      .IsRequired(false);

                entity.Property(p => p.DemoUrl)
                      .IsRequired(false);

                entity.Property(p => p.Destacado)
                      .HasDefaultValue(false);

            });

            // ------------------ MensajeContacto ------------------
            modelBuilder.Entity<MensajeContacto>(entity =>
            {
                entity.ToTable("MensajesContacto");

                entity.HasKey(m => m.Id);

                entity.Property(m => m.Nombre)
                      .IsRequired();

                entity.Property(m => m.Email)
                      .IsRequired();

                entity.Property(m => m.Mensaje)
                      .IsRequired();


                entity.Property(m => m.Leido)
                      .HasDefaultValue(false);
            });
        }
    }
}
