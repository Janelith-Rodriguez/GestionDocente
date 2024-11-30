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
        [MaxLength(60, ErrorMessage = "Máximo número de caracteres {1}.")]
        public int HrsRelojAnuales { get; set; }

        [Required(ErrorMessage = "Las horas de cátedra semanales son necesarias")]
        [MaxLength(60, ErrorMessage = "Máximo número de caracteres {1}.")]
        public int HrsCatedraSemanales { get; set; }

        [Required(ErrorMessage = "Saber si la materia es anual o cuatrimestral es necesario")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Anual_Cuatrimestral { get; set; }

        public int Anno { get; set; }
        public int? NumeroOrden { get; set; }
    }
}
