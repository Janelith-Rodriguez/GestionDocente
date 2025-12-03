using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IInscripcionCarreraRepositorio : IRepositorio<InscripcionCarrera>
    {
        Task<List<InscripcionCarrera>> SelectByAlumno(int alumnoId);
        Task<List<InscripcionCarrera>> SelectByCarrera(int carreraId);
        Task<List<InscripcionCarrera>> SelectByCohorte(int cohorte);
        Task<InscripcionCarrera> SelectByLegajo(string legajo);
    }
}
