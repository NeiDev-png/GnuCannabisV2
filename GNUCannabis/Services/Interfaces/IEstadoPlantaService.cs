using GNUCannabis.DTOs;

namespace GNUCannabis.Services.Interfaces
{
    public interface IEstadoPlantaService
    {
        Task<IEnumerable<EstadosPlantaDto>> GetAllEstadosPlantaAsync();
        Task<EstadosPlantaDto> GetEstadoPlantaByIdAsync(int id);
        Task AddEstadoPlantaAsync(EstadosPlantaDto estadoPlantaDTO);
        Task UpdateEstadoPlantaAsync(int id, EstadosPlantaDto estadoPlantaDTO);
        Task DeleteEstadoPlantaAsync(int id);
    }
}
