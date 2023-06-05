namespace Educa.Models
{
    public class PagLeccion
    {
        public int Id { get; set; }
        public String? NombrePagLeccion { get; set; }
        public String? LinkPagLeccion {get; set; }
        public String? DescripcionPagLeccion { get; set; }
        public int IdLeccion { get; set; }
        public Leccion? Lecciones { get; set; }
        public List<UsuarioLeccionPag> UsuarioLeccionPaginas { get; set; }
    }
}
