using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class DocenteRepository : BaseRepository<Docente>, IDocenteRepository
    {

        public IEnumerable<Docente> GetDocenteByName(Docente docente)
        {
            IEnumerable<Docente> getByName = GetAll().Where(x => x.Nombre.ToLower().Contains(docente.Nombre.ToLower()) || x.Apellido.ToLower().Contains(docente.Apellido.ToLower())).ToList();
            return getByName;
        }

        public IEnumerable<Docente> GetDocenteCMB()
        {
            IEnumerable<Docente> getByName = GetAll().ToList();
            return getByName;
        }

        public IEnumerable<Docente> GetDocenteByUserId(int userId)
        {
            IEnumerable<Docente> getByUserId = GetAll().Where(x => x.UsuarioId == userId).ToList();
            return getByUserId;
        }

    }
}
