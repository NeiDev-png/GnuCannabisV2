using GNUCannabis.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNUCannabis.Services.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAllPersonasAsync();
        Task<PersonaDto> GetPersonaByIdAsync(int id);
        Task AddPersonaAsync(PersonaDto personaDTO);
        Task UpdatePersonaAsync(int id, PersonaDto personaDTO);
        Task DeletePersonaAsync(int id);
    }
}
