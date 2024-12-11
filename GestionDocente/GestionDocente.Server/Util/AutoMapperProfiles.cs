using AutoMapper;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Shared.DTO;

namespace GestionDocente.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //ClaseAsistencia--------------------------------------------------------------------------------------------------
            CreateMap<CrearClaseAsistenciaDTO, ClaseAsistencia>();
            //Clase------------------------------------------------------------------------------------------------------------
            CreateMap<CrearClaseDTO, Clase>();
            //_usuario________________________________________________________________________________________________________________________________
            CreateMap<CrearUsuarioDTO, Usuario>();
            //CreateMap<UsuarioDTO, Usuario>();
            //CreateMap<Usuario, GetUsuarioDTO>()
            //                                .ForMember(dest => dest.NombrePersona, opt => opt.MapFrom(src => src.Persona.Nombre))
            //                                .ForMember(dest => dest.ApellidoPersona, opt => opt.MapFrom(src => src.Persona.Apellido))
            //                                .ForMember(dest => dest.DocumentoPersona, opt => opt.MapFrom(src => src.Persona.Documento))
            //                                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //                                .ForMember(dest => dest.Contrasena, opt => opt.MapFrom(src => src.Contrasena));

            //_Profesor_______________________________________________________________________________________________________________________________
            CreateMap<CrearProfesorDTO, Profesor>();
            //_Turno_______________________________________________________________________________________________________________________________
            CreateMap<CrearTurnoDTO, Turno>();


            CreateMap<CrearCursadoMateriaDTO, CursadoMateria>();
            CreateMap<CUPOFProfesorDTO, CUPOF_Profesor>();
        }
    }
}
