using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class EvaluacionRepository : BaseRepository<Evaluacion>, IEvaluacionRepository
    {
        public IEnumerable<Evaluacion> GetEvalacionByAlumno(int idAlumno)
        {
            IEnumerable<Evaluacion> getByAlumno = GetAll().Where(x => x.AlumnoId == idAlumno).ToList();
            return getByAlumno;
        }

        public IEnumerable<Evaluacion> GetEvalacionByMateria(int idMateria)
        {
            IEnumerable<Evaluacion> getByMateria = GetAll().Where(x => x.MateriaId == idMateria).ToList();
            return getByMateria;
        }

        public IEnumerable<Evaluacion> GetEvaluacionByAlumnoMateria (int idAlumno, int idMateria)
        {
            IEnumerable<Evaluacion> getByAlumnoMateria = GetAll().Where(x => x.AlumnoId == idAlumno && x.MateriaId==idMateria).ToList();
            return getByAlumnoMateria;
        }

        public IEnumerable<Evaluacion> GetEvaluacionByFecha(string fecha)
        {
            IEnumerable<Evaluacion> getByFecha = GetAll().Where(x => x.Fecha == fecha).ToList();
            return getByFecha;
        }
    }
}
