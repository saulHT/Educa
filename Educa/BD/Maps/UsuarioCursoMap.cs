using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class UsuarioCursoMap : IEntityTypeConfiguration<UsuarioCurso>
    {
        public void Configure(EntityTypeBuilder<UsuarioCurso> builder)
        {
            builder.ToTable("UsuarioCurso");
            builder.HasKey(o => o.Id);


        }

    }

}
