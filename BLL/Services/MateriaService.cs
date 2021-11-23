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
    public class MateriaService : IMateriaService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public bool DeleteMateria(int id)
        {
            _unitOfWork.MateriaRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public Materia GetMateria(int id)
        {
            return _unitOfWork.MateriaRepository.GetById(id);
        }

        public IEnumerable<Materia> GetMaterias(int? PageNumber, int? PageSize)
        {
            var materias = _unitOfWork.MateriaRepository.GetAll();
            var pagedPosts = PagedList<Materia>.Create(materias, (int)PageNumber, (int)PageSize);
            return pagedPosts;
        }

        public void InsertMateria(Materia materia)
        {
            _unitOfWork.MateriaRepository.Add(materia);
            _unitOfWork.WriteXML(_ds);
        }

        public bool UpdateMateria(Materia materia)
        {
            _unitOfWork.MateriaRepository.Update(materia);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
