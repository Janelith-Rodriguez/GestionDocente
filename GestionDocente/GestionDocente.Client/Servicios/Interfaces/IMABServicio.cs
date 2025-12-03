using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IMABServicio : IServicio<MAB>
    {
        Task<HttpRespuesta<List<MAB>>> GetByProfesor(int profesorId);
        Task<HttpRespuesta<List<MAB>>> GetByCUPOFProfesor(int cupofProfesorId);
        Task<HttpRespuesta<MAB>> GetByIdMab(string idMab);
        Task<HttpRespuesta<List<MAB>>> GetBySitRevista(string sitRevista);
        Task<HttpRespuesta<List<MAB>>> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}