using GNUCannabis.DTOs;
using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GNUCannabis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantasController : ControllerBase
    {
        private readonly IPlantaService _plantaService;

        public PlantasController(IPlantaService plantaService)
        {
            _plantaService = plantaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dto = await _plantaService.GetAllAsync();
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _plantaService.GetByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpGet("cultivo/{cultivoId:int}")]
        public async Task<IActionResult> GetPlantasByCultivo(int cultivoId)
        {
            var plantas = await _plantaService.GetByCultivoIdAsync(cultivoId);

            if (plantas is null || !plantas.Any())
                return NoContent();          // 204 si no hay resultados

            return Ok(plantas);              // 200 con la lista
        }


        [HttpPost]
        public async Task<IActionResult> CreatePlanta([FromBody] PlantaCreateUpdateDto plantaCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var plantaCreada = await _plantaService.AddPlantaAsync(plantaCreateDto);


            return StatusCode(201);
        }


        [HttpPut("{id}")] // Usa PUT y especifica el ID en la ruta
        public async Task<IActionResult> UpdatePlanta(int id, [FromBody] PlantaCreateUpdateDto plantaUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 si el modelo no es válido
            }

            try
            {
                var plantaActualizada = await _plantaService.UpdatePlantaAsync(id, plantaUpdateDto);
                return Ok(plantaActualizada); // Devuelve 200 OK con la planta actualizada
            }
            catch (Exception) // Captura la excepción NotFoundException
            {
                return NotFound(); // Devuelve 404 si la planta no se encuentra
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantaAsync(int id)
        {
            var eliminado = await _plantaService.DeletePlantaAsync(id);

            if (!eliminado)
                return NotFound(); // 404: La planta no existe

            return NoContent(); // 204: Eliminado correctamente, sin contenido
        }
    }
}
