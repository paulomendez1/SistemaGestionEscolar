using BLL.Interfaces;
using Common;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Subject 
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly AvisoService _avisoService = new();
        List<Alumno> observers;
        public void Notify(decimal ValorCuota)
        {
            observers = _unitOfWork.AlumnoRepository.GetAll().ToList();
            Aviso oAviso = new Aviso
            {
                Leyenda = $"Le informamos que el valor de la cuota ha cambiado!, Ahora es {ValorCuota.ToString()}",
                  Fecha= DateTime.Now.ToString("dd-MM-yyyy"),
                  SuscriptoresId = 3
            };
            _avisoService.InsertAviso(oAviso);
        }
    }
}
