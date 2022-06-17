using Infraestructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitucionesController : ControllerBase
    {
        private readonly StoreContext _context;

        public InstitucionesController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Institucion>>> GetInstituciones()
        {
            var instituciones = await _context.Instituciones
                .OrderBy(r => r.Nombre)
                .ToListAsync();

            return Ok(instituciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Institucion>> GetInstitucion(int id) => Ok(await _context.Instituciones.FindAsync(id));
    }
}