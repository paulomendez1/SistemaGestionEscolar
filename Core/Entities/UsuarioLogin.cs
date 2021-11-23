using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UsuarioLogin 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}
