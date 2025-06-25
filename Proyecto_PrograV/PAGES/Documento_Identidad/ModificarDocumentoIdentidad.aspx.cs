using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Documento_Identidad
{
    public partial class ModificarDocumentoIdentidad : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        private int _documentoId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out _documentoId))
                {
                    hfDocumentoId.Value = _documentoId.ToString();
                    CargarDocumento(_documentoId);
                }
                else
                {
                    MostrarError("ID de documento no válido");
                    btnActualizar.Enabled = false;
                }
            }
        }

        //metodo que mapea los datos del documento a modificar
        private void CargarDocumento(int documentoId)
        {
            try
            {
                var documento = entities.documento_identidad.Find(documentoId);
                if (documento != null)
                {
                    txtNombre.Text = documento.nombre;
                }
                else
                {
                    MostrarError("Documento no encontrado");
                    btnActualizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar documento: " + ex.Message);
                RegistrarError(ex);
                btnActualizar.Enabled = false;
            }
        }

        //evento click que actualiza los datos del documento a modificar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && int.TryParse(hfDocumentoId.Value, out _documentoId))
            {
                try
                {
                    string nombre = txtNombre.Text.Trim();

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado
                    entities.sp_actualizar_documento_identidad(
                        p_documento_identidad_id: _documentoId,
                        p_nombre: nombre,
                        p_respuesta: p_respuesta
                    );

                    // Verificar la respuesta
                    if ((int)p_respuesta.Value > 0)
                    {
                        MostrarExito("Documento actualizado correctamente");
                        Response.Redirect("/PAGES/Documento_Identidad/ResultadoModificarDocumento_Identidad.aspx");
                    }
                    else
                    {
                        MostrarError("No se pudo actualizar el documento");
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("Error al actualizar documento: " + ex.Message);
                    RegistrarError(ex);
                }
            }
        }

        private void MostrarError(string mensaje)
        {
            lblResultado.ForeColor = System.Drawing.Color.Red;
            lblResultado.Text = mensaje;
        }

        private void MostrarExito(string mensaje)
        {
            lblResultado.ForeColor = System.Drawing.Color.Green;
            lblResultado.Text = mensaje;
        }

        private void RegistrarError(Exception ex)
        {
            if (Session["Usuario"] != null)
            {
                entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"].ToString());
            }
        }
    }
}