using AutoMapper;
using GNUCannabis.DTOs;
using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using GNUCannabis.Services.Interfaces;

namespace GNUCannabis.Services.Implements
{
    public class PlantaService : IPlantaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public PlantaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET TODAS LAS PLANTAS
        async Task<IEnumerable<PlantaDto>> IPlantaService.GetAllAsync()
        {
            var plantas = await _unitOfWork.Plantas.GetPlantasAsync();

            var plantasDto = _mapper.Map<IEnumerable<PlantaDto>>(plantas);


            return plantasDto;
        }


        // GET TODAS LAS PLANTAS POR CULTIVO
        async Task<IEnumerable<PlantaDto>> IPlantaService.GetByCultivoIdAsync(int cultivoId)
        {
            var plantas = await _unitOfWork.Plantas.GetByCultivoIdAsync(cultivoId);
            var plantasDto = _mapper.Map<IEnumerable<PlantaDto>>(plantas);
            return plantasDto;
        }
        // GET PLANTA POR ID
        async Task<PlantaDto?> IPlantaService.GetByIdAsync(int id)
        {
            var planta = await _unitOfWork.Plantas.GetByPlantaIdAsync(id);
            var plantasDto = _mapper.Map<PlantaDto>(planta);

            return plantasDto;
        }

        //POST PLANTA
        async Task<PlantaDto> IPlantaService.AddPlantaAsync(PlantaCreateUpdateDto plantaCreateDto)
        {
            var planta = new Planta
            {
                Nombre = plantaCreateDto.Nombre,
                IdCultivo = plantaCreateDto.IdCultivo,
                IdTipoPlanta = plantaCreateDto.IdTipoPlanta,
                IdEstadoPlanta = plantaCreateDto.IdEstadoPlanta
            };

            await _unitOfWork.Plantas.AddAsync(planta);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PlantaDto>(planta);
        }


        //PUT PLANTA
        async Task<PlantaDto> IPlantaService.UpdatePlantaAsync(int id, PlantaCreateUpdateDto plantaUpdateDto)
        {
            // 1. Obtener la entidad existente de la base de datos
            var plantaExistente = await _unitOfWork.Plantas.GetByPlantaIdAsync(id);

            // 2. Aplicar las modificaciones
            plantaExistente.Nombre = plantaUpdateDto.Nombre;
            plantaExistente.IdCultivo = plantaUpdateDto.IdCultivo;
            plantaExistente.IdTipoPlanta = plantaUpdateDto.IdTipoPlanta;
            plantaExistente.IdEstadoPlanta = plantaUpdateDto.IdEstadoPlanta;

            // 3. Actualizar la entidad
            _unitOfWork.Plantas.Update(plantaExistente);

            // 4. Guardar los cambios
            await _unitOfWork.CompleteAsync();

            // 5. Devolver el DTO actualizado
            return _mapper.Map<PlantaDto>(plantaExistente);
        }

        //DELETE PLANTA
        async Task<bool> IPlantaService.DeletePlantaAsync(int id)
        {
            var plantaExistente = await _unitOfWork.Plantas.GetByIdAsync(id);
            if (plantaExistente == null)
                return false;

            _unitOfWork.Plantas.Delete(plantaExistente);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}