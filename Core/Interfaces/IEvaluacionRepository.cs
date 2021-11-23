using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEvaluacionRepository : IRepository<Evaluacion>
    {
        IEnumerable<Evaluacion> GetEvalacionByMateria(int idMateria);

        IEnumerable<Evaluacion> GetEvalacionByAlumno(int idAlumno);

        IEnumerable<Evaluacion> GetEvaluacionByAlumnoMateria(int idAlumno, int idMateria);

        IEnumerable<Evaluacion> GetEvaluacionByFecha(string fecha);
    }
}
