namespace Educa.Models
{
    public class UsuarioLeccionPag
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPagLeccion { get; set; }
        public string? Estado { get; set; }
        public Usuario? Usuarios { get; set; }
        public PagLeccion? PagLecciones { get; set; }
    }
}
