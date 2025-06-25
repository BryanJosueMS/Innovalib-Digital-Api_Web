using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Libro
{
    public partial class AgregarLibro : Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarAutores();
                CargarEstado();
            }
        }

        //metodo que mapea los datos de las categorias registradas
        private void CargarCategorias()
        {
            try
            {
                var categorias = entities.sp_listar_categoria().ToList();

                ddlCategoria.Items.Clear();
                ddlCategoria.Items.Add(new ListItem("Seleccione la categoría", ""));

                foreach (var item in categorias)
                {
                    ddlCategoria.Items.Add(new ListItem(item.nombre, item.categoria_id.ToString()));
                }
            }
            catch (Exception ex)
            {
                lblResultado.ForeColor = System.Drawing.Color.Red;
                lblResultado.Text = "Error al cargar categorías: " + ex.Message;
                RegistrarError(ex);
            }
        }

        //metodo que mapea los datos de los autores registrados
        private void CargarAutores()
        {
            try
            {
                var autores = entities.sp_listar_autor().ToList();

                ddlAutor.Items.Clear();
                ddlAutor.Items.Add(new ListItem("Seleccione el autor", ""));

                foreach (var item in autores)
                {
                    string nombreCompleto = $"{item.nombre} {item.apellido1} {item.apellido2}";
                    ddlAutor.Items.Add(new ListItem(nombreCompleto, item.autor_id.ToString()));
                }
            }
            catch (Exception ex)
            {
                lblResultado.ForeColor = System.Drawing.Color.Red;
                lblResultado.Text = "Error al cargar autores: " + ex.Message;
                RegistrarError(ex);
            }
        }

        //metodo que mapea los datos de los estados disponibles
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

        private void RegistrarError(Exception ex)
        {
            if (Session["Usuario"] != null)
            {
                entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"].ToString());
            }
        }

        //evento click que guadra los datos del libro a registrar
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Validar selecciones
                    if (string.IsNullOrEmpty(ddlCategoria.SelectedValue))
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "Debe seleccionar una categoría.";
                        return;
                    }

                    if (string.IsNullOrEmpty(ddlAutor.SelectedValue))
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "Debe seleccionar un autor.";
                        return;
                    }

                    if (string.IsNullOrEmpty(ddlEstado.SelectedValue))
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "Debe seleccionar un estado.";
                        return;
                    }

                    // Obtener valores
                    string titulo = txtTitulo.Text;
                    DateTime fechaPublicacion = DateTime.Parse(txtFechaPublicacion.Text);
                    int categoriaId = int.Parse(ddlCategoria.SelectedValue);
                    int autorId = int.Parse(ddlAutor.SelectedValue);
                    int unidadesDisponibles = int.Parse(txtUnidadesDisponibles.Text);
                    string estado = ddlEstado.SelectedValue;
                    string descripcion = txtDescripcion.Text;

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado
                    entities.sp_guardar_libro(
                        p_titulo: titulo,
                        p_fecha_publicacion: fechaPublicacion,
                        p_categoria_id: categoriaId,
                        p_autor_id: autorId,
                        p_unidades_disponibles: unidadesDisponibles,
                        p_estado: estado,
                        p_descripcion: descripcion,
                        p_respuesta: p_respuesta
                    );

                    // Verificar respuesta
                    int resultado = (int)p_respuesta.Value;
                    if (resultado > 0)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Green;
                        lblResultado.Text = "Libro guardado correctamente.";
                        Response.Redirect("/PAGES/Libro/ResultadoAgregarLibro.aspx");
                    }
                    else
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text = "No se pudo guardar el libro.";
                    }
                }
                catch (Exception ex)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                    lblResultado.Text = "Error al guardar el libro: " + ex.Message;
                    RegistrarError(ex);
                }
            }
        }
    }
}