using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AsistenciaDTO
    {
        public int Id { get; set; }  
        public string Alumno { get; set; }
        public string Fecha { get; set; }
        public string Asistio { get; set; }
    }
}
