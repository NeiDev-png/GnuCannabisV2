using GNUCannabis.Data;
using GNUCannabis.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static GNUCannabis.Repositories.Implements.TiposPlantasRepository;

namespace GNUCannabis.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GNUCannabisDbContext _context;

        public UnitOfWork(GNUCannabisDbContext context)
        {
            _context = context;
            Cultivos = new CultivoRepository(_context);
            EstadosPlantas = new EstadosPlantaRepository(_context);
            HistorialPlantas = new HistorialPlantaRepository(_context);
            Personas = new PersonaRepository(_context);
            Plantas = new PlantaRepository(_context);
            Roles = new RolRepository(_context);
            TiposCultivo = new TiposCultivoRepository(_context);
            TiposDocumento = new TiposDocumentoRepository(_context);
            TiposPlanta = new TiposPlantaRepository(_context);
            Usuarios = new UsuarioRepository(_context);
        }

        public ICultivoRepository Cultivos { get; }
        public IEstadosPlantaRepository EstadosPlantas { get; }
        public IHistorialPlantaRepository HistorialPlantas { get; }
        public IPersonaRepository Personas { get; }
        public IPlantaRepository Plantas { get; }
        public IRolRepository Roles { get; }
        public ITiposCultivoRepository TiposCultivo { get; }
        public ITiposDocumentoRepository TiposDocumento { get; }
        public ITiposPlantaRepository TiposPlanta { get; }
        public IUsuarioRepository Usuarios { get; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
