using BLL.Interfaces;
using Common;
using Core.Entities;
using Core.Interfaces;
using Core.Repositories;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BackUpService : IBackUpService
    {
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public void CrearBackUp(BackUp backup)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            var fechaExistente = _unitOfWork.BackUpRepository.GetAll().Where(x => x.Fecha == DateTime.Now.ToString("dd-MM-yyyy"));
            if (fechaExistente.Count() > 0)
            {
                throw new Exception("Ya se creo un backup el dia de hoy, si quiere crearlo de todas formas, antes debe eliminar el anterior que se creo en esta fecha!");
            }
            else
            {
                _unitOfWork.BackUpRepository.Add(backup);
                _unitOfWork.WriteXML(_ds);
                _ds.WriteXml($@"C:/Users/paulo/source/repos/SistemaGestionEscolarV4.0/Data/XML/DB BackUp-{fecha}.xml");
            }
        }

        public void EliminarBackUp(int id)
        {
            _unitOfWork.BackUpRepository.Delete(id);
            _unitOfWork.WriteXML(_ds);
        }

        public IEnumerable<BackUp> GetBackUpByDate(DateTime fecha)
        {
            return _unitOfWork.BackUpRepository.GetBackUpByDate(fecha);
        }

        public IEnumerable<BackUp> GetBackUps()
        {
            return _unitOfWork.BackUpRepository.GetAll();
        }

        public void RestoreBackUp(int id)
        {
            _unitOfWork.BackUpRepository.RestoreBackUp(id);
        }

    }
}
