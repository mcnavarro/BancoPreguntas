using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class PreguntaConfiguration : IEntityTypeConfiguration<Pregunta>
    {
        public void Configure(EntityTypeBuilder<Pregunta> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Descripcion).IsRequired().HasMaxLength(600);

            builder.HasOne(r => r.Evaluacion).WithMany()
                .HasForeignKey(r => r.EvaluacionId);
        }
    }
}