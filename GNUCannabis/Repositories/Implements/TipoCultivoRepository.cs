using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class TiposCultivoRepository : Repository<TiposCultivo>, ITiposCultivoRepository
    {
        public TiposCultivoRepository(DbContext context) : base(context) { }
    }
}
