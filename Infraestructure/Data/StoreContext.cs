using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Numeral> Numerales { get; set; }
        public DbSet<TipoEvaluacion> TiposEvaluacion { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}