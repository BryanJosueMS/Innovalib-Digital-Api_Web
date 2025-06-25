using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Autor
{
    public partial class ListarAutor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAutores();
            }
        }

        //metodo que carga los autores registrados en el sistema
        private void CargarAutores()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var autores = db.sp_listar_autor().ToList();

                gvAutores.DataSource = autores;
                gvAutores.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error en logs)
                Console.WriteLine("Error al cargar autores: " + ex.Message);
            }
        }

        //metodo que referencia al aspx que crea un nuevo autor
        protected void btnNuevoAutor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAutor.aspx");
        }

        //metodo que referencia al aspx que modifica un autor
        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarAutor")
            {
                // Obtener el ID del autor seleccionado
                string autorId = e.CommandArgument.ToString();

                // Verificar si el ID es válido
                if (!string.IsNullOrEmpty(autorId))
                {
                    // Redirigir a la página de modificación
                    Response.Redirect("/PAGES/Autor/ModificarAutor.aspx?id=" + autorId, false);
                    Context.ApplicationInstance.CompleteRequest(); // Asegura que la respuesta se procese correctamente
                }
            }
        }
    }
}