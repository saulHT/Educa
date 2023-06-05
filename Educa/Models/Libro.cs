namespace Educa.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? TituloLibro { get; set; }
        public string? Autor { get; set; }
        public string? DescripcionLibro { get; set; }
        public string? EstadoLibro { get; set; }
        public string? LinkImgLibro { get; set; }
        public string? LinkPaginaLibro { get; set; }
        public int IdLeccion { get; set; }
        public string? Color { get; set; }
        public Leccion? Lecciones { get; set; }
        public List<UsuarioLibro>? UsuarioLibros { get; set; }

    }
}
