using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface ITipoDocumentoService
    {
        Task<IEnumerable<TipoDocumentoDto>> GetAllTiposDocumentoAsync();
        Task<TipoDocumentoDto> GetTipoDocumentoByIdAsync(int id);
        Task AddTipoDocumentoAsync(TipoDocumentoDto tipoDocumentoDTO);
        Task UpdateTipoDocumentoAsync(int id, TipoDocumentoDto tipoDocumentoDTO);
        Task DeleteTipoDocumentoAsync(int id);
    }
}
