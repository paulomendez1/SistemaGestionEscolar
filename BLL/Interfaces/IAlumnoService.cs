using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAlumnoService
    {
        IEnumerable<Alumno> GetAlumnos(int? PageNumber, int? PageSize);

        Alumno GetAlumno(int id);

        void InsertAlumno(Alumno alumno);

        bool UpdateAlumno(Alumno alumno);

        bool DeleteAlumno(int id);

        IEnumerable<Alumno> GetAlumnoByName(Alumno alumno);

        IEnumerable<Alumno> GetAlumnoByUserId(int userId);
    }
}
