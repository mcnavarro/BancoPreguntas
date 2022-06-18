namespace API.DTOs
{
    public class EvaluacionDTO
    {
        public int Id { get; set; }
        public string Institucion { get; set; }
        public string Escuela { get; set; }
        public string Curso { get; set; }
        public string TipoEvaluacion { get; set; }
        public string Numeral { get; set; }
        public DateTime Fecha { get; set; }
        public string InstitucionUrl { get; set; }
        public string EscuelaUrl { get; set; }
        public bool HabilitadoModificacion { get; set; } = true;
    }
}