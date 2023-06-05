using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Cursos).
             WithOne(o => o.Colores).
             HasForeignKey(o => o.IdColor);

            builder.HasMany(o => o.Temas).
             WithOne(o => o.Colores).
             HasForeignKey(o => o.IdColor);

            builder.HasMany(o => o.SubTemas).
             WithOne(o => o.Colores).
             HasForeignKey(o => o.IdColor);

            builder.HasMany(o => o.Lecciones).
             WithOne(o => o.Colores).
             HasForeignKey(o => o.IdColor);

        }
    }
}