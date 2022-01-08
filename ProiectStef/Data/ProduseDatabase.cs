using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProiectStef.Models;
using SQLite;


namespace ProiectStef.Data
{
    public class ProduseDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProduseDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Produse>().Wait();
        }
        public Task<List<Produse>> GetProduseAsync()
        {
            return _database.Table<Produse>().ToListAsync();
        }
        public Task<Produse> GetProduseAsync(int id)
        {
            return _database.Table<Produse>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveProduseAsync(Produse plist)
        {
            if (plist.ID != 0)
            {
                return _database.UpdateAsync(plist);
            }
            else
            {
                return _database.InsertAsync(plist);
            }
        }
        public Task<int> DeleteProduseAsync(Produse plist)
        {
            return _database.DeleteAsync(plist);
        }
    }
}
