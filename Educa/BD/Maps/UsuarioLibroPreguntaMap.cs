using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class UsuarioLibroPreguntaMap : IEntityTypeConfiguration<UsuarioLibroPregunta>
    {
        public void Configure(EntityTypeBuilder<UsuarioLibroPregunta> builder)
        {
            builder.ToTable("UsuarioLibroPregunta");
            builder.HasKey(o => o.Id);
        }

    }

}
