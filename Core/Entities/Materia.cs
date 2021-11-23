using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Materia : BaseEntity
    {
        public string Nombre { get; set; }
        public int DocenteId { get; set; }
        public virtual Docente Docente { get; set; }
    }
}
