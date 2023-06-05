using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class UsuarioLeccionPagMap : IEntityTypeConfiguration<UsuarioLeccionPag>
    {
        public void Configure(EntityTypeBuilder<UsuarioLeccionPag> builder)
        {
            builder.ToTable("UsuarioLeccionPag");
            builder.HasKey(o => o.Id);
        }
    }
}
