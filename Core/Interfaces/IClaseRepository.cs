﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IClaseRepository : IRepository<Clase>
    {
        IEnumerable<Clase> GetClaseByDate(string fecha);
    }
}
