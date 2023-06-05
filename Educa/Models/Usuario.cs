namespace Educa.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String? NombreUsuario { get; set; }
        public int Age { get; set; }
        public String? Escuela { get; set; }
        public String? User { get; set; }
        public String? Password { get; set; }
        public String? NombreTutor { get; set; }
        public String? EmailTutor { get; set; }
        public String? CelularTutor { get; set; }
        public String? Avatar { get; set; }
        public List<UsuarioCurso>? UsuarioCursos { get; set; }
        public List<UsuarioTema>? UsuarioTemas { get; set; }
        public List<UsuarioSubtema>? UsuarioSubtemas { get; set; }
        public List<UsuarioLeccion>? UsuarioLecciones { get; set; }
        public List<UsuarioEjercicio>? UsuarioEjercicios { get; set; }
        public List<UsuarioLibro>? UsuarioLibros { get; set; }
        public List<UsuarioCuPregunta>? UsuarioCuPreguntas { get; set; }
        public List<RecuperarPassword>? RecuperarPasswords { get; set; }
        public List<UsuarioLeccionPag>? UsuarioLeccionPaginas { get; set; }
    }
}
