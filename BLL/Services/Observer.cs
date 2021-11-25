using BLL.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Observer : IObserver
    {
        private readonly FinanzaService _finanzaService = new();
        public void Update(Finanza finanza)
        {
            _finanzaService.UpdateFinanza(finanza);
        }
    }
}
