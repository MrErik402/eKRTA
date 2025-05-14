using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    class GenericRepository<T> : IGenericRepository<T> where T : new()
    {
        //A GenericRepository osztály megvalósítja az IGenericRepository interfészt.
        //Ezért meg kell valósítani az összes metódust amit az interfész definiál.
        private readonly string _databasePath;
        public GenericRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        public List<T> GetAll()
        {
            using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(_databasePath))
            {
                sQLiteConnection.CreateTable<T>();
                return sQLiteConnection.Table<T>().ToList();
            }
        }
        public void insert(T item)
        {
            using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(_databasePath))
            {
                sQLiteConnection.CreateTable<T>();
                sQLiteConnection.Insert(item);
            }
        }
        public void update(T item)
        {
            using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(_databasePath))
            {
                sQLiteConnection.CreateTable<T>();
                sQLiteConnection.Update(item);
            }
        }
        public void delete(T item)
        {
            using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(_databasePath))
            {
                sQLiteConnection.CreateTable<T>();
                sQLiteConnection.Delete(item);
            }
        }
    }
}
