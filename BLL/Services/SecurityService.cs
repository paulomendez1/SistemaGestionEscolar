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
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public Usuario GetLoginByCredentials(UsuarioLogin login)
        {
            return _unitOfWork.SecurityRepository.GetLoginByCredentials(login);
        }

        public Usuario RecoverPw(UsuarioLogin login)
        {
            return _unitOfWork.SecurityRepository.RecoverPw(login);
        }

        public void RegisterUser(Usuario user)
        {
            var Email = _unitOfWork.SecurityRepository.GetAll().Where(x => x.Email == user.Email).ToList();
            if (Email.Count() > 0)
            {
                throw new Exception("Ya existe un usuario con esa direccion de correo electronico!");
            }
            else
            {
                _unitOfWork.SecurityRepository.Add(user);
                _unitOfWork.WriteXML(_ds);
            }
        }

        public (Administrador, Docente, Alumno) MergeUser(int userId)
        {
            return _unitOfWork.SecurityRepository.MergeUser(userId);
        }

        public Usuario MergeUserReturnUser(int userId)
        {
            return _unitOfWork.SecurityRepository.MergeUserReturnUser(userId);
        }

        public bool UpdateUser(Usuario user)
        {
            var Email = _unitOfWork.SecurityRepository.GetAll().Where(x => x.Email == user.Email && x.Id != user.Id).ToList();
            if (Email.Count() > 0 )
            {
                throw new Exception("Ya existe un usuario con esa direccion de correo electronico!");
            }
            else
            {
                _unitOfWork.SecurityRepository.Update(user);
                _unitOfWork.WriteXML(_ds);
                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            _unitOfWork.SecurityRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
