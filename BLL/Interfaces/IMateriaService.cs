using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMateriaService
    {
        IEnumerable<Materia> GetMaterias(int? PageNumber, int? PageSize);

        Materia GetMateria(int id);

        void InsertMateria(Materia materia);

        bool UpdateMateria(Materia materia);

        bool DeleteMateria(int id);
    }
}
