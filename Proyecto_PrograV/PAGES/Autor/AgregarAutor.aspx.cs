using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Autor
{
    public partial class AgregarAutor : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes agregar inicializaciones aquí si son necesarias
            }
        }

        //evento click que guarda a un nuevo autor
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Obtener los valores de los controles
                    string identificacion = txtIdentificacion.Text;
                    string nombre = txtNombre.Text;
                    string apellido1 = txtApellido1.Text;
                    string apellido2 = txtApellido2.Text;

                    // Convertir fechas
                    DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                    DateTime? fechaDefuncion = null;

                    if (!string.IsNullOrEmpty(txtFechaDefuncion.Text))
                    {
                        fechaDefuncion = DateTime.Parse(txtFechaDefuncion.Text);
                    }

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado CON LOS NOMBRES DE PARÁMETROS CORRECTOS
                    entities.sp_guardar_autor(
                        p_persona_id: 0, // Se determinará dentro del SP
                        p_identificacion: identificacion,
                        p_nombre: nombre,
                        p_apellido1: apellido1,
                        p_apellido2: apellido2,
                        p_fecha_nacimiento: fechaNacimiento,
                        p_fecha_defuncion: fechaDefuncion,
                        p_respuesta: p_respuesta
                    );

                    // Verificar la respuesta
                    int resultado = (int)p_respuesta.Value;
                    if (resultado > 0)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Green;
                        lblResultado.Text = "Autor guardado correctamente.";

                        // Redirigir a la página de listado
                        Response.Redirect("/PAGES/Autor/ResultadoAgregarAutor.aspx");
                    }
                    else
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "No se pudo guardar el autor.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                    lblResultado.Text = "Error al guardar el autor: " + ex.Message;

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