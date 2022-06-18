using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class EvaluacionesConTodosLosIncludesSpecification : BaseSpecification<Evaluacion>
    {
        public EvaluacionesConTodosLosIncludesSpecification()
        {
            AddInclude(r => r.TipoEvaluacion);
            AddInclude(r => r.Numeral);
            AddInclude(r => r.Curso);
            AddInclude(r => r.Curso.Escuela);
            AddInclude(r => r.Curso.Escuela.Institucion);
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