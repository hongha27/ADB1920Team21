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
        private static IObjectContainer Database = null;
        
        public static void OpenDatabase(string file = "DB4Odata.k43")
        {
            DBName = file;
            Database = Db4oEmbedded.OpenFile(file);
        }

        public static void CloseDatabase()
        {
            Database.Close();
        }

        public static void InsertObject<T>(T data)
        {
            OpenDatabase();
            Database.Store(data);
            CloseDatabase();
        }

        public static void UpdateObject<T>(T template, T data)
        {
            OpenDatabase();
            IObjectSet result = Database.QueryByExample(template);
            //get first
            T obj = (T) result[0];
            //update for data
            
            Database.Store(obj);
            CloseDatabase();
        }

        public static void DeleteObject<T>(T template)
        {
            OpenDatabase();
            IObjectSet result = Database.QueryByExample(template);
            //get first
            T obj = (T)result[0];
            Database.Delete(obj);
            CloseDatabase();
        }

        public static List<T> GetAll<T>(T template)
        {
            OpenDatabase();
            List<T> result = new List<T>();
            IObjectSet results = Database.QueryByExample(template);
            for (int i = 0; i < results.Count; i++)
            {
                result.Add((T)results[i]);
            }

            CloseDatabase();
            return result;
        }        
    }
}
