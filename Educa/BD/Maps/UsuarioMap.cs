using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educa.BD.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioCursos).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioTemas).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioSubtemas).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioLecciones).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioEjercicios).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioLibros).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioCuPreguntas).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.RecuperarPasswords).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);

            builder.HasMany(o => o.UsuarioLeccionPaginas).
            WithOne(o => o.Usuarios).
            HasForeignKey(o => o.IdUsuario);
        }
    }
}
