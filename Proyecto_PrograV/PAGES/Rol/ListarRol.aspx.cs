using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Rol
{
    public partial class ListarRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
            }
        }

        //metodo que carga los datos de los roles en el sistema
        private void CargarRoles()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var roles = db.sp_listar_rol().ToList();

                gvRoles.DataSource = roles;
                gvRoles.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error en logs)
                Console.WriteLine("Error al cargar roles: " + ex.Message);
            }
        }

        //metodo que redirecciona al aspx que guarda un nuevo rol
        protected void btnNuevoRol_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarRol.aspx");
        }

        //metodo que redirecciona al aspx que modfica un rol
        protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarRol")
            {
                // Obtener el ID del rol seleccionado
                string rolId = e.CommandArgument.ToString();

                // Verificar si el ID es válido
                if (!string.IsNullOrEmpty(rolId))
                {
                    // Redirigir a la página de modificación
                    Response.Redirect("/PAGES/Rol/ModificarRol.aspx?id=" + rolId, false);
                    Context.ApplicationInstance.CompleteRequest(); // Asegura que la respuesta se procese correctamente
                }
            }
        }
    }
}