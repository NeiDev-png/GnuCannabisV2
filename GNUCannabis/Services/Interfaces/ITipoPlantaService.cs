using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface ITiposPlantaService
    {
        Task<IEnumerable<TiposPlantaDto>> GetAllTiposPlantaAsync();
        Task<TiposPlantaDto> GetTipoPlantaByIdAsync(int id);
        Task AddTipoPlantaAsync(TiposPlantaDto tipoPlantaDTO);
        Task UpdateTipoPlantaAsync(int id, TiposPlantaDto tipoPlantaDTO);
        Task DeleteTipoPlantaAsync(int id);
    }
}
