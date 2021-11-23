using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Asistencia : BaseEntity
    {
        public int Asistio { get; set; }
        public int AlumnoId { get; set; }
        public int ClaseId { get; set; }
        public virtual Alumno Alumno { get; set; }
        public virtual Clase Clase { get; set; }
    }
}
