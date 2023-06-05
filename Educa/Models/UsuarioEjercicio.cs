namespace Educa.Models
{
    public class UsuarioEjercicio
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdEjercicio { get; set; }
        public String? EstadoUsuarioEjercicio { get; set; }
        public int NotaUsuarioEjercicio { get; set; }
        public Usuario? Usuarios { get; set; }
        public Ejercicio? Ejercicios { get; set; }
    }
}
