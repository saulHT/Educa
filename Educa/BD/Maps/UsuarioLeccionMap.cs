using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class UsuarioLeccionMap : IEntityTypeConfiguration<UsuarioLeccion>
    {
        public void Configure(EntityTypeBuilder<UsuarioLeccion> builder)
        {
            builder.ToTable("UsuarioLeccion");
            builder.HasKey(o => o.Id);
        }

    }

}
