using Core.Entities;
using Core.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class BackUpRepository : BaseRepository<BackUp>, IBackUpRepository
    {
        private readonly DataSet _ds = DataAccess.Instancia.ds;
        public IEnumerable<BackUp> GetBackUpByDate(DateTime fecha)
        {
            var fechaActual = fecha.ToString("dd-MM-yyyy");
            var fechaBuscar = GetAll().FirstOrDefault();
            var fechaBuscar2 = fechaBuscar.Fecha;
            IEnumerable <BackUp> getByDate = GetAll().Where(x => x.Fecha == fecha.ToString("dd-MM-yyyy")).ToList();
            return getByDate;
        }

        public void RestoreBackUp(int id)
        {
            DataRow newRow = _ds.Tables[typeof(BackUp).Name].AsEnumerable().Where(d => d.Field<string>("ID") == id.ToString()).FirstOrDefault();
            string fecha = newRow.Field<string>("fecha");
            DataSet ds = new DataSet();
            ds.ReadXml($"C:/Users/paulo/source/repos/SistemaGestionEscolarV4.0/Data/XML/DB BackUp-{fecha}.Xml");
            ds.WriteXml($@"C:/Users/paulo/source/repos/SistemaGestionEscolarV4.0/Data/XML/DB.xml");
        }
    }
}
