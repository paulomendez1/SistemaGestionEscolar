using Core.Interfaces;
using Core.Repositories;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using BLL.Interfaces;
using MySocialNetwork.Core.CustomEntities;
using Common;

namespace BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;

        public bool DeleteAdmin(int id)
        {
            _unitOfWork.AdminRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Administrador GetAdmin(int id)
        {
            return _unitOfWork.AdminRepository.GetById(id);
        }


        public IEnumerable<Administrador> GetAdmins(int? PageNumber, int? PageSize)
        {
            var admins = _unitOfWork.AdminRepository.GetAll();
            var pagedPosts = PagedList<Administrador>.Create(admins, (int)PageNumber, (int)PageSize);
            return pagedPosts;
        }

        public void InsertAdmin(Administrador admin)
        {
            var adminMerge = _unitOfWork.SecurityRepository.GetAll().Where(x => x.Id == admin.UsuarioId).FirstOrDefault();

            _unitOfWork.AdminRepository.Add(admin);
            _unitOfWork.WriteXML(_ds);
            EmailSender.EnviarEmailRegistro(adminMerge.Email, Encryption.DesencriptarPW(adminMerge.Contraseña));
        }

        public bool UpdateAdmin(Administrador admin)
        {
            _unitOfWork.AdminRepository.Update(admin);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
