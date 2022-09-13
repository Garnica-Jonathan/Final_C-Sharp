using Entrega_Final.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Entrega_Final.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString = "Server=DESKTOP-JU65CF5;Database=SistemaGestion;Trusted_Connection=true";

        public static Usuario GetTraerUsuario(string nombreUsuario)
        {
            Usuario resultado = new Usuario();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string traer = "Select * From Usuario Where NombreUsuario = @nombreUsuario";

                SqlParameter valor = new SqlParameter("nombreUsuario", SqlDbType.VarChar);
                valor.Value = nombreUsuario;

                using (SqlCommand sqlCommand = new SqlCommand(traer, sqlConnection))
                {
                    sqlCommand.Parameters.Add(valor);

                    sqlConnection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(reader["Id"]);
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Mail = reader["Mail"].ToString();

                                resultado = usuario;

                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }

        public static Usuario InicioSesion(string nombreUsuario, string contraseña)
        {
            Usuario resultado = new Usuario();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string inicio = "Select * From Usuario " +
                    "Where NombreUsuario = @nombreUsuario AND Contraseña = @contraseña";

                SqlParameter usuarioParameter = new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = nombreUsuario };
                SqlParameter contraseñaParameter = new SqlParameter("contraseña", SqlDbType.VarChar) { Value = contraseña };
                
                using (SqlCommand sqlCommand = new SqlCommand(inicio, sqlConnection))
                {
                    sqlCommand.Parameters.Add(usuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);

                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(reader["Id"]);
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Mail = reader["Mail"].ToString();

                                resultado = usuario;

                            }
                        }
                    }
                    sqlConnection.Close();
                }
                
            }
            return resultado;
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            bool resultado = false;
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                String queryInsert = "Insert Into Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                    "Values (@nombreParameter, @apellidoParameter, @nombreUsuarioParameter, @contraseñaParameter, @mailParameter)";

                SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuarioParameter", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter contraseñaParameter = new SqlParameter("contraseñaParameter", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter mailParameter = new SqlParameter("mailParameter", SqlDbType.VarChar) { Value = usuario.Mail };


                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(mailParameter);

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

        public static bool EliminarUsuario(Usuario usuario)
        {
            bool resultado = false;
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                String queryDelete = "Delete From Usuario Where Id = @Id";

                SqlParameter parameterDelete = new SqlParameter("id", SqlDbType.BigInt) { Value = usuario.Id};
                

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parameterDelete);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if(numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
                sqlConnection.Close();
            }
            return resultado;
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            bool resultado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "Update Producto Set Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, " +
                    "Contraseña = @contraseña, Mail= @mail Where Id = @Id  ";

                SqlParameter Nombre = new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter Apellido = new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter NombreUsuario = new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter Contraseña = new SqlParameter("contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter Mail = new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Mail };
                SqlParameter id = new SqlParameter("id", SqlDbType.BigInt) { Value = usuario.Id};

                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(Nombre);
                    sqlCommand.Parameters.Add(id);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if( numberOfRows > 0)
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
