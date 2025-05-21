using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;

public interface ICultivoRepository : IRepository<Cultivo>
{
    // Métodos específicos adicionales si son necesarios
    Task<IEnumerable<Cultivo>> GetCultivosAsync();
    Task<Cultivo?> GetByCultivoIdAsync(int cultivoId);
}
