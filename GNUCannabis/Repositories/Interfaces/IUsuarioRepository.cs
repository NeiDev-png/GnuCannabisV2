using GNUCannabis.Models;

namespace GNUCannabis.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> AuthenticateAsync(string email, string passwordHash);
    }
}
