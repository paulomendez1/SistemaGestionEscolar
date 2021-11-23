using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFinanzaRepository : IRepository<Finanza>
    {
        int GetTotalAlumnos();
        int GetTotalDocentes();
        decimal GetTotalSueldoDocentes();
        decimal GetTotalIngresos();
        decimal GetTotalEgresos();
        decimal GetTotal();
    }
}
