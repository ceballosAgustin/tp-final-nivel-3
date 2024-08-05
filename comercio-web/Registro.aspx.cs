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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                UserNegocio negocio = new UserNegocio();

                bool hayError = false;

                hayError |= Validacion.validaTextoVacio(txtNombre, lblErrorNombre, "❗ Debes ingresar tu nombre");
                hayError |= Validacion.validaTextoVacio(txtApellido, lblErrorApellido, "❗ Debes ingresar tu apellido");
                hayError |= Validacion.validaTextoVacio(txtEmail, lblErrorEmail, "❗ Debes ingresar tu E-mail");
                hayError |= Validacion.validaTextoVacio(txtPassword, lblErrorPass, "❗ Debes ingresar tu contraseña");

                if (hayError)
                {
                    return;
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                user.Id = negocio.insertarNuevo(user);
                Session.Add("user", user);

                Response.Redirect("Articulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}