using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitucionesController : ControllerBase
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
        public async Task<ActionResult<Institucion>> GetInstitucion(int id)
        {
            return Ok(await _institucionRepo.GetByIdAsync(id));
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