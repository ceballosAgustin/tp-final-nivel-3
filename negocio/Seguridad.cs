using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object usuario)
        {
            // Usuario distinto de null lo dejo como usuario y sino como nulo
            User user = usuario != null ? (User)usuario : null;

            // Distinto de null y si el ID no es 0 (ya existe)
            if(user != null && user.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esAdmin(object usuario)
        {
            User user = usuario != null ? (User)usuario : null;

            // Si no es nulo, devuelvo un Admin y sino un Usuario normal
            return user != null ? user.Admin : false;
        }
    }
}
