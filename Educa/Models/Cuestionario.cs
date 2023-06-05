namespace Educa.Models
{
    public class Cuestionario
    {
        public int Id { get; set; }
        public string? NombreCuestionario { get; set; }
        public string? DescripcionCuestionario { get; set; }
        public string? TipoCuestionario { get; set; }
        public List<CuestionarioPregunta>? CuestionarioPreguntas { get; set; }
    }
}
