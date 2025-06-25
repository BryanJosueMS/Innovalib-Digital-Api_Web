using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Proyecto_PrograV.DATA;

namespace Proyecto_PrograV.PAGES.Prestamo
{
    public partial class AgregarPrestamo : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarLibros();
            }
        }

        //metodo que carga los usuarios disponibles
        private void CargarUsuarios()
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                var usuarios = db.Database.SqlQuery<Usuario>("EXEC sp_listar_usuario").ToList();
                ddlUsuario.DataSource = usuarios;
                ddlUsuario.DataTextField = "nombre_completo"; // Mostrar el nombre completo
                ddlUsuario.DataValueField = "usuario_id";
                ddlUsuario.DataBind();
                ddlUsuario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione un usuario", ""));
            }
        }

        //metodo que carga los libros disponibles
        private void CargarLibros()
        {
            using (var db = new Proyecto_PrograVEntities1())
            {
                var libros = db.Database.SqlQuery<Libro>("EXEC sp_listar_libro").ToList();
                rptLibros.DataSource = libros;
                rptLibros.DataBind();
            }
        }

        //evento click que guarda el registro de prestamo
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaPrestamo = DateTime.Parse(txtFechaPrestamo.Text);
                DateTime fechaDevolucion = DateTime.Parse(txtFechaDevolucion.Text);
                string detalle = txtDetalle.Text;
                int usuarioId = int.Parse(ddlUsuario.SelectedValue);
                string estado = ddlEstado.SelectedValue;

                var librosSeleccionados = new List<string>();
                foreach (RepeaterItem item in rptLibros.Items)
                {
                    CheckBox chkLibro = (CheckBox)item.FindControl("chkLibro");
                    HiddenField hdnLibroId = (HiddenField)item.FindControl("hdnLibroId");

                    if (chkLibro != null && hdnLibroId != null && chkLibro.Checked)
                    {
                        librosSeleccionados.Add(hdnLibroId.Value); // Usamos el HiddenField para obtener el libro_id
                    }
                }

                string librosSeleccionadosStr = string.Join(",", librosSeleccionados);

                using (var db = new Proyecto_PrograVEntities1())
                {
                    var respuesta = new System.Data.Entity.Core.Objects.ObjectParameter("p_respuesta", typeof(int));
                    db.sp_guardar_prestamo(fechaPrestamo, fechaDevolucion, detalle, usuarioId, estado, librosSeleccionadosStr, respuesta);

                    if ((int)respuesta.Value == 1)
                    {
                        lblResultado.Text = "Préstamo guardado correctamente.";
                        // Redirigir a la página ResultadoAgregar.aspx
                        Response.Redirect("/PAGES/Prestamo/ResultadoAgregarPrestamo.aspx");
                    }
                    else
                    {
                        lblResultado.Text = "Error al guardar el préstamo.";
                    }
                }
            }
            catch (Exception oEx)
            {
                entities.RegistrarBitacoraErrores(oEx.Message, DateTime.Now, Session["Usuario"].ToString());
            }
        }

        // Clases para mapear los resultados de los procedimientos almacenados
        public class Usuario
        {
            public int usuario_id { get; set; }
            public string nombre { get; set; }
            public string apellido1 { get; set; }
            public string apellido2 { get; set; }
            public string nombre_completo => $"{nombre} {apellido1} {apellido2}"; // Propiedad calculada
        }

        public class Libro
        {
            public int libro_id { get; set; }
            public string titulo { get; set; }
        }
    }
}