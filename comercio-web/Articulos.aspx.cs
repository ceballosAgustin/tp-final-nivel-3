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
    public partial class Articulos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarConSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("DetalleArticulo.aspx?id=" + id + "&from=Articulos");
        }

        protected void btnFavorito_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                string idArticulo = ((ImageButton)sender).CommandArgument;

                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                Articulo articulo = articuloNegocio.listar(idArticulo)[0];

                if (!favoritoNegocio.verificarFavorito(user, articulo.Id))
                {
                    favoritoNegocio.agregar(user, articulo);
                    ImageButton btnFavorito = (ImageButton)sender;
                    btnFavorito.ImageUrl = "~/Images/in-favorito.png";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "toastr.success('El artículo ha sido agregado a favoritos.', '¡Agregado!', {timeOut: 3000});", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "toastr.warning('El artículo ya está en favoritos. Si deseas eliminarlo, ve hacía Mis Favoritos', 'Advertencia', {timeOut: 3000});", true);
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                FavoritoNegocio negocio = new FavoritoNegocio();

                var btnFavorito = (ImageButton)e.Item.FindControl("btnFavorito");
                var idArticulo = int.Parse(btnFavorito.CommandArgument);

                if(negocio.verificarFavorito(user, idArticulo))
                {
                    btnFavorito.ImageUrl = "~/Images/in-favorito.png";
                }
            }
        }
    }
}