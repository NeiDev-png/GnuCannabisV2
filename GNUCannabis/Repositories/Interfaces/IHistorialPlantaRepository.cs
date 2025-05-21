using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;


namespace GNUCannabis.Repositories.Interfaces
{
    public interface IHistorialPlantaRepository : IRepository<HistorialPlanta>
    {
        Task<IEnumerable<HistorialPlanta>> GetByPlantaIdAsync(int plantaId);
        Task<HistorialPlanta?> GetByHistorialIdAsync(int historialId);
    }
}