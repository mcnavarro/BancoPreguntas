namespace Core.Entities
{
    public class Curso : BaseEntity
    {
        public Escuela Escuela { get; set; }
        public int EscuelaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}