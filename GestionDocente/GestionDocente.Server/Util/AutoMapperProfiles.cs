using AutoMapper;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Shared.DTO;

namespace GestionDocente.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Tablas Maestras
            CreateMap<CrearTipoDocumentoDTO, TipoDocumento>();
            CreateMap<CrearCarreraDTO, Carrera>();
            CreateMap<CrearMateriaDTO, Materia>();
            CreateMap<CrearPersonaDTO, Persona>();
            CreateMap<CrearPlanEstudioDTO, PlanEstudio>();
            CreateMap<CrearUsuarioDTO, Usuario>();

            // Entidades Relacionadas
            CreateMap<CrearAlumnoDTO, Alumno>();
            CreateMap<CrearProfesorDTO, Profesor>();
            CreateMap<CrearCoordinadorDTO, Coordinador>();
            CreateMap<CrearTurnoDTO, Turno>();
            CreateMap<CrearMateriaEnPlanEstudioDTO, MateriaEnPlanEstudio>();
            CreateMap<CrearInscripcionCarreraDTO, InscripcionCarrera>();
            CreateMap<CrearCursadoMateriaDTO, CursadoMateria>();
            CreateMap<CrearClaseDTO, Clase>();
            CreateMap<CrearEvaluacionDTO, Evaluacion>();
            CreateMap<CrearNotaDTO, Nota>();
            CreateMap<CrearClaseAsistenciaDTO, ClaseAsistencia>();
            CreateMap<CrearCorrelatividadDTO, Correlatividad>();
            CreateMap<CrearCertificadoAlumnoDTO, CertificadoAlumno>();
            CreateMap<CrearCUPOF_CoordinadorDTO, CUPOF_Coordinador>();
            CreateMap<CrearCUPOF_ProfesorDTO, CUPOF_Profesor>();
            CreateMap<CrearMABDTO, MAB>();
        }
    }
}
