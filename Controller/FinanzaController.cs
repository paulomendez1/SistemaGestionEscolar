using BLL.Services;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FinanzaController
    {
        private readonly FinanzaService _finanzaService = new();

        public Finanza GetFinanza(int id)
        {
            return _finanzaService.GetFinanza(id);
        }

        public decimal GetTotal()
        {
            return _finanzaService.GetTotal();
        }

        public int GetTotalAlumnos()
        {
            return _finanzaService.GetTotalAlumnos();
        }

        public int GetTotalDocentes()
        {
            return _finanzaService.GetTotalDocentes();
        }

        public decimal GetTotalEgresos()
        {
            return _finanzaService.GetTotalEgresos();
        }

        public decimal GetTotalIngresos()
        {
            return _finanzaService.GetTotalIngresos();
        }

        public decimal GetTotalSueldoDocentes()
        {
            return _finanzaService.GetTotalSueldoDocentes();
        }

        public void UpdateFinanza(IDictionary<string, string> oFinanza)
        {
            Finanza finanza = oFinanza.Select(x => new Finanza
            {
                Id = 1,
                ValorCuota = Convert.ToInt32(oFinanza["ValorCuota"]),
                ValorServicio = Convert.ToInt32(oFinanza["ValorServicio"])
            }).FirstOrDefault(); ;

            _finanzaService.UpdateFinanza(finanza);
        }
    }
}
