using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Documento_Identidad
{
    public partial class AgregarDocumentoIdentidad : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializaciones si son necesarias
            }
        }

        //evento click que guarda el registro de un nuevo documento
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Obtener el valor del control
                    string nombre = txtNombre.Text.Trim();

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado
                    entities.sp_guardar_documento_identidad(
                        p_nombre: nombre,
                        p_respuesta: p_respuesta
                    );

                    // Verificar la respuesta
                    int resultado = (int)p_respuesta.Value;
                    if (resultado > 0)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Green;
                        lblResultado.Text = "Documento de identidad guardado correctamente.";

                        // Redirigir a la página de listado
                        Response.Redirect("/PAGES/Documento_Identidad/ResultadoAgregarDocumento_Identidad.aspx");
                    }
                    else
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "No se pudo guardar el documento. Verifique que no exista un documento con el mismo nombre.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                    lblResultado.Text = "Error al guardar el documento: " + ex.Message;

                    // Registrar en bitácora de errores si es necesario
                    if (Session["Usuario"] != null)
                    {
                        entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"].ToString());
                    }
                }
            }
        }
    }
}