namespace Educa.Models
{
    public class Grado
    {
        public int Id { get; set; }
        public string? NumeroGrado { get; set; }
        public List<Curso>? Cursos { get; set; }
    }
}
