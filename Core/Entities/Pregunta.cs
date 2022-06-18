using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Pregunta : BaseEntity
    {
        public Evaluacion Evaluacion { get; set; }
        public int EvaluacionId { get; set; }
        public string Descripcion { get; set; }
    }
}