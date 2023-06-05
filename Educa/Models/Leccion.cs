namespace Educa.Models
{
    public class Leccion
    {
        public int Id { get; set; }
        public string? TituloLeccion { get; set; }
        public string? DescripcionLeccion { get; set; }
        public string? LinkImgLeccion { get; set; }
        public string? TipoLeccion { get; set; }
        public int IdColor { get; set; }
        public int IdSubtema { get; set; }
        public Color? Colores { get; set; }
        public Subtema? Subtemas { get; set; }
        public List<Libro>? Libros { get; set; }
        public List<PagLeccion>? PagLecciones { get; set; }
        public List<UsuarioLeccion>? UsuarioLecciones { get; set; }
        public List<Ejercicio>? Ejercicios { get; set; }
    }
}
