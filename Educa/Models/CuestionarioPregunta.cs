namespace Educa.Models
{
    public class CuestionarioPregunta
    {
        public int Id { get; set; }
        public string? Pregunta { get; set; }
        public int IdCuestionario { get; set; }
        public Cuestionario? Cuestionarios { get; set; }
        public List<UsuarioCuPregunta>? UsuarioCuPreguntas { get; set; }
    }
}
