using BLL.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FinanzaService : IFinanzaService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly Subject _subject = new();
        private readonly DataSet _ds = DataAccess.Instancia.ds;

        public Finanza GetFinanza(int id)
        {
            return _unitOfWork.FinanzaRepository.GetById(id);
        }

        public decimal GetTotal()
        {
            return _unitOfWork.FinanzaRepository.GetTotal();
        }

        public int GetTotalAlumnos()
        {
            return _unitOfWork.FinanzaRepository.GetTotalAlumnos();
        }

        public int GetTotalDocentes()
        {
            return _unitOfWork.FinanzaRepository.GetTotalDocentes();
        }

        public decimal GetTotalEgresos()
        {
            return _unitOfWork.FinanzaRepository.GetTotalEgresos();
        }

        public decimal GetTotalIngresos()
        {
            return _unitOfWork.FinanzaRepository.GetTotalIngresos();
        }

        public decimal GetTotalSueldoDocentes()
        {
            return _unitOfWork.FinanzaRepository.GetTotalSueldoDocentes();
        }

        public bool UpdateFinanza(Finanza finanza)
        {
            _unitOfWork.FinanzaRepository.Update(finanza);
            _unitOfWork.WriteXML(_ds);
            _subject.Notify(finanza.ValorCuota);
            return true;
        }
    }
}
