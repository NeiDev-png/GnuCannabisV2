using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(DbContext context) : base(context) { }
    }
}
