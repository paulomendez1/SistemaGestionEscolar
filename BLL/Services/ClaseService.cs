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
    public class ClaseService : IClaseService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;

        public bool DeleteClase(int id)
        {
            _unitOfWork.ClaseRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Clase GetClase(int id)
        {
            return _unitOfWork.ClaseRepository.GetById(id);
        }

        public IEnumerable<Clase> GetClaseByDate(string fecha)
        {
            return _unitOfWork.ClaseRepository.GetClaseByDate(fecha);
        }

        public PagedList<Clase> GetClases(int? PageNumber, int? PageSize)
        {
            var clases = _unitOfWork.ClaseRepository.GetAll();
            var pagedPosts = PagedList<Clase>.Create(clases, (int)PageNumber, (int)PageSize);
            return pagedPosts;
        }

        public void InsertClase(Clase clase)
        {
            _unitOfWork.ClaseRepository.Add(clase);
            _unitOfWork.WriteXML(_ds);
        }

        public bool UpdateClase(Clase clase)
        {
            _unitOfWork.ClaseRepository.Update(clase);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
