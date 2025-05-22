using GNUCannabis.DTOs;


namespace GNUCannabis.Services.Interfaces
{
    public interface ICultivoService
    {
        // Operaciones b�sicas
        Task<IEnumerable<CultivoDto>> GetAllAsync();
        Task<CultivoDto?> GetByIdAsync(int id);
        Task<CultivoDto> AddCultivoAsync(CultivoCreateUpdateDto cultivo);
        Task<CultivoDto> UpdateCultivoAsync(int id, CultivoCreateUpdateDto cultivo);
        Task<bool> DeleteCultivoAsync(int id);
    }
}