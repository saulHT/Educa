using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class PruebaMap : IEntityTypeConfiguration<Prueba>
    {
        public void Configure(EntityTypeBuilder<Prueba> builder)
        {
            builder.ToTable("Prueba");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.PreguntaPruebas).
             WithOne(o => o.Pruebas).
             HasForeignKey(o => o.IdPrueba);

            builder.HasMany(o => o.UsuarioLibroPreguntas).
             WithOne(o => o.Pruebas).
             HasForeignKey(o => o.IdPrueba);

            builder.HasMany(o => o.UsuarioSubtemaPreguntas).
            WithOne(o => o.Pruebas).
            HasForeignKey(o => o.IdPrueba);

        }
    }
}
