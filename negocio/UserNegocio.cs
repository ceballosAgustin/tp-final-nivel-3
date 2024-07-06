using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UserNegocio
    {
        public bool Login(User user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email AND pass = @pass");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)datos.Lector["admin"];

                    // Si no está vacía
                    if (!(datos.Lector["nombre"] is DBNull))
                    {
                        user.Nombre = (string)datos.Lector["nombre"];
                    }

                    if (!(datos.Lector["apellido"] is DBNull))
                    {
                        user.Apellido = (string)datos.Lector["apellido"];
                    }

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                    {
                        user.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int insertarNuevo(User nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizar(User user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil Where Id = @id");
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);

                // Si no hay imagen, que pase NULL a la DB
                datos.setearParametro("@urlImagenPerfil", user.UrlImagenPerfil != null ? user.UrlImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("@id", user.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
