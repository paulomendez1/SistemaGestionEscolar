using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFinanzaService
    {
        int GetTotalAlumnos();
        int GetTotalDocentes();
        decimal GetTotalSueldoDocentes();
        decimal GetTotalIngresos();
        decimal GetTotalEgresos();
        decimal GetTotal();

        bool UpdateFinanza(Finanza finanza);
        Finanza GetFinanza(int id);
    }
}
