using BLL.Interfaces;
using Common;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using Data;
using MySocialNetwork.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public bool DeleteAlumno(int id)
        {
            _unitOfWork.AlumnoRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Alumno GetAlumno (int id)
        {
            return _unitOfWork.AlumnoRepository.GetById(id);
        }

        public IEnumerable<Alumno> GetAlumnoByName(Alumno alumno)
        {
            return _unitOfWork.AlumnoRepository.GetAlumnoByName(alumno);
        }

        public IEnumerable<Alumno> GetAlumnoByUserId(int userId)
        {
            return _unitOfWork.AlumnoRepository.GetAlumnoByUserId(userId);
        }

        public IEnumerable<Alumno> GetAlumnos(int? PageNumber, int? PageSize)
        {
            if (PageNumber != null & PageSize != null)
            {
                var alumnos = _unitOfWork.AlumnoRepository.GetAll();
                var pagedPosts = PagedList<Alumno>.Create(alumnos, (int)PageNumber, (int)PageSize);
                return pagedPosts;
            }
            else
            {
                var alumnos = _unitOfWork.AlumnoRepository.GetAll();
                return alumnos;
            }
        }

        public void InsertAlumno(Alumno alumno)
        {
            var alumnoMerge = _unitOfWork.SecurityRepository.GetAll().Where(x => x.Id == alumno.UsuarioId).FirstOrDefault();

                _unitOfWork.AlumnoRepository.Add(alumno);
                _unitOfWork.WriteXML(_ds);
                EmailSender.EnviarEmailRegistro(alumnoMerge.Email, Encryption.DesencriptarPW(alumnoMerge.Contraseña));
        }

        public bool UpdateAlumno(Alumno alumno)
        {
            _unitOfWork.AlumnoRepository.Update(alumno);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
