using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class TemaMap : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Tema");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Subtemas).
            WithOne(o => o.Temas).
            HasForeignKey(o => o.IdTema);

            builder.HasMany(o => o.UsuarioTemas).
             WithOne(o => o.Temas).
             HasForeignKey(o => o.IdTema);

        }
    }
}
