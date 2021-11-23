using Core.Entities;
using MySocialNetwork.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEvaluacionService
    {
        PagedList<Evaluacion> GetEvaluaciones(int? PageNumber, int? PageSize);

        Evaluacion GetEvaluacion(int id);

        void InsertEvaluacion(Evaluacion evaluacion);

        bool UpdateEvaluacion(Evaluacion evaluacion);

        bool DeleteEvaluacion(int id);
        IEnumerable<Evaluacion> GetEvalacionByMateria(int idMateria);

        IEnumerable<Evaluacion> GetEvalacionByAlumno(int idAlumno);

        IEnumerable<Evaluacion> GetEvaluacionByAlumnoMateria(int idAlumno, int idMateria);
        IEnumerable<Evaluacion> GetEvaluacionByFecha(string fecha);

    }
}
