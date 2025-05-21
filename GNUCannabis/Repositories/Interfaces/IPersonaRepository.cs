using GNUCannabis.Models;

namespace GNUCannabis.Repositories.Interfaces
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<Persona?> GetByDocumentoAsync(string numeroDocumento, int tipoDocumentoId);
    }
}
