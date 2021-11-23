using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Finanza : BaseEntity
    {
        public decimal ValorCuota { get; set; }
        public decimal ValorServicio { get; set; }
    }
}
