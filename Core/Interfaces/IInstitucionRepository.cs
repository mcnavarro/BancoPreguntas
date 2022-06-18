using Core.Entities;

namespace Core.Interfaces
{
    public interface IInstitucionRepository
    {
        Task<Institucion> GetInstitucionByIdAsync(int id);
        Task<IReadOnlyList<Institucion>> GetInstitucionesAsync();
        Task<IReadOnlyList<Evaluacion>> GetEvaluacionesAsync();
    }
}