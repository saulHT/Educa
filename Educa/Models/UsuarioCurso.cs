namespace Educa.Models
{
    public class UsuarioCurso
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public String? EstadoCurso { get; set; }
        public int NotaPrueba { get; set; }
        public int PorcentajeAvance { get; set; }
        public DateTime UltFechaModif { get; set; }
        public Usuario? Usuarios { get; set; }
        public Curso? Cursos { get; set; }
    }
}
