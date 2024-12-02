using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public class TurnoRepositorio : Repositorio<Turno>, ITurnoRepositorio
    {
        public TurnoRepositorio(Context context) : base(context)
        {
        }
    }
}
