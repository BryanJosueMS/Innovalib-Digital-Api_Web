using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Prestamo
{
    public partial class ModificarPrestamo : Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarLibros();

                if (Request.QueryString["id"] != null)
                {
                    int prestamoId;
                    if (int.TryParse(Request.QueryString["id"], out prestamoId))
                    {
                        CargarPrestamo(prestamoId);
                    }
                    else
                    {
                        lblResultado.Text = "ID de préstamo no válido.";
                    }
                }
            }
        }

        //metodo que mapea los datos del prestamo a modificar
        private void CargarPrestamo(int prestamoId)
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                try
                {
                    var prestamo = db.prestamo.Find(prestamoId);

                    if (prestamo != null)
                    {
                        txtFechaPrestamo.Text = prestamo.fecha_prestamo.ToString("yyyy-MM-dd");
                        txtFechaDevolucion.Text = prestamo.fecha_devolucion.ToString("yyyy-MM-dd");
                        txtDetalle.Text = prestamo.detalle;
                        ddlUsuario.SelectedValue = prestamo.usuario_id.ToString();
                        ddlEstado.SelectedValue = prestamo.estado;

                        // Cargar los libros asociados al préstamo
                        var librosPrestamo = db.prestamo_libro.Where(pl => pl.prestamo_id == prestamoId).ToList();
                        foreach (RepeaterItem item in rptLibros.Items)
                        {
                            CheckBox chkLibro = (CheckBox)item.FindControl("chkLibro");
                            HiddenField hdnLibroId = (HiddenField)item.FindControl("hdnLibroId");

                            if (librosPrestamo.Any(lp => lp.libro_id.ToString() == hdnLibroId.Value))
                            {
                                chkLibro.Checked = true;
                            }
                        }
                    }
                    else
                    {
                        lblResultado.Text = "No se encontró el préstamo.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.Text = "Error al cargar el préstamo: " + ex.Message;
                }
            }
        }

        //metodo que carga los usuarios disponibles
        private void CargarUsuarios(int? prestamoId = null)
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                try
                {
                    var usuarios = db.usuario
                        .Join(db.persona,
                            u => u.persona_id, 
                            p => p.persona_id, 
                            (u, p) => new
                            {
                                u.usuario_id,
                                NombreCompleto = p.nombre + " " + p.apellido1 + " " + p.apellido2
                            })
                        .ToList();

                    ddlUsuario.Items.Clear();
                    ddlUsuario.Items.Add(new System.Web.UI.WebControls.ListItem("Seleccione el usuario", ""));

                    int? usuarioSeleccionado = null;

                    if (prestamoId.HasValue)
                    {
                        var prestamo = db.prestamo.FirstOrDefault(p => p.prestamo_id == prestamoId.Value);
                        if (prestamo != null)
                        {
                            usuarioSeleccionado = prestamo.usuario_id;
                        }
                    }

                    foreach (var usuario in usuarios)
                    {
                        var listItem = new System.Web.UI.WebControls.ListItem(usuario.NombreCompleto, usuario.usuario_id.ToString());

                        if (usuarioSeleccionado.HasValue && usuario.usuario_id == usuarioSeleccionado.Value)
                        {
                            listItem.Selected = true;
                        }

                        ddlUsuario.Items.Add(listItem);
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.Text = "Error al cargar los usuarios: " + ex.Message;
                }
            }
        }

        //metodo que carga los libros disponibles
        private void CargarLibros()
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                var libros = db.libro.ToList();
                rptLibros.DataSource = libros;
                rptLibros.DataBind();
            }
        }

        //evento click que actualiza el prestamo
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaPrestamo.Text) || string.IsNullOrEmpty(txtFechaDevolucion.Text) ||
                string.IsNullOrEmpty(txtDetalle.Text) || ddlUsuario.SelectedValue == "" ||
                ddlEstado.SelectedValue == "")
            {
                lblResultado.Text = "Todos los campos son obligatorios.";
                return;
            }

            int prestamoId = int.Parse(Request.QueryString["id"]);
            DateTime fechaPrestamo;
            DateTime fechaDevolucion;

            if (!DateTime.TryParse(txtFechaPrestamo.Text, out fechaPrestamo) || !DateTime.TryParse(txtFechaDevolucion.Text, out fechaDevolucion))
            {
                lblResultado.Text = "Formato de fecha inválido.";
                return;
            }

            string detalle = txtDetalle.Text;
            int usuarioId = int.Parse(ddlUsuario.SelectedValue);
            string estado = ddlEstado.SelectedValue;

            // Obtener los libros seleccionados
            string librosSeleccionados = "";
            foreach (RepeaterItem item in rptLibros.Items)
            {
                CheckBox chkLibro = (CheckBox)item.FindControl("chkLibro");
                HiddenField hdnLibroId = (HiddenField)item.FindControl("hdnLibroId");

                if (chkLibro.Checked)
                {
                    librosSeleccionados += hdnLibroId.Value + ",";
                }
            }

            if (!string.IsNullOrEmpty(librosSeleccionados))
            {
                librosSeleccionados = librosSeleccionados.TrimEnd(',');
            }

            try
            {
                using (var db = new Proyecto_PrograVEntities1())
                {
                    ObjectParameter respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    db.sp_actualizar_prestamo(prestamoId, fechaPrestamo, fechaDevolucion, detalle, usuarioId, estado, librosSeleccionados, respuesta);

                    if ((int)respuesta.Value == 1)
                    {
                        lblResultado.Text = "Préstamo actualizado correctamente.";
                        // Redirigir a la página de resultado o a la lista de préstamos
                        Response.Redirect("/PAGES/Prestamo/ResultadoModificarPrestamo.aspx");
                    }
                    else
                    {
                        lblResultado.Text = "Error al actualizar el préstamo.";
                    }
                }
            }
            catch (Exception oEx)
            {
                entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());
                lblResultado.Text = "Error al actualizar el préstamo: " + oEx.Message;
            }
        }
    }
}