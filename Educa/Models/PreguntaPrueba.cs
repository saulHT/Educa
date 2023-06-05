namespace Educa.Models
{
    public class PreguntaPrueba
    {
        public int Id { get; set; }
        public string? PreguntaP { get; set; }
        public string? Respuesta { get; set; }
        public int IdPrueba { get; set; }
        public Prueba? Pruebas { get; set; }
        
    }
}
