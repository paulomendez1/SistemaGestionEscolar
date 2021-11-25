using BLL.Interfaces;
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
    public class AvisoService : IAvisoService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;

        public bool DeleteAviso(int id)
        {
            _unitOfWork.AvisoRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Aviso GetAviso(int id)
        {
            return _unitOfWork.AvisoRepository.GetById(id);
        }

        public IEnumerable<Aviso> GetAvisos(int? PageNumber, int? PageSize)
        {
            if (PageNumber != null || PageSize != null)
            {
                var avisos = _unitOfWork.AvisoRepository.GetAll();
                var pagedPosts = PagedList<Aviso>.Create(avisos, (int)PageNumber, (int)PageSize);
                return pagedPosts;
            }
            else
            {
                var avisos = _unitOfWork.AvisoRepository.GetAll();
                return avisos;
            }
        }

        public void InsertAviso(Aviso aviso)
        {
            _unitOfWork.AvisoRepository.Add(aviso);
            _unitOfWork.WriteXML(_ds);
        }

        public bool UpdateAviso(Aviso aviso)
        {
            _unitOfWork.AvisoRepository.Update(aviso);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
