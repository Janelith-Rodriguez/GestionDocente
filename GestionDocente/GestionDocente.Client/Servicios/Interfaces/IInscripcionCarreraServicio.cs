using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IInscripcionCarreraServicio : IServicio<InscripcionCarrera>
    {
        Task<HttpRespuesta<List<InscripcionCarrera>>> GetByAlumno(int alumnoId);
        Task<HttpRespuesta<List<InscripcionCarrera>>> GetByCarrera(int carreraId);
        Task<HttpRespuesta<List<InscripcionCarrera>>> GetByCohorte(int cohorte);
        Task<HttpRespuesta<InscripcionCarrera>> GetByLegajo(string legajo);
    }
}