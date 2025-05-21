using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        public PersonaRepository(DbContext context) : base(context) { }

        public async Task<Persona?> GetByDocumentoAsync(string numeroDocumento, int tipoDocumentoId)
        {
            return await _dbSet.FirstOrDefaultAsync(p =>
                p.NumeroDocumento == numeroDocumento && p.IdTipoDocumento == tipoDocumentoId);
        }
    }
}
