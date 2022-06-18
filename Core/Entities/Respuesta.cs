namespace Core.Entities
{
    public class Respuesta : BaseEntity
    {
        public Pregunta Pregunta { get; set; }
        public int PreguntaId { get; set; }
        public string Descripcion { get; set; }
        public bool EsCorrecta { get; set; } = false;
    }
}