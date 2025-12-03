using GestionDocente.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearMABDTO
    {
        [Required(ErrorMessage = "El profesor es obligatorio")]
        public int ProfesorId { get; set; }

        [Required(ErrorMessage = "El CUPOF del profesor es obligatorio")]
        public int CUPOF_ProfesorId { get; set; }

        [Required(ErrorMessage = "El Id del MAB es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string IdMab { get; set; }

        [Required(ErrorMessage = "La situación de revista es obligatoria")]
        [MaxLength(45, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string SitRevista { get; set; }

        [Required(ErrorMessage = "La Fecha de Inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La Fecha de Fin de contrato es obligatorio")]
        public DateTime FechaFin { get; set; }
    }
}
