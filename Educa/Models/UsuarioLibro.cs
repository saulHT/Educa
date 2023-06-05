namespace Educa.Models
{
    public class UsuarioLibro
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public String? EstadoUsuarioLibro { get; set; }
        public Usuario? Usuarios { get; set; }
        public Libro? Libros { get; set; }
        public List<UsuarioLibroPregunta>? UsuarioLibroPreguntas { get; set; }
    }
}
