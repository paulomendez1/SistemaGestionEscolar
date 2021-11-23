using BLL.Services;
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
    public class MateriaController
    {
        private readonly MateriaService _materiaService = new();
        private readonly DocenteService _docenteService = new();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable GetMaterias(int? pageNumber, int? pageSize)
        {
            var materias = _materiaService.GetMaterias(pageNumber, pageSize);
            return _materiaService.GetMaterias(pageNumber, pageSize).Select(x => new MateriaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Docente = $"{_docenteService.GetDocente(x.DocenteId).Nombre} {_docenteService.GetDocente(x.DocenteId).Apellido}"
            }).ToList();
        }

        public void AddMateria(IDictionary<string, string> oMateria)
        {
            Materia materia = oMateria.Select(x => new Materia
            {
                Id = _unitOfWork.MateriaRepository.GetAll().LastOrDefault().Id + 1,
                Nombre = oMateria["Nombre"],
                DocenteId = Convert.ToInt32(oMateria["DocenteId"])
            }).FirstOrDefault();

            _materiaService.InsertMateria(materia);
        }

        public Materia GetMateria(int id)
        {
            return _materiaService.GetMateria(id);
        }

        public void DeleteMateria(int id)
        {
            _materiaService.DeleteMateria(id);
        }

        public void UpdateMateria(IDictionary<string, string> oMateria)
        {
            Materia materia = oMateria.Select(x => new Materia
            {
                Id = Convert.ToInt32(oMateria["Id"]),
                Nombre = oMateria["Nombre"],
                DocenteId = Convert.ToInt32(oMateria["DocenteId"])
            }).FirstOrDefault(); ;

            _materiaService.UpdateMateria(materia);
        }


    }
}

