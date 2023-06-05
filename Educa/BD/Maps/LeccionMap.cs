using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class LeccionMap : IEntityTypeConfiguration<Leccion>
    {
        public void Configure(EntityTypeBuilder<Leccion> builder)
        {
            builder.ToTable("Leccion");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Libros).
             WithOne(o => o.Lecciones).
             HasForeignKey(o => o.IdLeccion);

            builder.HasMany(o => o.UsuarioLecciones).
             WithOne(o => o.Lecciones).
             HasForeignKey(o => o.IdLeccion);

            builder.HasMany(o => o.Ejercicios).
            WithOne(o => o.Lecciones).
            HasForeignKey(o => o.IdLeccion);

            builder.HasMany(o => o.PagLecciones).
            WithOne(o => o.Lecciones).
            HasForeignKey(o => o.IdLeccion);
        }
    }
}