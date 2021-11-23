using Core.Entities;
using MySocialNetwork.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClaseService
    {
        PagedList<Clase> GetClases(int? PageNumber, int? PageSize);

        Clase GetClase(int id);

        void InsertClase(Clase clase);

        bool UpdateClase(Clase clase);

        bool DeleteClase(int id);

        IEnumerable<Clase> GetClaseByDate(string fecha);

    }
}
