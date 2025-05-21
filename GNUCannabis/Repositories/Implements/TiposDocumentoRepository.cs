using GNUCannabis.Models;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Repositories.Implements
{
    public class TiposDocumentoRepository : Repository<TiposDocumento>, ITiposDocumentoRepository
    {
        public TiposDocumentoRepository(DbContext context) : base(context) { }
    }
}
