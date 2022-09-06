using MiPrimeraApi.Model;
using System.Data;
using System.Data.SqlClient;

public class InicioSesion : Usuario
{
    public const string ConnectionString = "Server=DESKTOP-NM1D9DV;Initial Catalog=SistemaGestion;Trusted_Connection=true";
    public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString)) 
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer del inicio sesion 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();                                
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();                              
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return usuarios;
        }
    }