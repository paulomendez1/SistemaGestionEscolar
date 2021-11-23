using BLL.Interfaces;
using BLL.Services;
using Common;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class SecurityController
    {
        private readonly ISecurityService _securityService = new SecurityService();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        public void RegisterUser(IDictionary<string, string> oUser)
        {
            Usuario usuario = oUser.Select(x => new Usuario
            {
                Id = _unitOfWork.SecurityRepository.GetAll().LastOrDefault().Id + 1,
                Email = oUser[Configuration.EMAIL],
                Contraseña = oUser[Configuration.CONTRASEÑA],
                RolId = Convert.ToInt32(oUser[Configuration.ROL]),
            }).FirstOrDefault();

            _securityService.RegisterUser(usuario);
        }
        public void UpdateUser(IDictionary<string, string> oUser)
        {
            Usuario usuario = oUser.Select(x => new Usuario
            {
                Id = Convert.ToInt32(oUser[Configuration.ID]),
                Email = oUser[Configuration.EMAIL],
                Contraseña = oUser[Configuration.CONTRASEÑA],
                RolId = Convert.ToInt32(oUser[Configuration.ROL])
            }).FirstOrDefault();

            _securityService.UpdateUser(usuario);
        }
        public void DeleteUser(int id)
        {
            _securityService.DeleteUser(id);
        }

        public (bool, Usuario) IsValidUser(IDictionary<string, string> oUser)
        {
            UsuarioLogin usuarioLogin = new UsuarioLogin();
            usuarioLogin.Email = oUser[Configuration.EMAIL];
            usuarioLogin.Contraseña = oUser[Configuration.CONTRASEÑA];
            var user = _securityService.GetLoginByCredentials(usuarioLogin);
            return (user != null, user);
        }

        public (bool, Usuario) RecoverPw(IDictionary<string, string> oUser)
        {
            UsuarioLogin usuarioLogin = new UsuarioLogin();
            usuarioLogin.Email = oUser[Configuration.EMAIL];
            var user = _securityService.RecoverPw(usuarioLogin);
            EmailSender.EnviarEmailRecuperacion(user.Email, user.Contraseña);
            return (user != null, user);
        }

        public (Administrador, Docente, Alumno) MergeUser(int userId)
        {
            var user = _securityService.MergeUser(userId);
            return user;
        }

        public Usuario MergeUserReturnUser(int userId)
        {
            var user = _securityService.MergeUserReturnUser(userId);
            return user;
        }
    }
}
