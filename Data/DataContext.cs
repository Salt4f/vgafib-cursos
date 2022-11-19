using Microsoft.EntityFrameworkCore;
using VGAFIBCursos.Models;

namespace VGAFIBCursos.Data
{
    public class DataContext : DbContext
    {
        readonly IConfiguration configuration;

        public DataContext(IConfiguration config)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();
        }


        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Estudiante>? Estudiantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Curso);

            modelBuilder.Entity<Estudiante>()
                .HasKey(e => new { e.Dni, e.CursoId });

            /*modelBuilder.Entity<MultiplePrimaryKeyModel>()
                .HasKey(m => new { m.ID_1, m.ID_2 });*/
        }

    }
}
