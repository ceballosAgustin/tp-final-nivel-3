using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace comercio_web
{
    public partial class MisFavoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaFavoritos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    User user = (User)Session["user"];
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    ListaFavoritos = negocio.listar(user);

                    repRepetidor.DataSource = ListaFavoritos;
                    repRepetidor.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idArticulo = int.Parse(btnEliminar.CommandArgument);
            User user = (User)(Session["user"]);
            
            FavoritoNegocio negocio = new FavoritoNegocio();
            negocio.eliminar(user, idArticulo);
            Response.Redirect("MisFavoritos.aspx", false);
        }
    }
}