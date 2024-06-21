using SQLite;
using System.Diagnostics.CodeAnalysis;

namespace NETMAUICRUD2MVVM.Models
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo  { get; set; }

    }
}
