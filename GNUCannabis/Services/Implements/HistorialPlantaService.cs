using AutoMapper;
using GNUCannabis.DTOs;
using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Interfaces;

namespace GNUCannabis.Services.Implements
{
    public class HistorialPlantaService : IHistorialPlantaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HistorialPlantaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<IEnumerable<HistorialPlantaDto>> IHistorialPlantaService.GetHistorialPlantaByIdAsync(int id)
        {
            var historial = await _unitOfWork.HistorialPlantas.GetByPlantaIdAsync(id);

            var historialDto = _mapper.Map<IEnumerable<HistorialPlantaDto>>(historial);
            return historialDto;
        }
        async Task<HistorialPlantaDto> IHistorialPlantaService.AddHistorialPlantaAsync(HistorialPlantaDto historialPlantaDTO, int id)
        {
            var historial = new HistorialPlanta
            {
                Descripcion = historialPlantaDTO.Descripcion,
                Fecha = historialPlantaDTO.Fecha,
                IdPlanta = id,
            };

            await _unitOfWork.HistorialPlantas.AddAsync(historial);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<HistorialPlantaDto>(historial);
        }

        async Task<HistorialPlantaDto> IHistorialPlantaService.UpdateHistorialPlantaAsync(int id, HistorialPlantaDto historialPlantaDTO)
        {
            var historialExistente = await _unitOfWork.HistorialPlantas.GetByHistorialIdAsync(id);
            historialExistente.Descripcion = historialPlantaDTO.Descripcion;
            historialExistente.Fecha = historialPlantaDTO.Fecha;

            _unitOfWork.HistorialPlantas.Update(historialExistente);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<HistorialPlantaDto>(historialExistente);
        }
        async Task<bool> IHistorialPlantaService.DeleteHistorialPlantaAsync(int id)
        {
            var historialExistente = await _unitOfWork.HistorialPlantas.GetByHistorialIdAsync(id);
            if (historialExistente == null)
                return false;

            _unitOfWork.HistorialPlantas.Delete(historialExistente);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}

