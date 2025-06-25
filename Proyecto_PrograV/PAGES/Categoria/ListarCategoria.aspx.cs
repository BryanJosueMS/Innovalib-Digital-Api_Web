using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Categoria
{
    public partial class ListarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        //metodo que carga los datos de las categorias registradas
        private void CargarCategorias()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var categorias = db.sp_listar_categoria().ToList();

                gvCategorias.DataSource = categorias;
                gvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error en logs)
                Console.WriteLine("Error al cargar categorías: " + ex.Message);
            }
        }

        //metodo que redirecciona al aspx que crea una nueva categoria
        protected void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }

        //metodo que redirecciona al aspx que actualiza una categoria
        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarCategoria")
            {
                // Obtener el ID de la categoría seleccionada
                string categoriaId = e.CommandArgument.ToString();

                // Verificar si el ID es válido
                if (!string.IsNullOrEmpty(categoriaId))
                {
                    // Redirigir a la página de modificación
                    Response.Redirect("/PAGES/Categoria/ModificarCategoria.aspx?id=" + categoriaId, false);
                    Context.ApplicationInstance.CompleteRequest(); // Asegura que la respuesta se procese correctamente
                }
            }
        }
    }
}