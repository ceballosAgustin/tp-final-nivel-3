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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();

            try
            {
                bool hayError = false;

                hayError |= Validacion.validaTextoVacio(txtEmail, lblErrorEmail, "❗ Debes ingresar tu E-mail");
                hayError |= Validacion.validaTextoVacio(txtPassword, lblErrorPass, "❗ Debes ingresar tu contraseña");

                if(hayError)
                {
                    // Si hay un error, no sigue el método
                    return;
                }

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Articulos.aspx", false);
                }
                else
                {
                    Session.Add("error", "E-mail o Contraseña incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}