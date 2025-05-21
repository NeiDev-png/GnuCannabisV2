using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class HistorialPlantaRepository : Repository<HistorialPlanta>, IHistorialPlantaRepository
    {
        public HistorialPlantaRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<HistorialPlanta>> GetByPlantaIdAsync(int plantaId)
        {
            return await _dbSet.Where(h => h.IdPlanta == plantaId).ToListAsync();
        }

        async Task<HistorialPlanta?> IHistorialPlantaRepository.GetByHistorialIdAsync(int historialId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(h => h.IdPlantaNavigation)
                .FirstOrDefaultAsync(h => h.IdHistorial == historialId);
        }
    }
}
