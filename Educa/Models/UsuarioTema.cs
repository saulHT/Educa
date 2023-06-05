namespace Educa.Models
{
    public class UsuarioTema
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdTema { get; set; }
        public String? EstadoTema { get; set; }
        public int NotaPrueba { get; set; }
        public int PuntosTema { get; set; }
        public int PorcentajeAvance { get; set; }
        public DateTime UltFechaModif { get; set; }
        public Usuario? Usuarios { get; set; }
        public Tema? Temas { get; set; }
    }
}
