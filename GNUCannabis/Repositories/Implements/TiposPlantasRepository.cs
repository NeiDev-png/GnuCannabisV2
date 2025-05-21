using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class TiposPlantasRepository
    {
        public class TiposPlantaRepository : Repository<TiposPlanta>, ITiposPlantaRepository
        {
            public TiposPlantaRepository(DbContext context) : base(context) { }
        }
    }
}
