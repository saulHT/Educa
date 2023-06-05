namespace Educa.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string? ColorLight { get; set; }
        public string? ColorBlack { get; set; }
        public List<Curso>? Cursos { get; set; }
        public List<Tema>? Temas { get; set; }
        public List<Subtema>? SubTemas { get; set; }
        public List<Leccion>? Lecciones { get; set; }

    }
}
