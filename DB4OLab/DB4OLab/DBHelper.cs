using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB4OLab
{
    public class DBHelper
    {
        public static string DBName { get; set; }
        private static IObjectContainer _database = null;
        public static IObjectContainer Database
        {
            get { return _database; }
        }
        public static void OpenDatabase(string file = "DB4Odata.k43")
        {
            DBName = file;
            _database = Db4oEmbedded.OpenFile(file);
        }

        public static void CloseDatabase()
        {
            _database.Close();
        }

        public static void InsertObject<T>(T data)
        {
            OpenDatabase();
            _database.Store(data);
            CloseDatabase();
        }

        public static void UpdateObject<T>(T template, T data)
        {
            OpenDatabase();
            IObjectSet result = _database.QueryByExample(template);
            //get first
            T obj = (T) result[0];
            //update for data
            
            _database.Store(obj);
            CloseDatabase();
        }

        public static void DeleteObject<T>(T template)
        {
            OpenDatabase();
            IObjectSet result = _database.QueryByExample(template);
            //get first
            T obj = (T)result[0];
            _database.Delete(obj);
            CloseDatabase();
        }

        public static List<T> GetAll<T>(T template)
        {
            OpenDatabase();
            List<T> result = new List<T>();
            IObjectSet results = _database.QueryByExample(template);
            for (int i = 0; i < results.Count; i++)
            {
                result.Add((T)results[i]);
            }

            CloseDatabase();
            return result;
        }        
    }
}
