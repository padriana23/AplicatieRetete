using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using AplicatieRetete.Models;

namespace AplicatieRetete.Data
{
    public class ReteteDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReteteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Retete>().Wait();
        }
        public Task<List<Retete>> GetRetetesAsync()
        {
            return _database.Table<Retete>().ToListAsync();
        }
        public Task<Retete> GetReteteAsync(int id)
        {
            return _database.Table<Retete>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveReteteAsync(Retete slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteReteteAsync(Retete slist)
        {
            return _database.DeleteAsync(slist);
        }

    }
}
