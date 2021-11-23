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
    public class AsistenciaController
    {
        private readonly AsistenciaService _asistenciaService = new();
        private readonly ClaseService _claseService = new();
        private readonly AlumnoService _alumnoService = new();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetAsistencias(int? pageNumber, int? pageSize)
        {
            return _asistenciaService.GetAsistencias(pageNumber, pageSize).Select(x => new AsistenciaDTO
            {
                Id = x.Id,
                Alumno = $"{_alumnoService.GetAlumno(x.AlumnoId).Nombre} {_alumnoService.GetAlumno(x.AlumnoId).Apellido}",
                Fecha = $"{_claseService.GetClase(x.ClaseId).Fecha}", 
                Asistio = x.Asistio.ToString()
            }).ToList();
        }

        public void AddAsistencia(IDictionary<string, string> oAsistencia)
        {
            Asistencia asistencia = oAsistencia.Select(x => new Asistencia
            {
                Id = _unitOfWork.AsistenciaRepository.GetAll().LastOrDefault().Id + 1,
                AlumnoId = Convert.ToInt32(oAsistencia["AlumnoId"]),
                ClaseId = Convert.ToInt32(oAsistencia["ClaseId"]),
                Asistio = Convert.ToInt32(oAsistencia["Asistio"]),
            }).FirstOrDefault();

            _asistenciaService.InsertAsistencia(asistencia);
        }

        public Asistencia GetAsistencia(int id)
        {
            return _asistenciaService.GetAsistencia(id);
        }

        public void DeleteAsistencia(int id)
        {
            _asistenciaService.DeleteAsistencia(id);
        }

        public void UpdateAsistencia(IDictionary<string, string> oAsistencia)
        {
            Asistencia asistencia = oAsistencia.Select(x => new Asistencia
            {
                Id = Convert.ToInt32(oAsistencia["Id"]),
                AlumnoId = Convert.ToInt32(oAsistencia["AlumnoId"]),
                ClaseId = Convert.ToInt32(oAsistencia["ClaseId"]),
                Asistio = Convert.ToInt32(oAsistencia["Asistio"]),
            }).FirstOrDefault();

            _asistenciaService.UpdateAsistencia(asistencia);
        }

        public IEnumerable GetAsistenciaByAlumno(int userId)
        {
            return _asistenciaService.GetAsistencias(null, null).Where(x=>x.AlumnoId==userId).Select(x => new AsistenciaDTO
            {
                Id = x.Id,
                Alumno = $"{_alumnoService.GetAlumno(x.AlumnoId).Nombre} {_alumnoService.GetAlumno(x.AlumnoId).Apellido}",
                Fecha = $"{_claseService.GetClase(x.ClaseId).Fecha}",
                Asistio = x.Asistio.ToString()
            }).ToList();
        }

        public IEnumerable GetAsistenciaByClase(int claseId)
        {
            return _asistenciaService.GetAsistencias(null, null).Where(x => x.ClaseId == claseId).Select(x => new AsistenciaDTO
            {
                Id = x.Id,
                Alumno = $"{_alumnoService.GetAlumno(x.AlumnoId).Nombre} {_alumnoService.GetAlumno(x.AlumnoId).Apellido}",
                Fecha = $"{_claseService.GetClase(x.ClaseId).Fecha}",
                Asistio = x.Asistio.ToString()
            }).ToList();
        }

    }
}
