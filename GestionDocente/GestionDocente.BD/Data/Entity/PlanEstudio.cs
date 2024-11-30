using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    [Index(nameof(CarreraId), nameof(Anno), Name = "PlanEstudio_UQ", IsUnique = true)]
    [Index(nameof(CarreraId), Name = "PlanesDeUnaCarreraIDX", IsUnique = false)]
    public class PlanEstudio : EntityBase
    {
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        [Required(ErrorMessage = "El nombre del plan de estudio es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El año del plan es obligatorio")]
        public int Anno { get; set; }

        [Required(ErrorMessage = "El estado del plan es obligatorio")]
        public bool EstadoPlan { get; set; }

        public List<MateriaEnPlanEstudio> MateriasEnPlanEstudio = new List<MateriaEnPlanEstudio>();
    }
}
