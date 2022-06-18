using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class EscuelaConfiguration : IEntityTypeConfiguration<Escuela>
    {
        public void Configure(EntityTypeBuilder<Escuela> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(r => r.InstitucionId).IsRequired();
            builder.HasOne(r => r.Institucion).WithMany()
                .HasForeignKey(r => r.InstitucionId);
        }
    }
}