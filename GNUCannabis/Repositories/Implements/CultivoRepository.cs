using GNUCannabis.Models;
using GNUCannabis.Repositories.Implements;
using Microsoft.EntityFrameworkCore;

public class CultivoRepository : Repository<Cultivo>, ICultivoRepository
{
    public CultivoRepository(DbContext context) : base(context) { }

    async Task<Cultivo?> ICultivoRepository.GetByCultivoIdAsync(int cultivoId)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(c => c.IdTipoCultivoNavigation)
            .FirstOrDefaultAsync(c => c.IdCultivo == cultivoId);
    }

    async Task<IEnumerable<Cultivo>> ICultivoRepository.GetCultivosAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Include(c => c.IdTipoCultivoNavigation)
            .ToListAsync();
    }

}