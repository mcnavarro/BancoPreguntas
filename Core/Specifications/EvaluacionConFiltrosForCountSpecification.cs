using Core.Entities;

namespace Core.Specifications
{
    public class EvaluacionConFiltrosForCountSpecification : BaseSpecification<Evaluacion>
    {
        public EvaluacionConFiltrosForCountSpecification(EvaluacionSpecParams evaluacionParams) :
            base(r => 
            (string.IsNullOrEmpty(evaluacionParams.Search) || r.Curso.Nombre.ToLower().Contains(evaluacionParams.Search)) &&
            (!evaluacionParams.TipoEvaluacionId.HasValue || r.TipoEvaluacionId == evaluacionParams.TipoEvaluacionId) &&
            (!evaluacionParams.CursoId.HasValue || r.CursoId == evaluacionParams.CursoId))
        {

        }
    }
}