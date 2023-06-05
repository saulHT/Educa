using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class EjercicioMap : IEntityTypeConfiguration<Ejercicio>
    {
        public void Configure(EntityTypeBuilder<Ejercicio> builder)
        {
            builder.ToTable("Ejercicio");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioEjercicios).
            WithOne(o => o.Ejercicios).
            HasForeignKey(o => o.IdEjercicio);
        }
    }
}
