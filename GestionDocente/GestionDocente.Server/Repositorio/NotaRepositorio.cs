using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public class NotaRepositorio : Repositorio<Nota>, INotaRepositorio
    {
        public NotaRepositorio(Context context) : base(context)
        {
        }
    }
}

