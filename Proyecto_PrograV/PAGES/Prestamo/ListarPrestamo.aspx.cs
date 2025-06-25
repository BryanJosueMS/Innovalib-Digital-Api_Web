using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.PrestamoLibro
{
    public partial class ListarPrestamoLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPrestamoLibro();
            }
        }

        //metodo que carga los datos del prestamo-libro
        private void CargarPrestamoLibro()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var prestamoLibros = db.sp_listar_prestamo_libro().ToList();

                // Dividir en préstamos activos y devueltos
                var prestamosActivos = prestamoLibros.Where(p => {
                    int estado;
                    return int.TryParse(p.estado_prestamo, out estado) && estado == 1;
                }).ToList();

                var prestamosDevueltos = prestamoLibros.Where(p => {
                    int estado;
                    return int.TryParse(p.estado_prestamo, out estado) && estado == 0;
                }).ToList();

                gvPrestamosActivos.DataSource = prestamosActivos;
                gvPrestamosActivos.DataBind();

                gvPrestamosDevueltos.DataSource = prestamosDevueltos;
                gvPrestamosDevueltos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error en logs)
                Console.WriteLine("Error al cargar préstamos-libros: " + ex.Message);
            }
        }

        //metodo que redirecciona al aspx que guarda un nuevo prestamo
        protected void btnNuevoPrestamoLibro_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPrestamo.aspx");
        }

        //metodo que redirecciona al aspx que modifica un prestamo
        protected void gvPrestamos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarPrestamoLibro")
            {
                // Obtener el ID del préstamo-libro seleccionado
                string prestamoLibroId = e.CommandArgument.ToString();

                // Verificar si el ID es válido
                if (!string.IsNullOrEmpty(prestamoLibroId))
                {
                    // Redirigir a la página de modificación
                    Response.Redirect("/PAGES/PrestamoLibro/ModificarPrestamoLibro.aspx?id=" + prestamoLibroId, false);
                    Context.ApplicationInstance.CompleteRequest(); // Asegura que la respuesta se procese correctamente
                }
            }
        }
    }
}