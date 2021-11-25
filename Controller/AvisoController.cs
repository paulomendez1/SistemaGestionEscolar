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
    public class AvisoController
    {
        private readonly AvisoService _avisoService = new();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetAvisos(int? pageNumber, int? pageSize)
        {
            return _avisoService.GetAvisos(pageNumber, pageSize).Select(x => new AvisoDTO
            {
                Id = x.Id,
                Leyenda = x.Leyenda,
                Fecha = x.Fecha,
                Notificados = x.SuscriptoresId == 3 ? "Alumnos" : "Docentes"
            }).ToList();
        }
        public IEnumerable GetAvisosAlumnos(int? pageNumber, int? pageSize)
        {
            return _avisoService.GetAvisos(pageNumber, pageSize).Select(x => new AvisoDTO
            {
                Id = x.Id,
                Leyenda = x.Leyenda,
                Fecha = x.Fecha,
                Notificados = x.SuscriptoresId == 3 ? "Alumnos" : "Docentes"
            }).Where(x => x.Notificados == "Alumnos").ToList();
        }
        public IEnumerable GetAvisosDocentes(int? pageNumber, int? pageSize)
        {
            return _avisoService.GetAvisos(pageNumber, pageSize).Select(x => new AvisoDTO
            {
                Id = x.Id,
                Leyenda = x.Leyenda,
                Fecha = x.Fecha,
                Notificados = x.SuscriptoresId == 3 ? "Alumnos" : "Docentes"
            }).Where(x=>x.Notificados=="Docentes").ToList();
        }

        public void AddAviso(IDictionary<string, string> oAviso)
        {
            Aviso aviso = oAviso.Select(x => new Aviso
            {
                Id = _unitOfWork.AvisoRepository.GetAll().LastOrDefault().Id + 1,
                Leyenda = oAviso["Leyenda"],
                Fecha = oAviso["Fecha"],
                SuscriptoresId = Convert.ToInt32(oAviso["SuscriptoresId"])
            }).FirstOrDefault();

            _avisoService.InsertAviso(aviso);
        }

        public Aviso GetAviso(int id)
        {
            return _avisoService.GetAviso(id);
        }

        public void DeleteAviso(int id)
        {
            _avisoService.DeleteAviso(id);
        }

        public void UpdateAviso(IDictionary<string, string> oAviso)
        {
            Aviso aviso = oAviso.Select(x => new Aviso
            {
                Id = Convert.ToInt32(oAviso["Id"]),
                Leyenda = oAviso["Leyenda"],
                Fecha = oAviso["Fecha"],
                SuscriptoresId = Convert.ToInt32(oAviso["SuscriptoresId"])
            }).FirstOrDefault(); ;

            _avisoService.UpdateAviso(aviso);
        }


    }
}
