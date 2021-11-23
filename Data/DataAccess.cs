using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataAccess
    {
        private static DataAccess instancia = null;
        public DataSet ds = null;

        protected DataAccess()
        {
            ds = new DataSet();
            ds.ReadXml("C:/Users/paulo/source/repos/SistemaGestionEscolarV4.0/Data/XML/DB.Xml");

        }

        public static DataAccess Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new DataAccess();

                return instancia;

            }
        }
    }
}
