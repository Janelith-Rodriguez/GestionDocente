using GestionDocente.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearClaseAsistenciaDTO
    {

        [Required(ErrorMessage = "La clase es necesaria")]
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }

        [Required(ErrorMessage = "Poner si el alumno estuvo presente o ausente es necesario")]
        public char Asistencia { get; set; } 
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Observacion { get; set; } 
    }
}
