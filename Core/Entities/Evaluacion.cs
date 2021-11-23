using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Evaluacion : BaseEntity
    {
        public string Fecha { get; set; }
        public int Calificacion { get; set; }
        public int AlumnoId { get; set; }
        public int MateriaId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
