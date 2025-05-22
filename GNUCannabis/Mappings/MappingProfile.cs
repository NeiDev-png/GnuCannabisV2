// MappingProfile.cs
using AutoMapper;
using GNUCannabis.Models;
using GNUCannabis.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Definir mapeo de cada entidad a su DTO respectivo
        CreateMap<Cultivo, CultivoDto>();
        CreateMap<Cultivo, CultivoDto>()
            .ForMember(dest => dest.TipoCultivo, opt => opt.MapFrom(src => src.IdTipoCultivoNavigation.NombreTipo));
        CreateMap<Cultivo, CultivoCreateUpdateDto>();
        CreateMap<CultivoCreateUpdateDto, Cultivo>();

        CreateMap<HistorialPlanta, HistorialPlantaDto>();
        CreateMap<EstadosPlanta, EstadosPlantaDto>();
        CreateMap<Persona, PersonaDto>();


        CreateMap<Planta, PlantaDto>()
            .ForMember(dest => dest.Cultivo, opt => opt.MapFrom(src => src.IdCultivoNavigation.Nombre))
            .ForMember(dest => dest.TipoPlanta, opt => opt.MapFrom(src => src.IdTipoPlantaNavigation.NombreTipo))
            .ForMember(dest => dest.EstadoPlanta, opt => opt.MapFrom(src => src.IdEstadoPlantaNavigation.NombreEstado));
        CreateMap<PlantaCreateUpdateDto, Planta>();
        CreateMap<Planta, PlantaCreateUpdateDto>();


        CreateMap<Rol, RolDto>();
        CreateMap<TiposDocumento, TipoDocumentoDto>();
        CreateMap<TiposPlanta, TiposPlantaDto>();
        CreateMap<Usuario, UsuarioDto>();

        //CreateMap<Usuario, UsuarioDto>()
        //    .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => src.IdPersonaNavigation.NombreCompleto)) // Cambia "Nombre" si el campo tiene otro nombre en Persona
        //    .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.IdRolNavigation.NombreRol)) // Cambia "Nombre" si el campo tiene otro nombre en Rol
        //    .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
        //    .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
        //    .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario));


         CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Persona,
                    opt => opt.MapFrom(src => src.IdPersonaNavigation.NombreCompleto))
                .ForMember(dest => dest.Rol,
                    opt => opt.MapFrom(src => src.IdRolNavigation.NombreRol))
                .ForMember(dest => dest.Estado,
                    opt => opt.MapFrom(src => src.Estado ? "Activo" : "Inactivo"))
                .ForMember(dest => dest.Cultivo,
                    opt => opt.MapFrom(src => src.IdCultivoNavigation != null ? src.IdCultivoNavigation.Nombre : null));

        CreateMap<UsuarioCreateUpdateDto, Usuario>()
            .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.IdPersona))
            .ForMember(dest => dest.ContrasenaHash, opt => opt.MapFrom(src => src.Contraseña)) // si luego querés hashear, cambiamos esto
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado == 1));


        CreateMap<TiposCultivo, TiposCultivoDto>();
    }
}
