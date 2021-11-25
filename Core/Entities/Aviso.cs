using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Aviso : BaseEntity
    {
        public string Leyenda { get; set; }
        public string Fecha { get; set; }
        public int SuscriptoresId { get; set; }
    }
}
