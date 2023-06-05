namespace Educa.Models
{
    public class UsuarioCuPregunta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCuestionarioPregunta { get; set; }
        public string? Respuesta { get; set; }
        public Usuario? Usuarios { get; set; }
        public CuestionarioPregunta? CuestionarioPreguntas { get; set; }
    }
}

