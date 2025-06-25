using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Rol
{
    public partial class ModificarRol : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        private int _rolId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out _rolId))
                {
                    hfRolId.Value = _rolId.ToString();
                    CargarRol(_rolId);
                }
                else
                {
                    MostrarError("ID de rol no válido");
                    btnActualizar.Enabled = false;
                }
            }
        }

        //metodo que mapea los datos del rol a modificar
        private void CargarRol(int rolId)
        {
            try
            {
                var rol = entities.rol.Find(rolId);
                if (rol != null)
                {
                    txtNombre.Text = rol.nombre;
                }
                else
                {
                    MostrarError("Rol no encontrado");
                    btnActualizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar rol: " + ex.Message);
                RegistrarError(ex);
                btnActualizar.Enabled = false;
            }
        }

        //evento click que actualiza los datos del rol
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && int.TryParse(hfRolId.Value, out _rolId))
            {
                try
                {
                    string nombre = txtNombre.Text.Trim();

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado
                    entities.sp_actualizar_rol(
                        p_rol_id: _rolId,
                        p_nombre: nombre,
                        p_respuesta: p_respuesta
                    );

                    // Verificar la respuesta
                    if ((int)p_respuesta.Value > 0)
                    {
                        MostrarExito("Rol actualizado correctamente");
                        Response.Redirect("/PAGES/Rol/ResultadoModificarRol.aspx");
                    }
                    else
                    {
                        MostrarError("No se pudo actualizar el rol. Verifique que no exista otro rol con el mismo nombre.");
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("Error al actualizar rol: " + ex.Message);
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