namespace GNUCannabis.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICultivoRepository Cultivos { get; }
        IEstadosPlantaRepository EstadosPlantas { get; }
        IHistorialPlantaRepository HistorialPlantas { get; }
        IPersonaRepository Personas { get; }
        IPlantaRepository Plantas { get; }
        IRolRepository Roles { get; }
        ITiposCultivoRepository TiposCultivo { get; }
        ITiposDocumentoRepository TiposDocumento { get; }
        ITiposPlantaRepository TiposPlanta { get; }
        IUsuarioRepository Usuarios { get; }

        Task<int> CompleteAsync();
    }
}
