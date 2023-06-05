namespace Educa.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string? NombreCurso { get; set; }
        public int IdGrado { get; set; }
        public string? LinkImgCurso { get; set; }
        public int IdColor { get; set; }
        public Grado? Grados { get; set; }
        public Color? Colores { get; set; }
        public List<Tema>? Temas { get; set; }
        public List<UsuarioCurso>? UsuarioCursos { get; set; }
    }
}
