using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ITurnoServicio : IServicio<Turno>
    {
        Task<HttpRespuesta<List<Turno>>> GetByMateriaPlan(int materiaPlanId);
        Task<HttpRespuesta<List<Turno>>> GetByProfesor(int profesorId);
        Task<HttpRespuesta<List<Turno>>> GetByCicloLectivo(int annoCicloLectivo);
        Task<HttpRespuesta<List<Turno>>> GetBySede(string sede);
    }
}
