using AutoMapper;
using GNUCannabis.DTOs;
using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Interfaces;

namespace GNUCannabis.Services.Implements
{

    public class CultivoService : ICultivoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CultivoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<CultivoDto> ICultivoService.AddCultivoAsync(CultivoCreateUpdateDto cultivoCreateDto)
        {
            var cultivo = new Cultivo
            {
                Nombre = cultivoCreateDto.Nombre,
                IdTipoCultivo = cultivoCreateDto.idTipoCultivo
            };

            await _unitOfWork.Cultivos.AddAsync(cultivo);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CultivoDto>(cultivo);
        }

        async Task<IEnumerable<CultivoDto>> ICultivoService.GetAllAsync()
        {
            var cultivos = await _unitOfWork.Cultivos.GetCultivosAsync();

            // Mapear los modelos a DTOs (simplificado)
            var cultivoDtos = _mapper.Map<IEnumerable<CultivoDto>>(cultivos);

            return cultivoDtos;
        }

        async Task<CultivoDto?> ICultivoService.GetByIdAsync(int id)
        {
            var cultivo = await _unitOfWork.Cultivos.GetByCultivoIdAsync(id);

            var cultivoDto = _mapper.Map<CultivoDto>(cultivo);
            return cultivoDto;
        }
        async Task<CultivoDto> ICultivoService.UpdateCultivoAsync(int id, CultivoCreateUpdateDto cultivo)
        {
            var cultivoExistente = await _unitOfWork.Cultivos.GetByCultivoIdAsync(id);
            cultivoExistente.Nombre = cultivo.Nombre;
            cultivoExistente.IdTipoCultivo = cultivo.idTipoCultivo;
            _unitOfWork.Cultivos.Update(cultivoExistente);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CultivoDto>(cultivoExistente);
        }

        async Task<bool> ICultivoService.DeleteCultivoAsync(int id)
        {
            var cultivoExistente = await _unitOfWork.Cultivos.GetByIdAsync(id);
            if (cultivoExistente == null)
                return false;

            _unitOfWork.Cultivos.Delete(cultivoExistente);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
