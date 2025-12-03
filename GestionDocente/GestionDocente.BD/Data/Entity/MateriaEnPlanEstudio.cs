using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    [Index(nameof(PlanEstudioId), nameof(MateriaId), Name = "MateriaEnPlanEstudio_UQ", IsUnique = true)]
    public class MateriaEnPlanEstudio : EntityBase
    {
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        public int PlanEstudioId { get; set; }
        public PlanEstudio PlanEstudio { get; set; }

        [Required(ErrorMessage = "Las horas de reloj anuales son necesarias")]
        [Range(1, 9999, ErrorMessage = "Las horas de reloj deben estar entre {1} y {2}")]
        public int HrsRelojAnuales { get; set; }

        [Required(ErrorMessage = "Las horas de cátedra semanales son necesarias")]
        [Range(1, 100, ErrorMessage = "Las horas de cátedra deben estar entre {1} y {2}")]
        public int HrsCatedraSemanales { get; set; }

        [Required(ErrorMessage = "Saber si la materia es anual o cuatrimestral es necesario")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Anual_Cuatrimestral { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(1, 6, ErrorMessage = "El año debe estar entre {1} y {2}")]
        public int Anno { get; set; }

        [Range(1, 20, ErrorMessage = "El número de orden debe estar entre {1} y {2}")]
        public int? NumeroOrden { get; set; }
    }
}
