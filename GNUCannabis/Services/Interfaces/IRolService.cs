using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<RolDto>> GetAllRolesAsync();
        Task<RolDto> GetRolByIdAsync(int id);
        Task AddRolAsync(RolDto rolDTO);
        Task UpdateRolAsync(int id, RolDto rolDTO);
        Task DeleteRolAsync(int id);
    }
}
