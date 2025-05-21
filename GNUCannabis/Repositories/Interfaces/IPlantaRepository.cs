using GNUCannabis.Models;

namespace GNUCannabis.Repositories.Interfaces
{
    public interface IPlantaRepository : IRepository<Planta>
    {
        Task<Planta?> GetByPlantaIdAsync(int plantaId);
        Task<List<Planta>> GetPlantasAsync();
        Task<IEnumerable<Planta>> GetByCultivoIdAsync(int cultivoId);
    }
}
