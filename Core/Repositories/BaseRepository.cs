using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Core.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataSet _ds;
        public BaseRepository()
        {
            _ds = Data.DataAccess.Instancia.ds;
        }
        public void Add(T entity)
        {
            var properties = typeof(T).GetProperties().OrderBy(x => x.MetadataToken).ToList();
            if (properties[0].Name != "Id")
            {
                var temp = properties[properties.Count-1];
                properties.Insert(0, temp);
                properties.RemoveAt(properties.Count - 1);
            }
            var table = _ds.Tables[typeof(T).Name];

            try 
            {
                foreach (var property in properties)
                {
                    table.Columns.Add(property.Name, property.PropertyType);
                }
                table.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());
                _ds.AcceptChanges();
            }
            catch
            {
                table.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());
                _ds.AcceptChanges();
            }
        }

        public void Delete(int id)
        {
            for (int i = _ds.Tables[typeof(T).Name].Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = _ds.Tables[typeof(T).Name].Rows[i];
                if (dr[0].ToString() == id.ToString())
                {
                    dr.Delete();
                }
            }
            _ds.AcceptChanges();
        }

        public IEnumerable<T> GetAll()
        {
            List<T> getAll = JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(_ds.Tables[typeof(T).Name]), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return getAll;
        }

        public T GetById(int id)
        {
            T getById = GetAll().Where(x => x.Id == id).FirstOrDefault();
            return getById;
        }

        public void Update(T entity)
        {
            for (int i = _ds.Tables[typeof(T).Name].Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = _ds.Tables[typeof(T).Name].Rows[i];
                if (dr[0].ToString() == entity.Id.ToString())
                {
                    dr.Delete();
                }
            }
            _ds.AcceptChanges();

            var properties = typeof(T).GetProperties().OrderBy(x => x.MetadataToken).ToList();
            if (properties[0].Name != "Id")
            {
                var temp = properties[properties.Count - 1];
                properties.Insert(0, temp);
                properties.RemoveAt(properties.Count - 1);
            }
            var table = _ds.Tables[typeof(T).Name];

            try
            {
                foreach (var property in properties)
                {
                    table.Columns.Add(property.Name, property.PropertyType);
                }
                table.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());
                _ds.AcceptChanges();
            }
            catch
            {
                table.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());
                _ds.AcceptChanges();
            }
        }
    }
}
