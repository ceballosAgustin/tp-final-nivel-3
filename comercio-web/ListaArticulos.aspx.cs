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
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
            btnReiniciarLista.Enabled = !FiltroAvanzado;

            CargarCriterios();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCriterios();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                                                          ddlCriterio.SelectedItem.ToString(),
                                                          txtFiltroAvanzado.Text);

                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Reinicio valores del filtro avanzado
            ddlCampo.SelectedIndex = 0;
            ddlCriterio.Items.Clear();
            txtFiltroAvanzado.Text = string.Empty;

            CargarCriterios();

            ArticuloNegocio negocio = new ArticuloNegocio();

            Session.Add("listaArticulos", negocio.listarConSP());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }
        protected void btnReiniciarLista_Click(object sender, EventArgs e)
        {
            txtFiltroAvanzado.Text = string.Empty;

            ArticuloNegocio negocio = new ArticuloNegocio();

            Session.Add("listaArticulos", negocio.listarConSP());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void CargarCriterios()
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedItem != null)
            {
                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    ddlCriterio.Items.Add("Igual a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina");
                }
            }
        }

    }
}