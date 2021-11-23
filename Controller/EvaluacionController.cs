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
    public class EvaluacionController
    {
        private readonly EvaluacionService _evaluacionService = new();
        private readonly MateriaService _materiaService = new();
        private readonly AlumnoService _alumnoService = new();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public void DeleteEvaluacion(int id)
        {
            _evaluacionService.DeleteEvaluacion(id);
        }

        public IEnumerable GetEvalacionByAlumno(int idAlumno)
        {
            var evaluaciones = _evaluacionService.GetEvalacionByAlumno(idAlumno);
            var list = _evaluacionService.GetEvalacionByAlumno(idAlumno).Select(x => new EvaluacionAlumnoDTO
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Calificacion = x.Calificacion,
                Materia = _materiaService.GetMateria(x.MateriaId).Nombre
            }).ToList();

            return list;
        }

        public IEnumerable GetEvaluacionByAlumnoMateria(int idAlumno, int idMateria)
        {
            var list = _evaluacionService.GetEvaluacionByAlumnoMateria(idAlumno, idMateria).Select(x => new EvaluacionAlumnoDTO
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Calificacion = x.Calificacion,
                Materia = _materiaService.GetMateria(x.MateriaId).Nombre
            }).ToList();

            return list;
        }

        public IEnumerable GetEvalacionByMateria(int idMateria)
        {
            var list = _evaluacionService.GetEvalacionByMateria(idMateria).Select(x => new EvaluacionMateriaDTO
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Calificacion = x.Calificacion,
                Alumno = $"{_alumnoService.GetAlumno(x.AlumnoId).Nombre} {_alumnoService.GetAlumno(x.AlumnoId).Apellido}"
            }).ToList();

            return list;
        }

        public IEnumerable GetEvaluacionByFecha(string fecha)
        {
            var list = _evaluacionService.GetEvaluacionByFecha(fecha).Select(x => new EvaluacionMateriaDTO
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Calificacion = x.Calificacion,
                Alumno = $"{_alumnoService.GetAlumno(x.AlumnoId).Nombre} {_alumnoService.GetAlumno(x.AlumnoId).Apellido}"
            }).ToList();

            return list;
        }

        public Evaluacion GetEvaluacion(int id)
        {
            return _evaluacionService.GetEvaluacion(id);
        }

        public IEnumerable GetEvaluaciones(int? PageNumber, int? PageSize)
        {
            var evaluaciones = _evaluacionService.GetEvaluaciones(PageNumber, PageSize);
            var list = _evaluacionService.GetEvaluaciones(PageNumber, PageSize).Select(x => new Evaluacion
            {
                Id = x.Id,
                Fecha = x.Fecha,
                Calificacion = x.Calificacion
            }).ToList();

            return list;
        }

        public void InsertEvaluacion(IDictionary<string, string> oEvaluacion)
        {
            Evaluacion evaluacion = oEvaluacion.Select(x => new Evaluacion
            {
                Id = _unitOfWork.EvaluacionRepository.GetAll().LastOrDefault().Id + 1,
                Fecha = oEvaluacion["Fecha"],
                Calificacion = Convert.ToInt32(oEvaluacion["Calificacion"]),
                AlumnoId = Convert.ToInt32(oEvaluacion["AlumnoId"]),
                MateriaId = Convert.ToInt32(oEvaluacion["MateriaId"])
            }).FirstOrDefault();

            _evaluacionService.InsertEvaluacion(evaluacion);
        }

        public void UpdateEvaluacion(IDictionary<string, string> oEvaluacion)
        {
            Evaluacion evaluacion = oEvaluacion.Select(x => new Evaluacion
            {
                Id = Convert.ToInt32(oEvaluacion["Id"]),
                Fecha = oEvaluacion["Fecha"],
                Calificacion = Convert.ToInt32(oEvaluacion["Calificacion"]),
                AlumnoId = Convert.ToInt32(oEvaluacion["AlumnoId"]),
                MateriaId = Convert.ToInt32(oEvaluacion["MateriaId"])
            }).FirstOrDefault(); ;

            _evaluacionService.UpdateEvaluacion(evaluacion);
        }
    }
}
