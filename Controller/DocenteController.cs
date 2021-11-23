using BLL.Interfaces;
using BLL.Services;
using Common;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DocenteController
    {
        private readonly DocenteService _docenteService = new();
        private readonly MateriaService _materiaService = new();
        private readonly ISecurityService _securityService = new SecurityService();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetDocentes(int? pageNumber, int? pageSize)
        {
            var docentes = _docenteService.GetDocentes(pageNumber, pageSize);
            var list=  _docenteService.GetDocentes(pageNumber, pageSize).Select(x => new DocenteDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sueldo = x.Sueldo,
                MateriasAsignadas = _unitOfWork.MateriaRepository.GetAll().Where(X=> x.Id == X.DocenteId).Count()
                
            }).ToList();


            return list;
        }
        
        public void AddDocente(IDictionary<string, string> oDocente)
        {
            Usuario user = oDocente.Select(x => new Usuario
            {
                Id = _unitOfWork.SecurityRepository.GetAll().LastOrDefault().Id + 1,
                Email = oDocente["Email"],
                Contraseña = oDocente["Contraseña"],
                RolId = 2
            }).FirstOrDefault();
            Docente docente = oDocente.Select(x=> new Docente
            {
                Id = _unitOfWork.DocenteRepository.GetAll().LastOrDefault().Id + 1,
                Nombre = oDocente[Configuration.NOMBRE],
                Apellido = oDocente[Configuration.APELLIDO],
                Sueldo = Convert.ToInt32(oDocente[Configuration.SUELDO]),
                UsuarioId = user.Id
            }).FirstOrDefault();

            _securityService.RegisterUser(user);
            _docenteService.InsertDocente(docente);
        }

        public Docente GetDocente (int id)
        {
           return _docenteService.GetDocente(id);
        }

        public void DeleteDocente (int id)
        {
            _docenteService.DeleteDocente(id);
        }

        public void UpdateDocente (IDictionary<string, string> oDocente)
        {
            Usuario user = oDocente.Select(x => new Usuario
            {
                Id = Convert.ToInt32(oDocente["UsuarioId"]),
                Email = oDocente["Email"],
                Contraseña = oDocente["Contraseña"],
                RolId = 2
            }).FirstOrDefault();
            Docente Docente = oDocente.Select(x => new Docente
            {
                Id = Convert.ToInt32(oDocente[Configuration.ID]),
                Nombre = oDocente[Configuration.NOMBRE],
                Apellido = oDocente[Configuration.APELLIDO],
                Sueldo = Convert.ToInt32(oDocente[Configuration.SUELDO])
            }).FirstOrDefault();

            _docenteService.UpdateDocente(Docente);
            _securityService.UpdateUser(user);
        }

        public IEnumerable GetDocenteByName(string name)
        {
            Docente docente = new Docente();
            docente.Nombre = name;
            docente.Apellido = name;
            return _docenteService.GetDocenteByName(docente).Select(x => new DocenteDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sueldo = x.Sueldo
                //MateriasAsignadas = x.Materias.Count

            }).ToList();
        }

        public IEnumerable GetDocentesCMB()
        {
            var docentes = _docenteService.GetDocenteCMB();
            return _docenteService.GetDocenteCMB().Select(x => new DocenteDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sueldo = x.Sueldo,

            }).ToList();
        }

        public IEnumerable GetDocenteByUserId(int userId)
        {
            return _docenteService.GetDocenteByUserId(userId).Select(x => new DocenteDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sueldo = x.Sueldo
            }).ToList();
        }
    }
}
