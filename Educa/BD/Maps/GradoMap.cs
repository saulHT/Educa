using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class GradoMap : IEntityTypeConfiguration<Grado>
    {
        public void Configure(EntityTypeBuilder<Grado> builder)
        {
            builder.ToTable("Grado");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Cursos).
             WithOne(o => o.Grados).
             HasForeignKey(o => o.IdGrado);

        }
    }
}
