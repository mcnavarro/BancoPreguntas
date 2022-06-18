using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Evaluacion, EvaluacionDTO>()
                .ForMember(r => r.Curso, o => o.MapFrom(s => s.Curso.Nombre))
                .ForMember(r => r.Escuela, o => o.MapFrom(s => s.Curso.Escuela.Nombre))
                .ForMember(r => r.Institucion, o => o.MapFrom(s => s.Curso.Escuela.Institucion.Nombre))
                .ForMember(r => r.TipoEvaluacion, o => o.MapFrom(s => s.TipoEvaluacion.Nombre))
                .ForMember(r => r.Numeral, o => o.MapFrom(s => s.Numeral.Nombre))
                .ForMember(r => r.InstitucionUrl, o => o.MapFrom<EvaluacionInstitucionUrlResolver>())
                .ForMember(r => r.EscuelaUrl, o => o.MapFrom<EvaluacionEscuelaUrlResolver>());
        }
    }
}