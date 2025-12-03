using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearClaseDTO
    {
        [Required(ErrorMessage = "El turno es obligatorio")]
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "La fecha de clase es obligatoria")]
        public DateTime Fecha { get; set; }
    }
}
