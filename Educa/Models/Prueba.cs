namespace Educa.Models
{
    public class Prueba
    {
        public int Id { get; set; }
        public string? NombrePrueba { get; set; }
        public int IdSubtema { get; set; }
        public string? LinkPrueba { get; set; }
        public int Tipo { get; set; }
        public List<PreguntaPrueba>? PreguntaPruebas { get; set; }
        public List<UsuarioLibroPregunta>? UsuarioLibroPreguntas { get; set; }
        public List<UsuarioSubtemaPregunta>? UsuarioSubtemaPreguntas { get; set; }
    }
}
