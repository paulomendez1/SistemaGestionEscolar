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
    public class DocenteService : IDocenteService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public bool DeleteDocente(int id)
        {
            _unitOfWork.DocenteRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Docente GetDocente(int id)
        {
            return _unitOfWork.DocenteRepository.GetById(id);
        }

        public PagedList<Docente> GetDocentes(int? PageNumber, int? PageSize)
        {
           var docentes = _unitOfWork.DocenteRepository.GetAll();
           var pagedPosts = PagedList<Docente>.Create(docentes, (int)PageNumber, (int)PageSize);
           return pagedPosts;
        }

        public void InsertDocente(Docente docente)
        {
            var docenteMerge = _unitOfWork.SecurityRepository.GetAll().Where(x => x.Id == docente.UsuarioId).FirstOrDefault();
            _unitOfWork.DocenteRepository.Add(docente);
            _unitOfWork.WriteXML(_ds);
            EmailSender.EnviarEmailRegistro(docenteMerge.Email, Encryption.DesencriptarPW(docenteMerge.Contraseña));
        }

        public bool UpdateDocente(Docente docente)
        {
            _unitOfWork.DocenteRepository.Update(docente);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public IEnumerable<Docente> GetDocenteByName(Docente docente)
        {
            return _unitOfWork.DocenteRepository.GetDocenteByName(docente);
        }

        public IEnumerable<Docente> GetDocenteCMB()
        {
            return _unitOfWork.DocenteRepository.GetDocenteCMB();
        }

        public IEnumerable<Docente> GetDocenteByUserId(int userId)
        {
            return _unitOfWork.DocenteRepository.GetDocenteByUserId(userId);
        }

    }
}
