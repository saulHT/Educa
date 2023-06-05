using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class PagLeccionMap : IEntityTypeConfiguration<PagLeccion>
    {
        public void Configure(EntityTypeBuilder<PagLeccion> builder)
        {
            builder.ToTable("PagLeccion");
            builder.HasKey(o => o.Id);

            
            builder.HasMany(o => o.UsuarioLeccionPaginas).
            WithOne(o => o.PagLecciones).
            HasForeignKey(o => o.IdPagLeccion);
        }
    }
}
