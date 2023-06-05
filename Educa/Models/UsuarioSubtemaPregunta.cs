namespace Educa.Models
{
    public class UsuarioSubtemaPregunta
    {
        public int Id { get; set; }
        public int IdUsuarioSubtema { get; set; }
        public int IdPrueba { get; set; }
        public string? Estado { get; set; }
        public int Nota { get; set; }
        public UsuarioSubtema? UsuarioSubtemas { get; set; }
        public Prueba? Pruebas { get; set; }
    }
}
