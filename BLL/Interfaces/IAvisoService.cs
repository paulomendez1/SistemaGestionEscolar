using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAvisoService
    {
        IEnumerable<Aviso> GetAvisos(int? PageNumber, int? PageSize);

        Aviso GetAviso(int id);

        void InsertAviso(Aviso aviso);

        bool UpdateAviso(Aviso aviso);

        bool DeleteAviso(int id);
    }
}
