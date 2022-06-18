using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class EvaluacionEscuelaUrlResolver : IValueResolver<Evaluacion, EvaluacionDTO, string>
    {
        private readonly IConfiguration _config;

        public EvaluacionEscuelaUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Evaluacion source, EvaluacionDTO destination, string destMember, ResolutionContext context)
        {
            return $"{_config["ApiUrl"]}{source.Curso.Escuela.ImagenUrl}";
        }
    }
}