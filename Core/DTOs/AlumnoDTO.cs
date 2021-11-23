using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AlumnoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Promedio { get; set; }
        public decimal Asistencia { get; set; }

        public string FullName
        {
            get { return Nombre + " " + Apellido; }
        }
    }
}
