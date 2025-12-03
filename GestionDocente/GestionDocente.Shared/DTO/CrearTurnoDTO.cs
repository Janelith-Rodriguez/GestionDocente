using GestionDocente.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearTurnoDTO
    {
        public int? ProfesorId { get; set; }

        [Required(ErrorMessage = "La materia en plan de estudio es obligatoria")]
        public int MateriaEnPlanEstudioId { get; set; }

        [Required(ErrorMessage = "La sede es obligatoria")]
        [MaxLength(45, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Sede { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Horario { get; set; }

        [Required(ErrorMessage = "El ciclo lectivo es obligatorio")]
        public int AnnoCicloLectivo { get; set; }
    }
}
