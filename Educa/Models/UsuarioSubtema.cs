namespace Educa.Models
{
    public class UsuarioSubtema
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdSubtema { get; set; }
        public String? EstadoSubtema { get; set; }
        public int NotaPrueba { get; set; }
        public int PuntosSubtema { get; set; }
        public int PorcentajeAvance { get; set; }
        public DateTime UltFechaModif { get; set; }
        public Usuario? Usuarios { get; set; }
        public Subtema? Subtemas { get; set; }
        public List<UsuarioSubtemaPregunta>? UsuarioSubtemaPreguntas { get; set; }
    }
}
