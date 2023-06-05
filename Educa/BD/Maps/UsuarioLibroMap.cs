using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class UsuarioLibroMap : IEntityTypeConfiguration<UsuarioLibro>
    {
        public void Configure(EntityTypeBuilder<UsuarioLibro> builder)
        {
            builder.ToTable("UsuarioLibro");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioLibroPreguntas).
            WithOne(o => o.UsuarioLibros).
            HasForeignKey(o => o.IdUsuarioLibro);
        }

    }

}
