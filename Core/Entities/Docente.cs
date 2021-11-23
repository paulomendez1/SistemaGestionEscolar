using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Docente : BaseEntity
    {
        public Docente()
        {

        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Sueldo { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<Materia> Materias { get; set; }
    }
}
