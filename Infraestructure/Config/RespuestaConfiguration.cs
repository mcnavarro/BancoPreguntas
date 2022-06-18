using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class RespuestaConfiguration : IEntityTypeConfiguration<Respuesta>
    {
        public void Configure(EntityTypeBuilder<Respuesta> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Descripcion).IsRequired().HasMaxLength(450);

            builder.HasOne(r => r.Pregunta).WithMany()
                .HasForeignKey(r => r.PreguntaId);
        }
    }
}