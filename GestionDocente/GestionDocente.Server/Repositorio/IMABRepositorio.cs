using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IMABRepositorio : IRepositorio<MAB>
    {
        Task<List<MAB>> SelectByProfesor(int profesorId);
        Task<List<MAB>> SelectByCUPOFProfesor(int cupofProfesorId);
        Task<MAB> SelectByIdMab(string idMab);
        Task<List<MAB>> SelectBySitRevista(string sitRevista);
        Task<List<MAB>> SelectByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}

