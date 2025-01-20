using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StockScreener.Models1;
using System.Threading.Tasks;


namespace StockScreener.Services
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApp.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<MyDataModel>();
            _database.CreateTable<Stock>();
        }

        // Method to retrieve all items from the database
        public List<MyDataModel> GetItems()
        {
            return _database.Table<MyDataModel>().ToList();
        }

        // Method to save a new item to the database
        public int SaveItem(MyDataModel item)
        {
            return _database.Insert(item);
        }

        // Method to delete an item from the database
        public int DeleteItem(int id)
        {
            return _database.Delete<MyDataModel>(id);
        }

        // Method to update an existing item in the database
        public int UpdateItem(MyDataModel item)
        {
            return _database.Update(item);
        }

        public List<Stock> GetStocks()
        {
            return _database.Table<Stock>().ToList();
        }

        public int SaveStock(Stock stock)
        {
            return _database.Insert(stock);
        }
    }

    public class MyDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
