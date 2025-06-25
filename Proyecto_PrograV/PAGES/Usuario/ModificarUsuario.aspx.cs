using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;

namespace Proyecto_PrograV.PAGES.Usuario
{
    public partial class ActualizarUsuario : Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoDocumento();
                CargarEstado();
                CargarRol();

                if (Request.QueryString["id"] != null)
                {
                    int usuarioId;
                    if (int.TryParse(Request.QueryString["id"], out usuarioId))
                    {
                        CargarUsuario(usuarioId);
                    }
                    else
                    {
                        lblResultado.Text = "ID de usuario no válido.";
                    }
                }
            }
        }

        //metodo que mapea los datos del usuario
        private void CargarUsuario(int usuarioId)
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                try
                {
                    var usuario = db.sp_consultar_usuario(usuarioId).FirstOrDefault();

                    if (usuario != null)
                    {
                        txtIdentificacion.Text = usuario.identificacion;
                        txtNombre.Text = usuario.nombre;
                        txtApellido1.Text = usuario.apellido1;
                        txtApellido2.Text = usuario.apellido2;
                        txtFechaNacimiento.Text = usuario.fecha_nacimiento.ToString("yyyy-MM-dd");
                        ddlDocumentoIdentidad.SelectedValue = usuario.documento_identidad_id.ToString();
                        ddlRol.SelectedValue = usuario.rol_id.ToString();
                        txtEmail.Text = usuario.email;

                        // Cargar la contraseña desde la base de datos
                        txtContrasena.Attributes["value"] = usuario.contrasena; // Esto asegura que la contraseña se cargue en el campo de texto
                        ddlEstado.SelectedValue = usuario.estado.ToString();
                    }
                    else
                    {
                        lblResultado.Text = "No se encontró el usuario.";
                    }
                }
                catch (Exception oEx)
                {
                    lblResultado.Text = "Error al cargar el usuario: " + oEx.Message;
                    entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());
                }
            }
        }

        //evento click que actualiza los registros del usuario
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentificacion.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellido1.Text) || string.IsNullOrEmpty(txtApellido2.Text) ||
                string.IsNullOrEmpty(txtFechaNacimiento.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtContrasena.Text) || ddlDocumentoIdentidad.SelectedValue == "" ||
                ddlRol.SelectedValue == "" || ddlEstado.SelectedValue == "")
            {
                lblResultado.Text = "Todos los campos son obligatorios.";
                return;
            }

            int usuarioId = int.Parse(Request.QueryString["id"]);
            string identificacion = txtIdentificacion.Text;
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            DateTime fechaNacimiento;

            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                lblResultado.Text = "Formato de fecha inválido.";
                return;
            }

            int documentoIdentidadId = int.Parse(ddlDocumentoIdentidad.SelectedValue);
            int rolId = int.Parse(ddlRol.SelectedValue);
            string email = txtEmail.Text;
            string contrasena = txtContrasena.Text;
            bool estado = ddlEstado.SelectedValue == "1";

            try
            {
                using (var db = new Proyecto_PrograVEntities1())
                {
                    var usuario = db.sp_consultar_usuario(usuarioId).FirstOrDefault();
                    if (usuario == null)
                    {
                        lblResultado.Text = "Usuario no encontrado.";
                        return;
                    }

                    int personaId = usuario.persona_id;
                    ObjectParameter respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    db.sp_actualizar_usuario(usuarioId, rolId, personaId, documentoIdentidadId, email,
                                             contrasena, estado, identificacion, nombre, apellido1, apellido2,
                                             fechaNacimiento, respuesta);

                    // Redirigir a la página ResultadoModificarUsuario.aspx
                    Response.Redirect("/PAGES/Usuario/ResultadoModificarUsuario.aspx");
                }
            }
            catch (Exception oEx)
            {
                lblResultado.Text = "Error al actualizar el usuario: " + oEx.Message;
                entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());
            }
        }

        //metodo que carga los documentos disponibles
        private void CargarTipoDocumento()
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                var tiposDocumento = db.sp_listar_documento_identidad().ToList();
                ddlDocumentoIdentidad.Items.Clear();
                ddlDocumentoIdentidad.Items.Add(new System.Web.UI.WebControls.ListItem("Seleccione el tipo de documento", ""));
                foreach (var item in tiposDocumento)
                {
                    ddlDocumentoIdentidad.Items.Add(new System.Web.UI.WebControls.ListItem(item.nombre, item.documento_identidad_id.ToString()));
                }
            }
        }

        //metodo que carga los estados disponibles
        private void CargarEstado()
        {
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new System.Web.UI.WebControls.ListItem("Seleccione el estado", ""));
            ddlEstado.Items.Add(new System.Web.UI.WebControls.ListItem("Activo", "1"));
            ddlEstado.Items.Add(new System.Web.UI.WebControls.ListItem("Inactivo", "0"));
        }

        //metodo que carga los roles disponibles
        private void CargarRol()
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                var roles = db.sp_listar_rol().ToList();
                ddlRol.Items.Clear();
                ddlRol.Items.Add(new System.Web.UI.WebControls.ListItem("Seleccione el rol", ""));
                foreach (var item in roles)
                {
                    ddlRol.Items.Add(new System.Web.UI.WebControls.ListItem(item.nombre, item.rol_id.ToString()));
                }
            }
        }
    }
}