using BLL.Interfaces;
using BLL.Services;
using Common;
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
    public class AlumnoController
    {
        private readonly AlumnoService _alumnoService = new();
        private readonly AsistenciaService _asistenciaService = new();
        private readonly EvaluacionService _evaluacionService = new();
        private readonly ISecurityService _securityService = new SecurityService();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetALumnos(int? pageNumber, int? pageSize)
        {
            var alumnos = _alumnoService.GetAlumnos(pageNumber, pageSize);
            return _alumnoService.GetAlumnos(pageNumber, pageSize).Select(x => new AlumnoDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Asistencia = GetAlumnoAsistencia(x.Id),
                Promedio = GetAlumnoPromedio(x.Id)
            }).ToList();
        }

        public void AddAlumno(IDictionary<string, string> oAlumno)
        {
            Usuario user = oAlumno.Select(x => new Usuario
            {
                Id = _unitOfWork.SecurityRepository.GetAll().LastOrDefault().Id + 1,
                Email = oAlumno["Email"],
                Contraseña = Encryption.EncriptarPW(oAlumno["Contraseña"]),
                RolId = 3
            }).FirstOrDefault();
            Alumno alumno = oAlumno.Select(x => new Alumno
            {
                Id = _unitOfWork.AlumnoRepository.GetAll().LastOrDefault().Id + 1,
                Nombre = oAlumno["Nombre"],
                Apellido = oAlumno["Apellido"],              
                UsuarioId = user.Id
            }).FirstOrDefault();

            _securityService.RegisterUser(user);
            _alumnoService.InsertAlumno(alumno);

        }

        public Alumno GetAlumno(int id)
        {
            return _alumnoService.GetAlumno(id);
        }

        public void DeleteAlumno(int id)
        {
            _alumnoService.DeleteAlumno(id);
        }

        public void UpdateAlumno(IDictionary<string, string> oAlumno)
        {
            Usuario user = oAlumno.Select(x => new Usuario
            {
                Id = Convert.ToInt32(oAlumno["UsuarioId"]),
                Email = oAlumno["Email"],
                Contraseña = oAlumno["Contraseña"],
                RolId = 3
            }).FirstOrDefault();
            Alumno Alumno = oAlumno.Select(x => new Alumno
            {
                Id = Convert.ToInt32(oAlumno["Id"]),
                Nombre = oAlumno["Nombre"],
                Apellido = oAlumno["Apellido"],
                UsuarioId = Convert.ToInt32(oAlumno["UsuarioId"])
            }).FirstOrDefault();

            _alumnoService.UpdateAlumno(Alumno);
            _securityService.UpdateUser(user);
        }

        public IEnumerable GetAlumnoByName(string name)
        {
            Alumno alumno = new Alumno();
            alumno.Nombre = name;
            alumno.Apellido = name;
            return _alumnoService.GetAlumnoByName(alumno).Select(x => new AlumnoDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Asistencia = GetAlumnoAsistencia(x.Id),
                Promedio = GetAlumnoPromedio(x.Id)

            }).ToList();
        }

        public IEnumerable GetAlumnoByUserId(int userId)
        {
            return _alumnoService.GetAlumnoByUserId(userId).Select(x => new AlumnoDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Asistencia = GetAlumnoAsistencia(x.Id),
                Promedio = GetAlumnoPromedio(x.Id)
            }).ToList();
        }

        public int GetAlumnoPromedio(int userId)
        {
            int totalCalificacion = 0;
            int totalEvaluaciones = 0;
            foreach (var item in _evaluacionService.GetEvalacionByAlumno(userId))
            {
                totalCalificacion += item.Calificacion;
                totalEvaluaciones++;
            }
            if (totalEvaluaciones == 0)
            {
                return 0;
            }
            else
            {
                return totalCalificacion / totalEvaluaciones;
            }
        }
        public int GetAlumnoAsistencia(int userId)
        {
            int totalAsistencia = 0;
            int totalClases = 0;
            foreach (var item in _asistenciaService.GetAsistencias(null,null).Where(x=>x.AlumnoId==userId))
            {
                if (item.Asistio == 1)
                {
                    totalAsistencia++;
                }
                totalClases++;
            }
            if (totalClases == 0)
            {
                return 0;
            }
            else
            {
                decimal total = (decimal)totalAsistencia / totalClases;
                return (int)(total * 100);
            }
            
        }
    }
}
