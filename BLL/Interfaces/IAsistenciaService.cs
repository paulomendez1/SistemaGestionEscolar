using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAsistenciaService
    {
        IEnumerable<Asistencia> GetAsistencias(int? PageNumber, int? PageSize);

        Asistencia GetAsistencia(int id);

        void InsertAsistencia(Asistencia asistencia);

        bool UpdateAsistencia(Asistencia asistencia);

        bool DeleteAsistencia(int id);
    }
}
