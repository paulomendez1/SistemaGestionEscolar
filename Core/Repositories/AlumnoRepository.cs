using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class AlumnoRepository : BaseRepository<Alumno>, IAlumnoRepository
    {

        public IEnumerable<Alumno> GetAlumnoByName(Alumno alumno)
        {
            IEnumerable<Alumno> getByName = GetAll().Where(x => x.Nombre.ToLower().Contains(alumno.Nombre.ToLower()) || x.Apellido.ToLower().Contains(alumno.Apellido.ToLower())).ToList();
            return getByName;
        }

        public IEnumerable<Alumno> GetAlumnoByUserId(int userId)
        {
            IEnumerable<Alumno> getByName = GetAll().Where(x=> x.UsuarioId == userId).ToList();
            return getByName;
        }

    }
}
