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

        async Task<UsuarioDto> IUsuarioService.UpdateUsuarioAsync(int id, UsuarioCreateUpdateDto usuarioDTO)
        {
            var usuarioExistente = await _unitOfWork.Usuarios.GetUsuariosByIdAsync(id);

            // 2. Aplicar las modificaciones
            usuarioExistente.Correo = usuarioDTO.Correo;
            usuarioExistente.IdCultivo = usuarioDTO.IdCultivo;
            usuarioExistente.IdRol= usuarioDTO.IdRol;

            // 3. Actualizar la entidad
            _unitOfWork.Usuarios.Update(usuarioExistente);

            // 4. Guardar los cambios
            await _unitOfWork.CompleteAsync();

            // 5. Devolver el DTO actualizado
            return _mapper.Map<UsuarioDto>(usuarioExistente);
        }
    }
}
