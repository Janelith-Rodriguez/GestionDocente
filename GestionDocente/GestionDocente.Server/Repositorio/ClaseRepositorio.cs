using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class ClaseRepositorio : Repositorio<Clase>, IClaseRepositorio 
    {
        private readonly Context context;

        public ClaseRepositorio(Context context): base(context)
        {
            this.context = context;
        }

    }
}
