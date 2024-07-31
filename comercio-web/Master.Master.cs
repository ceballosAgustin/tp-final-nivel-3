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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Default || Page is Registro || Page is Error))
            {
                // Sin sesión activa, a loguearse o registrarse
                if (!(Seguridad.sesionActiva(Session["user"])))
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    // Con sesión activa, la guardo
                    User user = (User)Session["user"];

                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/ProfileImages/" + user.UrlImagenPerfil;
                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}