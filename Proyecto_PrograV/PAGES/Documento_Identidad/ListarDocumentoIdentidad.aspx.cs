using Proyecto_PrograV.DATA;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Documento_Identidad
{
    public partial class ListarDocumentoIdentidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDocumentos();
            }
        }

        //metodo que carga los datos de los documento registrados en el sistema
        private void CargarDocumentos()
        {
            try
            {
                var db = new Proyecto_PrograVEntities1();
                var documentos = db.sp_listar_documento_identidad().ToList();

                gvDocumentos.DataSource = documentos;
                gvDocumentos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error en logs)
                Console.WriteLine("Error al cargar documentos de identidad: " + ex.Message);
            }
        }

        //metodo que redirecciona al aspx que crea un nuevo documento
        protected void btnNuevoDocumento_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarDocumentoIdentidad.aspx");
        }

        //metodo que redirecciona al aspx que actualiza un documento
        protected void gvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarDocumento")
            {
                // Obtener el ID del documento seleccionado
                string documentoId = e.CommandArgument.ToString();

                // Verificar si el ID es válido
                if (!string.IsNullOrEmpty(documentoId))
                {
                    // Redirigir a la página de modificación
                    Response.Redirect("/PAGES/Documento_Identidad/ModificarDocumentoIdentidad.aspx?id=" + documentoId, false);
                    Context.ApplicationInstance.CompleteRequest(); // Asegura que la respuesta se procese correctamente
                }
            }
        }
    }
}