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

        private readonly ICultivoService _cultivoService;

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



    }
}
