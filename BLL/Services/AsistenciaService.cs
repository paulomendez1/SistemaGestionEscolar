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
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public bool DeleteAsistencia(int id)
        {
            _unitOfWork.AsistenciaRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Asistencia GetAsistencia(int id)
        {
            return _unitOfWork.AsistenciaRepository.GetById(id);
        }

        public IEnumerable<Asistencia> GetAsistencias(int? PageNumber, int? PageSize)
        {
            if (PageNumber != null || PageSize != null)
            {
                var asistencias = _unitOfWork.AsistenciaRepository.GetAll();
                var pagedPosts = PagedList<Asistencia>.Create(asistencias, (int)PageNumber, (int)PageSize);
                return pagedPosts;
            }
            else
            {
                var asistencias = _unitOfWork.AsistenciaRepository.GetAll();
                return asistencias;
            }
        }

        public void InsertAsistencia(Asistencia asistencia)
        {
            _unitOfWork.AsistenciaRepository.Add(asistencia);
            _unitOfWork.WriteXML(_ds);
        }

        public bool UpdateAsistencia(Asistencia asistencia)
        {
            _unitOfWork.AsistenciaRepository.Update(asistencia);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
