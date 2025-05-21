using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface IHistorialPlantaService
    {
        Task<IEnumerable<HistorialPlantaDto>> GetHistorialPlantaByIdAsync(int id);
        Task<HistorialPlantaDto> AddHistorialPlantaAsync(HistorialPlantaDto historialPlantaDTO, int id);
        Task<HistorialPlantaDto> UpdateHistorialPlantaAsync(int id, HistorialPlantaDto historialPlantaDTO);
        Task<bool> DeleteHistorialPlantaAsync(int id);
    }
}
