using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class SubtemaMap : IEntityTypeConfiguration<Subtema>
    {
        public void Configure(EntityTypeBuilder<Subtema> builder)
        {
            builder.ToTable("Subtema");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Lecciones).
             WithOne(o => o.Subtemas).
             HasForeignKey(o => o.IdSubtema);

            builder.HasMany(o => o.UsuarioSubtemas).
            WithOne(o => o.Subtemas).
            HasForeignKey(o => o.IdSubtema);

        }
    }
}