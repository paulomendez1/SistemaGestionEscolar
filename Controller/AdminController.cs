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
    public class AdminController
    {
        private readonly AdminService _adminService = new();
        private readonly ISecurityService _securityService = new SecurityService();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetAdmins(int? pageNumber, int? pageSize)
        {
            var admins = _adminService.GetAdmins(pageNumber, pageSize);
            return _adminService.GetAdmins(pageNumber, pageSize).Select(x => new AdminDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Cargo = x.Cargo
            }).ToList();
        }

        public void AddAdmin(IDictionary<string, string> oAdmin)
        {
            Usuario user = oAdmin.Select(x => new Usuario
            {
                Id = _unitOfWork.SecurityRepository.GetAll().LastOrDefault().Id + 1,
                Email = oAdmin["Email"],
                Contraseña = Encryption.EncriptarPW(oAdmin["Contraseña"]),
                RolId = 1
            }).FirstOrDefault();
            Administrador admin = oAdmin.Select(x => new Administrador
            {
                Id = _unitOfWork.AdminRepository.GetAll().LastOrDefault().Id + 1,
                Nombre = oAdmin["Nombre"],
                Apellido = oAdmin["Apellido"],
                Cargo = oAdmin["Cargo"],
                UsuarioId = user.Id
            }).FirstOrDefault();

            _adminService.InsertAdmin(admin);
            _securityService.RegisterUser(user);

        }

        public Administrador GetAdmin(int id)
        {
            return _adminService.GetAdmin(id);
        }

        public void DeleteAdmin(int id)
        {
            _adminService.DeleteAdmin(id);
        }

        public void UpdateAdmin(IDictionary<string, string> oAdmin)
        {
            Usuario user = oAdmin.Select(x => new Usuario
            {
                Id = Convert.ToInt32(oAdmin["UsuarioId"]),
                Email = oAdmin["Email"],
                Contraseña = oAdmin["Contraseña"],
                RolId = 1
            }).FirstOrDefault();
            Administrador admin = oAdmin.Select(x => new Administrador
            {
                Id = Convert.ToInt32(oAdmin["Id"]),
                Nombre = oAdmin["Nombre"],
                Apellido = oAdmin["Apellido"],
                Cargo = oAdmin["Cargo"],
                UsuarioId = Convert.ToInt32(oAdmin["UsuarioId"])
            }).FirstOrDefault();

            _adminService.UpdateAdmin(admin);
            _securityService.UpdateUser(user);
        }


    }
}

