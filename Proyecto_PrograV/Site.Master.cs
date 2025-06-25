using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null && !Request.Url.AbsolutePath.Contains("Login.aspx"))
            {
                Response.Redirect("~/PAGES/Login/Login.aspx");
            }


            //Valida si se debe mostrar la opcion de bitacora en el menu
            if (Session["Rol"] != null && Session["Rol"].ToString().Trim().Equals("Administrador"))
            {
                liBitacora.Visible = true;
                liAutor.Visible = true;
                liCategoria.Visible = true;
                liDocumento.Visible = true;
                liPrestamo.Visible = true;
                liRol.Visible = true;
                liUsuario.Visible = true;
                liLibro.Visible = true;  
            }
            else
            {
                liBitacora.Visible = false;
                liAutor.Visible = false;
                liCategoria.Visible = false;
                liDocumento.Visible = false;
                liPrestamo.Visible = false;
                liRol.Visible = false;
                liUsuario.Visible = false;
                liLibro.Visible = false;
            }
        }
    }
}