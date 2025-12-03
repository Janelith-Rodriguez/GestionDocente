using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface INotaServicio : IServicio<Nota>
    {
        Task<HttpRespuesta<List<Nota>>> GetByEvaluacion(int evaluacionId);
        Task<HttpRespuesta<List<Nota>>> GetByCursadoMateria(int cursadoMateriaId);
        Task<HttpRespuesta<List<Nota>>> GetByValor(int valorNota);
    }
}
