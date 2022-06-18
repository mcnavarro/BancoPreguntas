using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class InstitucionConfiguration : IEntityTypeConfiguration<Institucion>
    {
        public void Configure(EntityTypeBuilder<Institucion> builder)
        {
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}