using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class EvaluacionInstitucionUrlResolver : IValueResolver<Evaluacion, EvaluacionDTO, string>
    {
        private readonly IConfiguration _config;

        public EvaluacionInstitucionUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Evaluacion source, EvaluacionDTO destination, string destMember, ResolutionContext context)
        {
            return $"{_config["ApiUrl"]}{source.Curso.Escuela.Institucion.ImagenUrl}";
        }
    }
}