using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class LibroMap : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioLibros).
             WithOne(o => o.Libros).
             HasForeignKey(o => o.IdLibro);

        }
    }
}