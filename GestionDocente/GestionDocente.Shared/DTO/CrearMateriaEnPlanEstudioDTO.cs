using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearMateriaEnPlanEstudioDTO
    {
        [Required(ErrorMessage = "La materia es obligatoria")]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "El plan de estudio es obligatorio")]
        public int PlanEstudioId { get; set; }

        [Required(ErrorMessage = "Las horas de reloj anuales son necesarias")]
        public int HrsRelojAnuales { get; set; }

        [Required(ErrorMessage = "Las horas de cátedra semanales son necesarias")]
        public int HrsCatedraSemanales { get; set; }

        [Required(ErrorMessage = "El tipo de duración es necesario")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Anual_Cuatrimestral { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        public int Anno { get; set; }

        public int? NumeroOrden { get; set; }
    }
}
