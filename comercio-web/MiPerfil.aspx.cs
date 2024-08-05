using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace comercio_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["user"]))
                    {
                        User user = (User)Session["user"];

                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;

                        if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        {
                            imgNuevoPerfil.ImageUrl = "~/ProfileImages/" + user.UrlImagenPerfil; 
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            try
            {
                UserNegocio negocio = new UserNegocio();
                User user = (User)Session["user"];

                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./ProfileImages/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                bool hayError = false;

                hayError |= Validacion.validaTextoVacio(txtNombre, lblErrorNombre, "❗ Debes ingresar tu nombre");
                hayError |= Validacion.validaTextoVacio(txtApellido, lblErrorApellido, "❗ Debes ingresar tu apellido");

                if (hayError)
                {
                    return;
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.actualizar(user);
                Image imgAvatar = (Image)Master.FindControl("imgAvatar");

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/ProfileImages/" + user.UrlImagenPerfil + "?t=" + DateTime.Now.Ticks.ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "toastr.success('Tus datos han sido guardados exitosamente.', '¡Excelente!', {timeOut: 3000});", true);

                // Response.Redirect("Articulos.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}