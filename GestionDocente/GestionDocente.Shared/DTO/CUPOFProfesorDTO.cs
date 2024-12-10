
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Shared.DTO
{
    public class CUPOFProfesorDTO
    {


        public string CUPOF { get; }

        [Required(ErrorMessage = "Ver si el CUPOF está ocpuado o libre ")]
       
        public string Ocupado_Libre { get; } //para ver si el puesto del CUPOF está ya ocupado o no

        public bool Estado { get; }
    }
}