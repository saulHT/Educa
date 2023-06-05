using Microsoft.EntityFrameworkCore;
using Educa.BD.Maps;
using Educa.Models;
namespace Educa.BD
{
    public interface IEducaContext
    {
        DbSet<Usuario> _usuario { get; set; }
        DbSet<Color> _color { get; set; }
        DbSet<Cuestionario> _cuestionario { get; set; }
        DbSet<Curso> _curso { get; set; }
        DbSet<Ejercicio> _ejercicio { get; set; }
        DbSet<Grado> _grado { get; set; }
        DbSet<Leccion> _leccion { get; set; }
        DbSet<Libro> _libro { get; set; }
        DbSet<PagLeccion> _pagLeccion { get; set; }
        DbSet<PreguntaPrueba> _preguntaPrueba { get; set; }
        DbSet<Prueba> _prueba { get; set; }
        DbSet<RecuperarPassword> _recuperarPassword { get; set; }
        DbSet<Subtema> _subtema { get; set; }
        DbSet<Tema> _tema { get; set; }
        DbSet<UsuarioCuPregunta> _usuarioCuPregunta { get; set; }
        DbSet<UsuarioCurso> _usuarioCurso { get; set; }
        DbSet<UsuarioEjercicio> _usuarioEjercicio { get; set; }
        DbSet<UsuarioLeccion> _usuarioLeccion { get; set; }
        DbSet<UsuarioLeccionPag> _usuarioLeccionPag { get; set; }
        DbSet<UsuarioLibro> _usuarioLibro { get; set; }
        DbSet<UsuarioLibroPregunta> _usuarioLibroPregunta { get; set; }
        DbSet<UsuarioSubtema> _usuarioSubtema { get; set; }
        DbSet<UsuarioTema> _usuarioTema { get; set; }
        DbSet<UsuarioSubtemaPregunta> _usuarioSubtemaPregunta { get; set; }
        DbSet<CuestionarioPregunta> _cuestionarioPregunta { get; set; }
        int SaveChanges();

    }
    public class EducaContext : DbContext, IEducaContext
    {

        public virtual DbSet<Usuario> _usuario { get; set; }
        public virtual DbSet<Color> _color { get; set; }
        public virtual DbSet<Cuestionario> _cuestionario { get; set; }
        public virtual DbSet<Curso> _curso { get; set; }
        public virtual DbSet<Ejercicio> _ejercicio { get; set; }
        public virtual DbSet<Grado> _grado { get; set; }
        public virtual DbSet<Leccion> _leccion { get; set; }
        public virtual DbSet<Libro> _libro { get; set; }
        public virtual DbSet<PagLeccion> _pagLeccion { get; set; }
        public virtual DbSet<PreguntaPrueba> _preguntaPrueba { get; set; }
        public virtual DbSet<Prueba> _prueba { get; set; }
        public virtual DbSet<RecuperarPassword> _recuperarPassword { get; set; }
        public virtual DbSet<Subtema> _subtema { get; set; }
        public virtual DbSet<Tema> _tema { get; set; }
        public virtual DbSet<UsuarioCuPregunta> _usuarioCuPregunta { get; set; }
        public virtual DbSet<UsuarioCurso> _usuarioCurso { get; set; }
        public virtual DbSet<UsuarioEjercicio> _usuarioEjercicio { get; set; }
        public virtual DbSet<UsuarioLeccion> _usuarioLeccion { get; set; }
        public virtual DbSet<UsuarioLeccionPag> _usuarioLeccionPag { get; set; }
        public virtual DbSet<UsuarioLibro> _usuarioLibro { get; set; }
        public virtual DbSet<UsuarioLibroPregunta> _usuarioLibroPregunta { get; set; }
        public virtual DbSet<UsuarioSubtema> _usuarioSubtema { get; set; }
        public virtual DbSet<UsuarioTema> _usuarioTema { get; set; }
        public virtual DbSet<UsuarioSubtemaPregunta> _usuarioSubtemaPregunta { get; set; }
        public virtual DbSet<CuestionarioPregunta> _cuestionarioPregunta { get; set; }
        public EducaContext()
        {

        }
        public EducaContext(DbContextOptions<EducaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new CuestionarioMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new GradoMap());
            modelBuilder.ApplyConfiguration(new LeccionMap());
            modelBuilder.ApplyConfiguration(new LibroMap());
            modelBuilder.ApplyConfiguration(new PagLeccionMap());
            modelBuilder.ApplyConfiguration(new PreguntaPruebaMap());
            modelBuilder.ApplyConfiguration(new PruebaMap());
            modelBuilder.ApplyConfiguration(new RecuperarPasswordMap());
            modelBuilder.ApplyConfiguration(new SubtemaMap());
            modelBuilder.ApplyConfiguration(new TemaMap());
            modelBuilder.ApplyConfiguration(new UsuarioCuPreguntaMap());
            modelBuilder.ApplyConfiguration(new UsuarioCursoMap());
            modelBuilder.ApplyConfiguration(new UsuarioEjercicioMap());
            modelBuilder.ApplyConfiguration(new UsuarioLeccionMap());
            modelBuilder.ApplyConfiguration(new UsuarioLeccionPagMap());
            modelBuilder.ApplyConfiguration(new UsuarioLibroMap());
            modelBuilder.ApplyConfiguration(new UsuarioLibroPreguntaMap());
            modelBuilder.ApplyConfiguration(new UsuarioSubtemaMap());
            modelBuilder.ApplyConfiguration(new UsuarioTemaMap());
            modelBuilder.ApplyConfiguration(new UsuarioSubtemaPreguntaMap());
            modelBuilder.ApplyConfiguration(new CuestionarioPreguntaMap());
        }
    }
}
