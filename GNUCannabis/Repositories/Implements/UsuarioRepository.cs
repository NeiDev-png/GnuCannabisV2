using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context) { }

        async Task<IEnumerable<Usuario>> IUsuarioRepository.GetUsuariosAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(u => u.IdPersonaNavigation)
                .Include(u => u.IdRolNavigation)
                .Include(u => u.IdCultivoNavigation)
                .ToListAsync();
        }

        async Task<Usuario?> IUsuarioRepository.GetUsuariosByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(u => u.IdPersonaNavigation)
                .Include(u => u.IdRolNavigation)
                .Include(u => u.IdCultivoNavigation)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }
    }
}
