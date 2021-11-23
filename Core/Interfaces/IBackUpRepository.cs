using Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBackUpRepository : IRepository<BackUp>
    {
        IEnumerable<BackUp> GetBackUpByDate(DateTime fecha);
        void RestoreBackUp(int id);
    }
}
