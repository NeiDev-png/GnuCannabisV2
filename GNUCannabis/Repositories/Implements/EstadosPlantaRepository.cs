using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class EstadosPlantaRepository : Repository<EstadosPlanta>, IEstadosPlantaRepository
    {
        public EstadosPlantaRepository(DbContext context) : base(context) { }
    }
}
