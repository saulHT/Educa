using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class UsuarioSubtemaMap : IEntityTypeConfiguration<UsuarioSubtema>
    {
        public void Configure(EntityTypeBuilder<UsuarioSubtema> builder)
        {
            builder.ToTable("UsuarioSubtema");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioSubtemaPreguntas).
            WithOne(o => o.UsuarioSubtemas).
            HasForeignKey(o => o.IdUsuarioSubtema);
        }
    }
}

