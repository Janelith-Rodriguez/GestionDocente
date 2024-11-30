using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    [Index(nameof(IdMab), Name = "MABUnico_UQ", IsUnique = true)]
    public class MAB : EntityBase
    {
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }


        public int CUPOF_ProfesorId { get; set; }
        public CUPOF_Profesor CUPOF_Profesor { get; set; }

        [Required(ErrorMessage = "El Id del MAB (código del MAB) es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string IdMab { get; set; }

        [Required(ErrorMessage = "La situacion revista es obligatoria")]
        [MaxLength(45, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string SitRevista { get; set; }

        [Required(ErrorMessage = "La Fecha de Inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La Fecha de Fin de contrato es obligatorio")]
        public DateTime FechaFin { get; set; }
    }
}
