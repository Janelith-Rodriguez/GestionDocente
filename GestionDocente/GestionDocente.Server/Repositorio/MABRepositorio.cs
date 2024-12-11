using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public class MABRepositorio : Repositorio<MAB>, IMABRepositorio
    {
        public MABRepositorio(Context context) : base(context)
        {
        }
    }
}

