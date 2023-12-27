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
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();
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
        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }
        public Task<int> SaveListProductAsync(ListProduct listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Product>> GetListProductsAsync(int reteteid)
        {
            return _database.QueryAsync<Product>(
            "select P.ID, P.Description from Product P"
            + " inner join ListProduct LP"
            + " on P.ID = LP.ProductID where LP.ReteteID = ?",
            reteteid);
        }
    }
}
