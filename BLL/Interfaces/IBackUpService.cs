using Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBackUpService
    {
        IEnumerable<BackUp> GetBackUps();
        void CrearBackUp(BackUp backup);
        void RestoreBackUp(int id);
        void EliminarBackUp(int id);

        IEnumerable<BackUp> GetBackUpByDate(DateTime fecha);

    }
}
