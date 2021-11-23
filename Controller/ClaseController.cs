using BLL.Services;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ClaseController
    {
        private readonly ClaseService _claseService = new();
        private readonly AsistenciaService _asistenciaService = new();
        private readonly DocenteService _docenteService = new();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetClases(int? pageNumber, int? pageSize)
        {
            return _claseService.GetClases(pageNumber, pageSize).Select(x => new ClaseDTO
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Docente = $"{_docenteService.GetDocente(x.DocenteId).Nombre} {_docenteService.GetDocente(x.DocenteId).Apellido}"
            }).ToList();
        }

        public void AddClase(IDictionary<string, string> oClase)
        {
            Clase clase = oClase.Select(x => new Clase
            {
                Id = _unitOfWork.ClaseRepository.GetAll().LastOrDefault().Id + 1,
                Fecha = oClase["Fecha"],
                DocenteId = Convert.ToInt32(oClase["DocenteId"])
            }).FirstOrDefault();

            _claseService.InsertClase(clase);
        }

        public Clase GetClase(int id)
        {
            return _claseService.GetClase(id);
        }

        public void DeleteClase(int id)
        {
            foreach (var item in _asistenciaService.GetAsistencias(null, null).Where(x => x.ClaseId == id))
            {
                _asistenciaService.DeleteAsistencia(item.Id);
            }
            _claseService.DeleteClase(id);
        }

        public void UpdateClase(IDictionary<string, string> oClase)
        {
            Clase clase = oClase.Select(x => new Clase
            {
                Id = Convert.ToInt32(oClase["Id"]),
                Fecha = oClase["Fecha"],
                DocenteId = Convert.ToInt32(oClase["DocenteId"])
            }).FirstOrDefault(); ;

            _claseService.UpdateClase(clase);
        }

        public IEnumerable GetClaseByDate(string fecha)
        {
            return _claseService.GetClaseByDate(fecha).Select(x => new ClaseDTO
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Docente = $"{_docenteService.GetDocente(x.DocenteId).Nombre} {_docenteService.GetDocente(x.DocenteId).Apellido}"
            }).ToList();
        }

        public int GetIdLastClase()
        {
            return _unitOfWork.ClaseRepository.GetAll().LastOrDefault().Id;
        }

    }
}

