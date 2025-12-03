using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearCorrelatividadDTO
    {
        [Required(ErrorMessage = "La materia en plan de estudio es obligatoria")]
        public int MateriaEnPlanEstudioId { get; set; }

        [Required(ErrorMessage = "La materia correlativa es obligatoria")]
        public int MateriaCorrelativaId { get; set; }
    }
}
