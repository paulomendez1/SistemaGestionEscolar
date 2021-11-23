using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class ClaseRepository : BaseRepository<Clase>, IClaseRepository
    {
        public IEnumerable<Clase> GetClaseByDate(string fecha)
        {
            IEnumerable<Clase> getByDate = GetAll().Where(x => x.Fecha == fecha).ToList();
            return getByDate;
        }
    }
}
