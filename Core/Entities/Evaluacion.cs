namespace Core.Entities
{
    public class Evaluacion : BaseEntity
    {
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
        public int TipoEvaluacionId { get; set; }
        public Numeral Numeral { get; set; }
        public int NumeralId { get; set; }
        public DateTime Fecha { get; set; }
        public bool HabilitadoModificacion { get; set; } = true;
    }
}