using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace VFViewModel.Helpers
{
    public class DatabaseHelper
    {
        
        private static string vehilcleFleetDb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "vehicleFleetDb.db3");
        public static bool Insert<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(vehilcleFleetDb))
            {
                connection.CreateTable<T>();
                int numberOfItems = connection.Insert(item);
                if (numberOfItems > 0) result = true;
            }
                return result;
        }
        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(vehilcleFleetDb))
            {
                connection.CreateTable<T>();
                int numberOfItems = connection.Update(item);
                if (numberOfItems > 0) result = true;
            }
                return result;
        }
        public static bool Delete<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(vehilcleFleetDb))
            {
                connection.CreateTable<T>();
                int numberOfItems = connection.Delete(item);
                if (numberOfItems > 0) result = true;
            }
                return result;
        }
        public static List<T> Read<T>() where T : new()
        {
            List<T> items;
            using (SQLiteConnection connection = new SQLiteConnection(vehilcleFleetDb))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }
                return items;
        }
    }
}
