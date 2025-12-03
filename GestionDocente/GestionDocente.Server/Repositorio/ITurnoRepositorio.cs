using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ITurnoRepositorio : IRepositorio<Turno>
    {
        Task<List<Turno>> SelectByMateriaPlan(int materiaPlanId);
        Task<List<Turno>> SelectByProfesor(int profesorId);
        Task<List<Turno>> SelectByCicloLectivo(int annoCicloLectivo);
        Task<List<Turno>> SelectBySede(string sede);
    }
}
