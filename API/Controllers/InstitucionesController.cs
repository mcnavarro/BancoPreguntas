using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using AutoMapper;
using API.Errors;

namespace API.Controllers
{
    public class InstitucionesController : BaseApiController
    {
        private readonly IGenericRepository<Institucion> _institucionRepo;
        private readonly IGenericRepository<Escuela> _escuelaRepo;
        private readonly IGenericRepository<Curso> _cursoRepo;
        private readonly IGenericRepository<Evaluacion> _evaluacionRepo;
        private readonly IMapper _mapper;

        public InstitucionesController(IGenericRepository<Institucion> institucionRepo,
                                       IGenericRepository<Escuela> EscuelaRepo,
                                       IGenericRepository<Curso> cursoRepo,
                                       IGenericRepository<Evaluacion> evaluacionRepo,
                                       IMapper mapper)
        {
            _institucionRepo = institucionRepo;
            _escuelaRepo = EscuelaRepo;
            _cursoRepo = cursoRepo;
            _evaluacionRepo = evaluacionRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Institucion>>> GetInstituciones()
        {
            return Ok(await _institucionRepo.ListAsync(new BaseSpecification<Institucion>()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Institucion>> GetInstitucion(int id)
        {
            var institucion = await _institucionRepo.GetByIdAsync(id);

            if (institucion == null) return NotFound(new ApiResponse(404));

            return Ok(institucion);
        }

        [HttpGet("evaluaciones")]
        public async Task<ActionResult<IReadOnlyList<EvaluacionDTO>>> GetEvaluaciones()
        {
            var spec = new EvaluacionesConTodosLosIncludesSpecification();

            var evaluaciones = await _evaluacionRepo
                .ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Evaluacion>, IReadOnlyList<EvaluacionDTO>>(evaluaciones));
        }

        [HttpGet("escuelas")]
        public async Task<ActionResult<IReadOnlyList<Escuela>>> GetEscuelas()
        {
            return Ok(await _escuelaRepo.ListAllAsync());
        }
    }
}