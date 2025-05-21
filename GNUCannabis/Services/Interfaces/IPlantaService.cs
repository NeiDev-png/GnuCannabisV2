using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface IPlantaService
    {
        Task<IEnumerable<PlantaDto>> GetAllAsync();
        Task<PlantaDto?> GetByIdAsync(int id);
        Task<IEnumerable<PlantaDto>> GetByCultivoIdAsync(int cultivoId);
        Task<PlantaDto> AddPlantaAsync(PlantaCreateUpdateDto planta);
        Task<PlantaDto> UpdatePlantaAsync(int id, PlantaCreateUpdateDto planta);
        Task<bool> DeletePlantaAsync(int id);
    }
}
