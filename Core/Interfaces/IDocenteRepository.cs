using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDocenteRepository : IRepository<Docente>
    {
        IEnumerable<Docente> GetDocenteByName(Docente docente);

        IEnumerable<Docente> GetDocenteCMB();

        IEnumerable<Docente> GetDocenteByUserId(int userId);

    }
}
