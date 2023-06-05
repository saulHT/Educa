namespace Educa.Models
{
    public class UsuarioLibroPregunta
    {
        public int Id { get; set; }
        public int IdUsuarioLibro { get; set; }
        public int IdPrueba { get; set; }
        public UsuarioLibro? UsuarioLibros { get; set; }
        public Prueba? Pruebas { get; set; }
    }
}
