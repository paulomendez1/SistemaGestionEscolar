using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class EvaluacionAlumnoDTO
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public int Calificacion { get; set; }
        public string Materia { get; set; }
    }
}
