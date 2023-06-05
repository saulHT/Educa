using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class UsuarioTemaMap : IEntityTypeConfiguration<UsuarioTema>
    {
        public void Configure(EntityTypeBuilder<UsuarioTema> builder)
        {
            builder.ToTable("UsuarioTema");
            builder.HasKey(o => o.Id);
        }
    }
}

