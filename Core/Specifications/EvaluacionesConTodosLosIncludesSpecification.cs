using Core.Entities;

namespace Core.Specifications
{
    public class EvaluacionesConTodosLosIncludesSpecification : BaseSpecification<Evaluacion>
    {
        public EvaluacionesConTodosLosIncludesSpecification(EvaluacionSpecParams evaluacionParams) :
            base(r => 
            (string.IsNullOrEmpty(evaluacionParams.Search) || r.Curso.Nombre.ToLower().Contains(evaluacionParams.Search)) &&
            (!evaluacionParams.TipoEvaluacionId.HasValue || r.TipoEvaluacionId == evaluacionParams.TipoEvaluacionId) &&
            (!evaluacionParams.CursoId.HasValue || r.CursoId == evaluacionParams.CursoId))
        {
            AddInclude(r => r.TipoEvaluacion);
            AddInclude(r => r.Numeral);
            AddInclude(r => r.Curso);
            AddInclude(r => r.Curso.Escuela);
            AddInclude(r => r.Curso.Escuela.Institucion);

            ApplyPaging(evaluacionParams.PageSize * (evaluacionParams.PageIndex - 1), evaluacionParams.PageSize);
            
            if (!string.IsNullOrEmpty(evaluacionParams.Sort))
            {
                switch (evaluacionParams.Sort)
                {
                    case "fechaAsc":
                        AddOrderBy(r => r.Fecha);
                        break;
                    case "fechaDesc":
                        AddOrderByDescending(r => r.Fecha);
                        break;
                    default:
                        AddOrderBy(r => r.Fecha);
                        break;
                }
            }
        }

        public EvaluacionesConTodosLosIncludesSpecification(int id) : base(r => r.Id == id)
        {
            AddInclude(r => r.TipoEvaluacion);
            AddInclude(r => r.Numeral);
            AddInclude(r => r.Curso);
            AddInclude(r => r.Curso.Escuela);
            AddInclude(r => r.Curso.Escuela.Institucion);
        }
    }
}