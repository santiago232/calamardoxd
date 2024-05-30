using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace ProyectoFinal5
{
    public class DataAccess


    {
        public const string CONNECTION_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Pineda's\\source\\repos\\ProyectoFinal5\\ProyectoFinal5\\Tienda.mdf\";Integrated Security=True";
        public const string CADENA_SQL_SERVER = "Server=DESKTOP-3C889HT\\SQLEXPRESS01;Integrated Security=true;Initial Catalog=MyDatabase";

        private readonly string connectionString;

        public DataAccess()
        {
            this.connectionString = CADENA_SQL_SERVER;
        }

        public List<Producto> GetAllDapper()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (SqlConnection conn = new SqlConnection(CADENA_SQL_SERVER))
                {
                    conn.Open();
                    string query = "SELECT Codigo, Descripcion, Cantidad, PrecioDeIngreso, PrecioDeVenta, FechaDeIngreso FROM Productos";
                    productos = conn.Query<Producto>(query).ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return productos;
        }
        public List<MovimientoCaja> GetAllMovimientosCaja()
        {
            List<MovimientoCaja> movimientosCaja = new List<MovimientoCaja>();
            try
            {
                using (SqlConnection conn = new SqlConnection(CADENA_SQL_SERVER))
                {
                    conn.Open();
                    string query = "SELECT id, TipoMovimiento, Cantidad, Descripcion, Monto, Fecha FROM MovimientoCaja";
                    movimientosCaja = conn.Query<MovimientoCaja>(query).ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return movimientosCaja;
        }
    }
}
