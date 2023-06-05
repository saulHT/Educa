using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class UsuarioCuPreguntaMap : IEntityTypeConfiguration<UsuarioCuPregunta>
    {
        public void Configure(EntityTypeBuilder<UsuarioCuPregunta> builder)
        {
            builder.ToTable("UsuarioCuPregunta");
            builder.HasKey(o => o.Id);
        }
    }
}