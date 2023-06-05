using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class UsuarioSubtemaPreguntaMap : IEntityTypeConfiguration<UsuarioSubtemaPregunta>
    {
        public void Configure(EntityTypeBuilder<UsuarioSubtemaPregunta> builder)
        {
            builder.ToTable("UsuarioSubtemaPregunta");
            builder.HasKey(o => o.Id);

        }
    }   
}