namespace Educa.Models
{
    public class UsuarioLeccion
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdLeccion { get; set; }
        public String? EstadoLeccion { get; set; }
        public int NotaLeccion { get; set; }
        public int PuntosLeccion { get; set; }
        public int PorcentajeAvance { get; set; }
        public DateTime UltFechaModif { get; set; }
        public Usuario? Usuarios { get; set; }
        public Leccion? Lecciones { get; set; }
    }
}
