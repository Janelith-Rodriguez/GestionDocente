using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IClaseAsistenciaServicio : IServicio<ClaseAsistencia>
    {
        Task<HttpRespuesta<List<ClaseAsistencia>>> GetByClase(int claseId);
        Task<HttpRespuesta<List<ClaseAsistencia>>> GetByCursadoMateria(int cursadoMateriaId);
        Task<HttpRespuesta<List<ClaseAsistencia>>> GetByAsistencia(char asistencia);
    }
}
