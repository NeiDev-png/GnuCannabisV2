using AutoMapper;
using GNUCannabis.DTOs;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Interfaces;

namespace GNUCannabis.Services.Implements
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        Task IUsuarioService.AddUsuarioAsync(UsuarioDto usuarioDTO)
        {
            throw new NotImplementedException();
        }

        Task IUsuarioService.DeleteUsuarioAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<UsuarioDto>> IUsuarioService.GetAllUsuariosAsync()
        {
            var usuarios = await _unitOfWork.Usuarios.GetUsuariosAsync();

            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        Task<UsuarioDto> IUsuarioService.GetUsuarioByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IUsuarioService.UpdateUsuarioAsync(int id, UsuarioDto usuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
