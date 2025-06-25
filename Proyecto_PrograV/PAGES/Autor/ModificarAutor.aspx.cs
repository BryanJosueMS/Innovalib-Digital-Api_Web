using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;

namespace Proyecto_PrograV.PAGES.Autor
{
    public partial class ModificarAutor : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int autorId;
                    if (int.TryParse(Request.QueryString["id"], out autorId))
                    {
                        CargarAutor(autorId);
                    }
                    else
                    {
                        lblResultado.Text = "ID de autor no válido.";
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        //metodo que mapea los datos del autor a modificar
        private void CargarAutor(int autorId)
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                try
                {
                    var autor = db.sp_consultar_autor(autorId).FirstOrDefault();

                    if (autor != null)
                    {
                        txtIdentificacion.Text = autor.identificacion;
                        txtNombre.Text = autor.nombre;
                        txtApellido1.Text = autor.apellido1;
                        txtApellido2.Text = autor.apellido2;
                        txtFechaNacimiento.Text = autor.fecha_nacimiento.ToString("yyyy-MM-dd");

                        if (autor.fecha_defuncion.HasValue)
                        {
                            txtFechaDefuncion.Text = autor.fecha_defuncion.Value.ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        lblResultado.Text = "No se encontró el autor.";
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.Text = "Error al cargar el autor: " + ex.Message;
                    lblResultado.ForeColor = System.Drawing.Color.Red;

                    if (Session["Usuario"] != null)
                    {
                        entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"].ToString());
                    }
                }
            }
        }

        //evento click que actualiza los datos del autor a modificar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int autorId = int.Parse(Request.QueryString["id"]);
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

                    // Obtener persona_id del autor
                    int personaId = 0;
                    using (var db = new Proyecto_PrograVEntities1())
                    {
                        var autor = db.autor.Find(autorId);
                        if (autor != null)
                        {
                            personaId = autor.persona_id;
                        }
                    }

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado
                    entities.sp_actualizar_autor(
                        p_autor_id: autorId,
                        p_persona_id: personaId,
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
                        lblResultado.Text = "Autor actualizado correctamente.";

                        // Redirigir a la página de listado
                        Response.Redirect("/PAGES/Autor/ResultadoModificarAutor.aspx");
                    }
                    else
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "No se pudo actualizar el autor.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                    lblResultado.Text = "Error al actualizar el autor: " + ex.Message;

                    if (Session["Usuario"] != null)
                    {
                        entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"].ToString());
                    }
                }
            }
        }
    }
}