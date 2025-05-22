using GNUCannabis.DTOs;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Implements;
using GNUCannabis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GNUCannabis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuariosById(int id)
        {
            var dto = await _usuarioService.GetUsuarioByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);

        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuario([FromBody] UsuarioCreateUpdateDto usuarioCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioCreado = await _usuarioService.AddUsuarioAsync(usuarioCreateDto);


            return StatusCode(201);

        }
    }
}
