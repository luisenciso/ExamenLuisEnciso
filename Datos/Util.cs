using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Data;

namespace Datos
{
    public static class Util
    {
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _Properties =
        new Dictionary<Type, IEnumerable<PropertyInfo>>();


        public static T DataTableToClass<T>(this DataTable table) where T : class, new()
        {
            var objType = typeof(T);
            IEnumerable<PropertyInfo> properties;
            lock (_Properties)
            {
                if (!_Properties.TryGetValue(objType, out properties))
                {
                    properties = objType.GetProperties().Where(property => property.CanWrite);
                    _Properties.Add(objType, properties);
                }
            }
            var obj = new T();
            foreach (var row in table.AsEnumerable())
            {
                foreach (var prop in properties)
                {
                    try
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                    }
                    catch
                    {
                    }
                }
            }
            return obj;
        }


        public static IEnumerable<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var objType = typeof(T);
                IEnumerable<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite);
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        try
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                        }
                        catch
                        {
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
