using System.Data.SqlClient;
using MiPrimeraApi.Controllers;
using MiPrimeraApi.Model;

namespace MiPrimeraApi.Repository
{

    public static class VentaHandler
    {
        public const string ConnectionString = "Server=DESKTOP-NM1D9DV;Initial Catalog=SistemaGestion;Trusted_Connection=true";

        public static bool CargarVenta(Venta venta)
        {

            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[ProductoVendido] " + "WHERE Id = @id";

                SqlParameter idsqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt) {  Value = venta.Id};
                

                sqlConnection.Open();

                {
                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idsqlParameter);
                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }
        public static bool EliminarVenta(Venta venta)
        {

            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[ProductoVendido] " + "WHERE Id = @id";

                SqlParameter idsqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt) { Value = venta.Id };


                sqlConnection.Open();

                {
                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(idsqlParameter);
                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            resultado = true;
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }
        public static List<Venta> GetVentas()
        {
            List<Venta> resultado = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM VENTA", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //me aseguro que haya filas
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Stock = Convert.ToInt32(dataReader["Stock"]);
                                venta.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                venta.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);


                                resultado.Add(venta);
                            }

                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }

    }
}