using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Globalization;

namespace comercio_web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtMarca.Text = seleccionado.Marca.Descripcion;
                    txtCategoria.Text = seleccionado.Categoria.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString("N2", CultureInfo.InvariantCulture);
                    imgArticulo.ImageUrl = seleccionado.ImagenUrl;
                    imgArticulo.DataBind();

                }

                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                txtDescripcion.Enabled = false;
                txtMarca.Enabled = false;
                txtCategoria.Enabled = false;
                txtPrecio.Enabled = false;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string paginaAnterior = Request.QueryString["from"];

            if (!string.IsNullOrEmpty(paginaAnterior))
            {
                Response.Redirect(paginaAnterior + ".aspx");
            }
            else
            {
                Response.Redirect("Articulos.aspx");
            }
        }

    }
}