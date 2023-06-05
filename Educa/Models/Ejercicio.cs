namespace Educa.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string? NombreEjercicio { get; set; }
        public string? DescripcionEjercicio { get; set; }
        public string? LinkEjercicio { get; set; }
        public int IdLeccion { get; set; }
        public Leccion? Lecciones { get; set; }
        public List<UsuarioEjercicio>? UsuarioEjercicios { get; set; }
    }
}
