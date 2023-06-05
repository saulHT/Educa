using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Temas).
            WithOne(o => o.Cursos).
            HasForeignKey(o => o.IdCurso);

            builder.HasMany(o => o.UsuarioCursos).
            WithOne(o => o.Cursos).
            HasForeignKey(o => o.IdCurso);

        }

    }

}