using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class InstitucionRepository : IInstitucionRepository
    {
        private readonly StoreContext _context;
        public InstitucionRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Institucion> GetInstitucionByIdAsync(int id)
        {
            return await _context.Instituciones.FindAsync(id);
        }

        public async Task<IReadOnlyList<Institucion>> GetInstitucionesAsync()
        {
            return await _context.Instituciones.ToListAsync();
        }

        public async Task<IReadOnlyList<Evaluacion>> GetEvaluacionesAsync()
        {
            return await _context.Evaluaciones
                .Include(r => r.Curso)
                .Include(r => r.Numeral)
                .Include(r => r.TipoEvaluacion)
                .Include(r => r.Curso.Escuela)
                .Include(r => r.Curso.Escuela.Institucion)
                .ToListAsync();
        }
    }
}