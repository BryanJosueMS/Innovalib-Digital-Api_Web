using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Administracion
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LIMPIAR LA SESION Y REDIRECCIONAR AL LOGIN
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/PAGES/Login/Login.aspx");
        }
    }
}