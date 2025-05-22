using AutoMapper;
using GNUCannabis.DTOs;
using GNUCannabis.Models;
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

        async Task<UsuarioDto> IUsuarioService.AddUsuarioAsync(UsuarioCreateUpdateDto usuarioDTO)
        {
            var usuario = new Usuario
            {
                IdPersona = usuarioDTO.IdPersona,
                ContrasenaHash = usuarioDTO.Contraseña,
                Correo = usuarioDTO.Correo,
                IdCultivo = usuarioDTO.IdCultivo,
                IdRol = usuarioDTO.IdRol
            };

            await _unitOfWork.Usuarios.AddAsync(usuario);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UsuarioDto>(usuario);
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

        async Task<UsuarioDto> IUsuarioService.GetUsuarioByIdAsync(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetUsuariosByIdAsync(id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return usuarioDto;
        }

        Task IUsuarioService.UpdateUsuarioAsync(int id, UsuarioDto usuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
