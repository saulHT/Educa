using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class CuestionarioMap : IEntityTypeConfiguration<Cuestionario>
    {
        public void Configure(EntityTypeBuilder<Cuestionario> builder)
        {
            builder.ToTable("Cuestionario");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.CuestionarioPreguntas).
             WithOne(o => o.Cuestionarios).
             HasForeignKey(o => o.IdCuestionario);
        }
    }
}