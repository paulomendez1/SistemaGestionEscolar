using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SessionCache
    {
        public static int Id { get; set; }
        public static string Email { get; set; }
        public static string Contraseña { get; set; }
        public static int Rol { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static int FailAttempts { get; set; }
    }
}
