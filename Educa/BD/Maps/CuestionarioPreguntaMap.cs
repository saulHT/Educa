using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class CuestionarioPreguntaMap : IEntityTypeConfiguration<CuestionarioPregunta>
    {
        public void Configure(EntityTypeBuilder<CuestionarioPregunta> builder)
        {
            builder.ToTable("CuestionarioPregunta");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioCuPreguntas).
             WithOne(o => o.CuestionarioPreguntas).
             HasForeignKey(o => o.IdCuestionarioPregunta);
        }
    }
}