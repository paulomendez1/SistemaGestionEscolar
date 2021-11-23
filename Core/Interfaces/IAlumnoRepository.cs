using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAlumnoRepository : IRepository<Alumno>
    {
        IEnumerable<Alumno> GetAlumnoByName(Alumno alumno);

        IEnumerable<Alumno> GetAlumnoByUserId(int userId);

    }
}
