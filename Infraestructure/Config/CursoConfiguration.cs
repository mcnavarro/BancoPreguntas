using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(r => r.EscuelaId).IsRequired();
            builder.HasOne(r => r.Escuela).WithMany()
                .HasForeignKey(r => r.EscuelaId);
        }
    }
}