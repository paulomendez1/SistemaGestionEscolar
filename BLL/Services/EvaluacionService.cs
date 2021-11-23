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
    public class EvaluacionService : IEvaluacionService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public bool DeleteEvaluacion(int id)
        {
            _unitOfWork.EvaluacionRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
            return true;
        }

        public IEnumerable<Evaluacion> GetEvalacionByAlumno(int idAlumno)
        {
            return _unitOfWork.EvaluacionRepository.GetEvalacionByAlumno(idAlumno);
        }

        public IEnumerable<Evaluacion> GetEvalacionByMateria(int idMateria)
        {
            return _unitOfWork.EvaluacionRepository.GetEvalacionByMateria(idMateria);
        }

        public Evaluacion GetEvaluacion(int id)
        {
            return _unitOfWork.EvaluacionRepository.GetById(id);
        }

        public IEnumerable<Evaluacion> GetEvaluacionByAlumnoMateria(int idAlumno, int idMateria)
        {
            return _unitOfWork.EvaluacionRepository.GetEvaluacionByAlumnoMateria(idAlumno, idMateria);
        }

        public IEnumerable<Evaluacion> GetEvaluacionByFecha(string fecha)
        {
            return _unitOfWork.EvaluacionRepository.GetEvaluacionByFecha(fecha);
        }

        public PagedList<Evaluacion> GetEvaluaciones(int? PageNumber, int? PageSize)
        {
            var evaluaciones = _unitOfWork.EvaluacionRepository.GetAll();
            var pagedPosts = PagedList<Evaluacion>.Create(evaluaciones, (int)PageNumber, (int)PageSize);
            return pagedPosts;
        }

        public void InsertEvaluacion(Evaluacion evaluacion)
        {
            _unitOfWork.EvaluacionRepository.Add(evaluacion);
            _unitOfWork.WriteXML(_ds);
        }

        public bool UpdateEvaluacion(Evaluacion evaluacion)
        {
            _unitOfWork.EvaluacionRepository.Update(evaluacion);
            _unitOfWork.WriteXML(_ds);
            return true;
        }
    }
}
