using Core.Entities;
using MySocialNetwork.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDocenteService
    {
        PagedList<Docente> GetDocentes(int? PageNumber, int? PageSize);

        Docente GetDocente(int id);

        void InsertDocente(Docente docente);

        bool UpdateDocente(Docente docente);

        bool DeleteDocente(int id);

        IEnumerable<Docente> GetDocenteByName(Docente docente);

        IEnumerable<Docente> GetDocenteCMB();
        IEnumerable<Docente> GetDocenteByUserId(int userId);
    }

}
