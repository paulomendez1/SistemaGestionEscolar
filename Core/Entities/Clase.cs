using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Clase :BaseEntity
    {
        public string Fecha { get; set; }
        public int DocenteId { get; set; }
        public virtual List<Asistencia> Asistencias { get; set; }
        public virtual Docente Docente { get; set; }
    }
}
