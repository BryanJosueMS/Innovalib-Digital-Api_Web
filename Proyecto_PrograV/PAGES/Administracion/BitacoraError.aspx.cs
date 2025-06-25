using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;

namespace Proyecto_PrograV.PAGES.Administracion
{
    public partial class BitacoraError : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si el usuario tiene el rol de Administrador
                if ((Session["Rol"] != null) && (Session["Rol"].ToString().Trim() == "Administrador"))
                {
                    // Cargar la bitácora de errores al cargar la página
                    CargarBitacoraErrores();
                }
                else
                {
                    // Redirigir a una página de acceso denegado o mostrar un mensaje
                    Response.Redirect("~/PAGES/AccesoDenegado.aspx");
                }
            }
        }

        /// <summary>
        /// Carga los datos de la bitácora de errores en el GridView.
        /// </summary>
        private void CargarBitacoraErrores()
        {
            try
            {
                // Obtener todos los registros de la tabla BitacoraErrores
                gvBitacoraErrores.DataSource = entities.BitacoraErrores.ToList();
                gvBitacoraErrores.DataBind();

            }
            catch (Exception ex)
            {

                entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"]?.ToString());

            }
        }

    }
}