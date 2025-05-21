using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context) { }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Correo == email);
        }

        public async Task<Usuario?> AuthenticateAsync(string email, string passwordHash)
        {
            return await _dbSet.FirstOrDefaultAsync(u =>
                u.Correo == email && u.ContrasenaHash == passwordHash);
        }
    }
}
