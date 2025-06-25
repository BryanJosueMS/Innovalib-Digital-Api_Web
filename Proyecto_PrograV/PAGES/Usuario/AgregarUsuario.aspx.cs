using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Usuario
{
    public partial class AgregarUsuario : Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los dropdowns con los datos desde la base de datos
                CargarTipoDocumento();
                CargarEstado();  // Cargar las opciones de estado
                CargarRol();
            }
        }

        //evento que carga los documentos disponibles
        private void CargarTipoDocumento()
        {
            try
            {
                using (var db = new Proyecto_PrograVEntities1())
                {
                    // Llamada al procedimiento almacenado para listar los tipos de documento
                    var tiposDocumento = db.sp_listar_documento_identidad().ToList();

                    // Limpiar los elementos actuales y agregar un valor por defecto
                    ddlDocumentoIdentidad.Items.Clear();
                    ddlDocumentoIdentidad.Items.Add(new ListItem("Seleccione el tipo de documento", ""));

                    // Agregar los elementos devueltos por el procedimiento almacenado al DropDownList
                    foreach (var item in tiposDocumento)
                    {
                        ddlDocumentoIdentidad.Items.Add(new ListItem(item.nombre, item.documento_identidad_id.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblResultado.ForeColor = System.Drawing.Color.Red;
                lblResultado.Text = "Error al cargar los tipos de documento: " + ex.Message;
            }
        }

        //metodo que carga los estados disponibles
        private void CargarEstado()
        {
            try
            {
                // Limpiar los elementos actuales y agregar un valor por defecto
                ddlEstado.Items.Clear();
                ddlEstado.Items.Add(new ListItem("Seleccione el estado", ""));

                // Agregar las opciones manualmente para "Activo" (A) e "Inactivo" (I)
                ddlEstado.Items.Add(new ListItem("Activo", "1"));
                ddlEstado.Items.Add(new ListItem("Inactivo", "0"));
            }
            catch (Exception oEx)
            {
                // Manejo de errores
                lblResultado.ForeColor = System.Drawing.Color.Red;
                lblResultado.Text = "Error al cargar los estados: " + oEx.Message;
                entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());
            }
        }

        //metodo que carga los roles disponibles
        private void CargarRol()
        {
            try
            {
                using (var db = new Proyecto_PrograVEntities1())
                {
                    // Llamada al procedimiento almacenado para listar los roles
                    var roles = db.sp_listar_rol().ToList();

                    // Limpiar los elementos actuales y agregar un valor por defecto
                    ddlRol.Items.Clear();
                    ddlRol.Items.Add(new ListItem("Seleccione el rol", ""));

                    // Agregar los elementos devueltos por el procedimiento almacenado al DropDownList
                    foreach (var item in roles)
                    {
                        ddlRol.Items.Add(new ListItem(item.nombre, item.rol_id.ToString()));
                    }
                }
            }
            catch (Exception oEx)
            {
                // Manejo de errores
                lblResultado.ForeColor = System.Drawing.Color.Red;
                lblResultado.Text = "Error al cargar los roles: " + oEx.Message;
                entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());

            }
        }

        //evento click que registra un usuario en el sistema
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Write("El evento btnGuardar_Click ha sido llamado.");  // Verificación

            if (Page.IsValid)
            {
                string nombre = txtNombre.Text;
                string apellido1 = txtApellido1.Text;
                string apellido2 = txtApellido2.Text;
                string identificacion = txtIdentificacion.Text;

                // Validar y convertir la fecha de nacimiento
                DateTime? fechaNacimiento = null;
                if (DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fecha))
                {
                    fechaNacimiento = fecha;
                }

                // Convertir a los tipos correctos
                int? documentoIdentidad = string.IsNullOrEmpty(ddlDocumentoIdentidad.SelectedValue)
                    ? (int?)null
                    : int.Parse(ddlDocumentoIdentidad.SelectedValue);

                int? rol = string.IsNullOrEmpty(ddlRol.SelectedValue)
                    ? (int?)null
                    : int.Parse(ddlRol.SelectedValue);

                bool? estado = ddlEstado.SelectedValue == "1"; // Suponiendo que "1" es activo

                string email = txtEmail.Text;
                string contrasena = txtContrasena.Text;

                using (var db = new Proyecto_PrograVEntities1())
                {
                    try
                    {
                        // Parámetro de salida
                        ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                        // Llamada al procedimiento almacenado con los parámetros correctos
                        db.sp_guardar_usuario(
                            rol,                   // p_rol_id
                            null,                  // p_persona_id (null si es nuevo)
                            documentoIdentidad,    // p_documento_identidad_id
                            email,                 // p_email
                            contrasena,            // p_contrasena
                            estado,                // p_estado
                            identificacion,        // p_identificacion
                            nombre,                // p_nombre
                            apellido1,             // p_apellido1
                            apellido2,             // p_apellido2
                            fechaNacimiento,       // p_fecha_nacimiento
                            p_respuesta            // p_respuesta (salida)
                        );

                        // Verificar la respuesta
                        int resultado = (int)p_respuesta.Value;
                        if (resultado > 0)
                        {
                            lblResultado.ForeColor = System.Drawing.Color.Green;
                            lblResultado.Text = "Usuario guardado correctamente.";

                            // Redirigir a la página ResultadoAgregar.aspx
                            Response.Redirect("/PAGES/Usuario/ResultadoAgregarUsuario.aspx");
                        }
                        else
                        {
                            lblResultado.ForeColor = System.Drawing.Color.Red;
                            lblResultado.Text = "No se pudo guardar el usuario.";
                        }
                    }
                    catch (Exception oEx)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "Error al guardar el usuario: " + oEx.Message;
                        entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());
                    }
                }
            }
        }

    }
}
