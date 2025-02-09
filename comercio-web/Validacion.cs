﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace comercio_web
{
    public static class Validacion
    {
        //public static bool validaTextoVacio(object control)
        //{
        //    if (control is TextBox texto)
        //    {
        //        // Si el texto está nulo o vacío
        //        if (string.IsNullOrEmpty(texto.Text))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    return false;
        //}

        public static bool validaTextoVacio(TextBox textBox, Label errorLabel, string mensaje)
        {
            if(string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorLabel.Text = mensaje;
                errorLabel.Visible = true;
                return true;
            }
            else
            {
                errorLabel.Visible = false;
                return false;
            }
        }

    }
}