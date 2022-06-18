using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class EvaluacionConfiguration : IEntityTypeConfiguration<Evaluacion>
    {
        public void Configure(EntityTypeBuilder<Evaluacion> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Fecha).IsRequired();
            builder.Property(r => r.CursoId).IsRequired();
            builder.Property(r => r.TipoEvaluacionId).IsRequired();
            builder.Property(r => r.NumeralId).IsRequired();
            builder.Property(r => r.HabilitadoModificacion).IsRequired();

            builder.HasOne(r => r.Curso).WithMany()
                .HasForeignKey(r => r.CursoId);
            builder.HasOne(r => r.TipoEvaluacion).WithMany()
                .HasForeignKey(r => r.TipoEvaluacionId);
            builder.HasOne(r => r.Numeral).WithMany()
                .HasForeignKey(r => r.NumeralId);
        }
    }
}