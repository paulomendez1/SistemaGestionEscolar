using BLL.Services;
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
    public class BackUpController
    {
        private readonly BackUpService _backUpService = new();
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable GetBackUps()
        {
            var backups = _backUpService.GetBackUps();
            return _backUpService.GetBackUps().Select(x => new BackUp
            {
                Id = x.Id,
                Fecha = x.Fecha
            }).ToList();
        }

        public void DeleteBackUp(int id)
        {
            _backUpService.EliminarBackUp(id);
        }

        public IEnumerable GetBackUpByDate(DateTime fecha)
        {
            var backup = _backUpService.GetBackUpByDate(fecha);
            return _backUpService.GetBackUpByDate(fecha).Select(x => new BackUp
            {
                Id = x.Id,
                Fecha = x.Fecha
            }).ToList();
        }

        public BackUp GetUltimoBackUpId()
        {
            var backups = _backUpService.GetBackUps();
            return _backUpService.GetBackUps().Select(x => new BackUp
            {
                Id = x.Id,
                Fecha = x.Fecha
            }).LastOrDefault();
        }

        public void RestoreBackUp(int id)
        {
            _backUpService.RestoreBackUp(id);
        }

        public void CreateBackUp(string Fecha)
        {
            var backUp = _backUpService.GetBackUps().Select(x => new BackUp
            {
                Id = _unitOfWork.BackUpRepository.GetAll().LastOrDefault().Id + 1,
                Fecha = Fecha
            }).FirstOrDefault();

            _backUpService.CrearBackUp(backUp);
        }



    }
}
