using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class PlantaRepository : Repository<Planta>, IPlantaRepository
    {
        public PlantaRepository(DbContext context) : base(context) { }

        async Task<List<Planta>> IPlantaRepository.GetPlantasAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.IdCultivoNavigation)
                .Include(p => p.IdTipoPlantaNavigation)
                .Include(p => p.IdEstadoPlantaNavigation)
                .ToListAsync();
        }

        async Task<Planta?> IPlantaRepository.GetByPlantaIdAsync(int plantaId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.IdCultivoNavigation)
                .Include(p => p.IdTipoPlantaNavigation)
                .Include(p => p.IdEstadoPlantaNavigation)
                .FirstOrDefaultAsync(p => p.IdPlanta == plantaId);
        }

        async Task<IEnumerable<Planta>> IPlantaRepository.GetByCultivoIdAsync(int cultivoId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.IdCultivoNavigation)
                .Include(p => p.IdTipoPlantaNavigation)
                .Include(p => p.IdEstadoPlantaNavigation)
                .Where(p => p.IdCultivo == cultivoId)
                .ToListAsync();
        }
    }
}
