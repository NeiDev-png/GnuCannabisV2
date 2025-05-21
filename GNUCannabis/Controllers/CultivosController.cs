using GNUCannabis.DTOs;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Implements;
using GNUCannabis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GNUCannabis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivosController : ControllerBase
    {

        private readonly ICultivoService _cultivoService;


        public CultivosController(ICultivoService cultivoService)
        {
            _cultivoService = cultivoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dto = await _cultivoService.GetAllAsync();
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _cultivoService.GetByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> PostCultivo([FromBody] CultivoCreateUpdateDto cultivoCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var plantaCreada = await _cultivoService.AddCultivoAsync(cultivoCreateDto);


            return StatusCode(201);
        }

        [HttpPut("{id}")] // Usa PUT y especifica el ID en la ruta
        public async Task<IActionResult> PutCultivo(int id, [FromBody] CultivoCreateUpdateDto cultivoUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }
            try
            {
                var plantaActualizada = await _cultivoService.UpdateCultivoAsync(id, cultivoUpdateDto);
                return Ok(plantaActualizada); // Devuelve 200 OK con la planta actualizada
            }
            catch (Exception) // Captura la excepción NotFoundException
            {
                return NotFound(); // Devuelve 404 si la planta no se encuentra
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCultivoAsync(int id)
        {
            var eliminado = await _cultivoService.DeleteCultivoAsync(id);

            if (!eliminado)
                return NotFound(); // 404: La planta no existe

            return NoContent(); // 204: Eliminado correctamente, sin contenido
        }

    }
}
