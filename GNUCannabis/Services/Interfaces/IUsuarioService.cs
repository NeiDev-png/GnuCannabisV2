using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
        Task<UsuarioDto> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(UsuarioDto usuarioDTO);
        Task UpdateUsuarioAsync(int id, UsuarioDto usuarioDTO);
        Task DeleteUsuarioAsync(int id);
    }
}
