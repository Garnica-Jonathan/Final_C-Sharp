using Entrega_Final.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Entrega_Final.Repository
{
    public class ProductoHandler
    {
        public const string ConnectionString = "Server=DESKTOP-JU65CF5;Database=SistemaGestion;Trusted_Connection=true";

        public static List<Producto> GetProducto()
        {
            List<Producto> resultado = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Select * From Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(reader["Id"]);
                                producto.Descripciones = reader["Descripciones"].ToString();
                                producto.Costo = Convert.ToInt32(reader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(reader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(reader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                                resultado.Add(producto);

                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }

        public static bool CrearProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                String queryInsert = "Insert Into Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) " +
                    "Values (@descripciones, @costo, @precioVenta, @stock, @idUsuario)";

                SqlParameter descripciones = new SqlParameter("descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                SqlParameter costo = new SqlParameter("costo", SqlDbType.VarChar) { Value = producto.Costo };
                SqlParameter precioVenta = new SqlParameter("precioVenta", SqlDbType.VarChar) { Value = producto.PrecioVenta };
                SqlParameter stock = new SqlParameter("stock", SqlDbType.VarChar) { Value = producto.Stock };
                SqlParameter idUsuario = new SqlParameter("idUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario };


                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(descripciones);
                    sqlCommand.Parameters.Add(costo);
                    sqlCommand.Parameters.Add(precioVenta);
                    sqlCommand.Parameters.Add(stock);
                    sqlCommand.Parameters.Add(idUsuario);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                }
                sqlConnection.Close();
            }
            return resultado;
        }

        public static bool ModificarProducto(Producto producto)
        {
            bool resultado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "Update Producto Set Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, " +
                    "Stock = @Stock, IdUsuario= @IdUsuario Where Id = @Id  ";

                SqlParameter Id = new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id };
                SqlParameter Descripciones = new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                SqlParameter Costo = new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.Costo };
                SqlParameter PrecioVenta = new SqlParameter("PrecioVenta", SqlDbType.BigInt) { Value = producto.PrecioVenta };
                SqlParameter Stock = new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock };
                SqlParameter IdUsuario = new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario };
                

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(Descripciones);
                    sqlCommand.Parameters.Add(Costo);
                    sqlCommand.Parameters.Add(PrecioVenta);
                    sqlCommand.Parameters.Add(Stock);
                    sqlCommand.Parameters.Add(IdUsuario);
                    sqlCommand.Parameters.Add(Id);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {

                        resultado = true;
                    }
                }
                sqlConnection.Close();
            }
            return resultado;
        }

        public static bool EliminarProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                String queryDelete = "Delete From Producto Where Id = @Id";

                SqlParameter parameterDelete = new SqlParameter("id", SqlDbType.BigInt) { Value = producto.Id };


                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterDelete);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
                sqlConnection.Close();
            }
            return resultado;
        }
    }
}
