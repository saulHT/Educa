using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class UsuarioEjercicioMap : IEntityTypeConfiguration<UsuarioEjercicio>
    {
        public void Configure(EntityTypeBuilder<UsuarioEjercicio> builder)
        {
            builder.ToTable("UsuarioEjercicio");
            builder.HasKey(o => o.Id);

        }
    }
}