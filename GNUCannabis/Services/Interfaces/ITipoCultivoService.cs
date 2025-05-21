using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface ITiposCultivoService
    {
        Task<IEnumerable<TiposCultivoDto>> GetAllTiposCultivoAsync();
        Task<TiposCultivoDto> GetTipoCultivoByIdAsync(int id);
        Task AddTipoCultivoAsync(TiposCultivoDto tipoCultivoDTO);
        Task UpdateTipoCultivoAsync(int id, TiposCultivoDto tipoCultivoDTO);
        Task DeleteTipoCultivoAsync(int id);
    }
}
