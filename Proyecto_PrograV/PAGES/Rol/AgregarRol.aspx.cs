using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Rol
{
    public partial class AgregarRol : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializaciones si son necesarias
            }
        }

        //evento click que guarda un registro en el sistema
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
                    entities.sp_guardar_rol(
                        p_nombre: nombre,
                        p_respuesta: p_respuesta
                    );

                    // Verificar la respuesta
                    int resultado = (int)p_respuesta.Value;
                    if (resultado > 0)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Green;
                        lblResultado.Text = "Rol guardado correctamente.";

                        // Redirigir a la página de listado
                        Response.Redirect("/PAGES/Rol/ResultadoAgregarRol.aspx");
                    }
                    else
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "No se pudo guardar el rol. Verifique que no exista un rol con el mismo nombre.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                    lblResultado.Text = "Error al guardar el rol: " + ex.Message;

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