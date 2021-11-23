using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Alumno : BaseEntity
    {
        public Alumno()
        {

        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
