namespace Educa.Models
{
    public class Subtema
    {
        public int Id { get; set; }
        public string? TituloSubtema { get; set; }
        public string? DescripcionSubtema { get; set; }
        public string? LinkImgSubtema { get; set; }
        public string? TipoSubtema { get; set; }
        public int? IdColor { get; set; }
        public int? IdTema { get; set; }
        public Color? Colores { get; set; }
        public Tema? Temas { get; set; }
        public List<Leccion>? Lecciones { get; set; }
        public List<UsuarioSubtema>? UsuarioSubtemas { get; set; }
    }
}
