using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IClaseRepositorio : IRepositorio<Clase>
    {
        Task<List<Clase>> SelectByTurno(int turnoId);
        Task<List<Clase>> SelectByFecha(DateTime fecha);
        Task<List<Clase>> SelectByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}
