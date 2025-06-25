using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Libro
{
    public partial class ListarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLibros();
            }
        }

        //metodo que lista los libros registrados en el sistema
        private void CargarLibros()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var libros = db.sp_listar_libro().ToList();

                gvLibros.DataSource = libros;
                gvLibros.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al cargar libros: " + ex.Message);
            }
        }

        //metodo que redirecciona al aspx que crea un nuevo libro
        protected void btnNuevoLibro_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarLibro.aspx");
        }

        //metodo que redirecciona al aspx que modifica un libro
        protected void gvLibros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarLibro")
            {
                string libroId = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(libroId))
                {
                    Response.Redirect("/PAGES/Libro/ModificarLibro.aspx?id=" + libroId, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}