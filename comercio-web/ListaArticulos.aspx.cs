using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace comercio_web
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "Se requieren permisos de admin para acceder a este apartado.");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                ArticuloNegocio negocio = new ArticuloNegocio();

                Session.Add("listaArticulos", negocio.listarConSP());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}