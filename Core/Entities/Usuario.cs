using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
