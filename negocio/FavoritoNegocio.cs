using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritoNegocio
    {
        public List<Articulo> listar(User user)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdArticulo from Favoritos where IdUser = @IdUser");
                datos.setearParametro("@IdUser", user.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idArticulo = (int)datos.Lector["IdArticulo"];

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo articulo = negocio.listar(idArticulo.ToString())[0];
                    lista.Add(articulo);
                }

                return lista;
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

        public void agregar(User user, Articulo articulo)
        {
            if (!verificarFavorito(user, articulo.Id))
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("insert into FAVORITOS(IdUser, IdArticulo) values (@IdUser, @IdArticulo)");

                    datos.setearParametro("@IdUser", user.Id);
                    datos.setearParametro("@IdArticulo", articulo.Id);

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

        public void eliminar(User user, int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdUser = @IdUser and IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", user.Id);
                datos.setearParametro("@IdArticulo", id);
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

        public bool verificarFavorito(User user, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select COUNT(*) from FAVORITOS where IdUser = @IdUser and IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", user.Id);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int contador = (int)datos.Lector[0];
                    return contador > 0;
                }
                else
                {
                    return false;
                }
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
