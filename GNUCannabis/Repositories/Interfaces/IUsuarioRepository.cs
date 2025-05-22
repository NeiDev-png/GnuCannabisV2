using GNUCannabis.Models;

namespace GNUCannabis.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
    }
}
