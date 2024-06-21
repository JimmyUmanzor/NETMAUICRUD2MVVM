
using NETMAUICRUD2MVVM.Models;
using SQLite;

namespace NETMAUICRUD2MVVM.Services
{
    public class ProveedorService
    {
        private readonly SQLiteConnection dbConnection;
        public ProveedorService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Proveedor>();
            
        }

        public List<Proveedor> GetAll()
        {
            var res = dbConnection.Table<Proveedor>().ToList();
            return res;
        }

        public int Insert(Proveedor proveedor)
        {
            return dbConnection.Insert(proveedor);
        }

        public int Update(Proveedor proveedor)
        {
            return dbConnection.Update(proveedor);
        }
        public int Delete(Proveedor proveedor)
        {
            return dbConnection.Delete(proveedor);
        }
    }
}
