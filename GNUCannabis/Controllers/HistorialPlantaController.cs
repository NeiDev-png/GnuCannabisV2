using GNUCannabis.DTOs;
using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Implements;
using GNUCannabis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GNUCannabis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialPlantasController : ControllerBase
    {
        private readonly IHistorialPlantaService _historialPlantaService;

        public HistorialPlantasController(IHistorialPlantaService historialPlantaService)
        {
            _historialPlantaService = historialPlantaService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorialByPlantaId(int id)
        {
            var historial = await _historialPlantaService.GetHistorialPlantaByIdAsync(id);
            if (historial == null || !historial.Any()) // Verifica si el historial es nulo o está vacío
            {
                return NotFound("No se encontro historial para la planta"); // Devuelve un error 404 si el historial no se encuentra o está vacío
            }
            return Ok(historial);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddHistorialPlanta(int id, [FromBody] HistorialPlantaDto historialPlantaDTO)
        {
            if (historialPlantaDTO == null)
            {
                return BadRequest("El objeto HistorialPlantaDto no puede ser nulo.");
            }
            var nuevoHistorial = await _historialPlantaService.AddHistorialPlantaAsync(historialPlantaDTO, id);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistorialPlanta(int id, [FromBody] HistorialPlantaDto historialPlantaDTO)
        {
            if (historialPlantaDTO == null)
            {
                return BadRequest("El objeto HistorialPlantaDto no puede ser nulo.");
            }
            var historialActualizado = await _historialPlantaService.UpdateHistorialPlantaAsync(id, historialPlantaDTO);
            return Ok(historialActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialPlanta(int id)
        {
            var eliminado = await _historialPlantaService.DeleteHistorialPlantaAsync(id);

            if (!eliminado)
                return NotFound(); // 404: La planta no existe

            return NoContent(); // 204: Eliminado correctamente, sin contenido
        }
    }
}
