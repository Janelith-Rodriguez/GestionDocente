using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class Correlatividad : EntityBase
    {
        public int MateriaEnPlanEstudioId { get; set; }
        public MateriaEnPlanEstudio MateriaEnPlanEstudio { get; set; }


        public int MateriaCorrelativaId { get; set; }
        public MateriaEnPlanEstudio MateriaCorrelativa { get; set; }
    }
}
