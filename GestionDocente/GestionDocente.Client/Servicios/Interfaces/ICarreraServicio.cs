using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICarreraServicio : IServicio<Carrera>
    {
        Task<HttpRespuesta<Carrera>> GetByNombre(string nombre);
    }
}