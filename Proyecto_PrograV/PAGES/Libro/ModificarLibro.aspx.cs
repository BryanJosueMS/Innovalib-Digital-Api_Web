using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Libro
{
    public partial class ActualizarLibro : Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarAutores();
                CargarEstado();

                if (Request.QueryString["id"] != null)
                {
                    int libroId;
                    if (int.TryParse(Request.QueryString["id"], out libroId))
                    {
                        CargarLibro(libroId);
                    }
                    else
                    {
                        lblResultado.Text = "ID de libro no válido.";
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        //metodo que mapea los datos del libro a modificar
        private void CargarLibro(int libroId)
        {
            try
            {
                var libro = entities.sp_consultar_libro(libroId).FirstOrDefault();

                if (libro != null)
                {
                    txtTitulo.Text = libro.titulo;
                    txtFechaPublicacion.Text = libro.fecha_publicacion.ToString("yyyy-MM-dd");
                    ddlCategoria.SelectedValue = libro.categoria_id.ToString();
                    ddlAutor.SelectedValue = libro.autor_id.ToString();
                    txtUnidadesDisponibles.Text = libro.unidades_disponibles.ToString();
                    ddlEstado.SelectedValue = libro.estado;
                    txtDescripcion.Text = libro.descripcion;
                }
                else
                {
                    lblResultado.Text = "No se encontró el libro.";
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al cargar el libro: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Red;
                RegistrarError(ex);
            }
        }

        //metodo que carga las categorias disponibles
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
                lblResultado.Text = "Error al cargar categorías: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Red;
                RegistrarError(ex);
            }
        }

        //metodo que carga los autores disponibles
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
                lblResultado.Text = "Error al cargar autores: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Red;
                RegistrarError(ex);
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

        private void RegistrarError(Exception ex)
        {
            if (Session["Usuario"] != null)
            {
                entities.RegistrarBitacoraErrores(ex.Message, DateTime.Now, Session["Usuario"].ToString());
            }
        }

        //evento lcick que actualiza los datos del libro a modificar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text) ||
                string.IsNullOrEmpty(txtFechaPublicacion.Text) ||
                string.IsNullOrEmpty(ddlCategoria.SelectedValue) ||
                string.IsNullOrEmpty(ddlAutor.SelectedValue) ||
                string.IsNullOrEmpty(txtUnidadesDisponibles.Text) ||
                string.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                lblResultado.Text = "Todos los campos obligatorios deben ser completados.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int libroId = int.Parse(Request.QueryString["id"]);
            string titulo = txtTitulo.Text;
            DateTime fechaPublicacion = DateTime.Parse(txtFechaPublicacion.Text);
            int categoriaId = int.Parse(ddlCategoria.SelectedValue);
            int autorId = int.Parse(ddlAutor.SelectedValue);
            int unidadesDisponibles = int.Parse(txtUnidadesDisponibles.Text);
            string estado = ddlEstado.SelectedValue;
            string descripcion = txtDescripcion.Text;

            try
            {
                ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                entities.sp_actualizar_libro(
                    p_libro_id: libroId,
                    p_titulo: titulo,
                    p_fecha_publicacion: fechaPublicacion,
                    p_categoria_id: categoriaId,
                    p_autor_id: autorId,
                    p_unidades_disponibles: unidadesDisponibles,
                    p_estado: estado,
                    p_descripcion: descripcion,
                    p_respuesta: p_respuesta
                );

                int resultado = (int)p_respuesta.Value;
                if (resultado > 0)
                {
                    Response.Redirect("/PAGES/Libro/ResultadoModificarLibro.aspx");
                }
                else
                {
                    lblResultado.Text = "No se pudo actualizar el libro.";
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al actualizar el libro: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Red;
                RegistrarError(ex);
            }
        }
    }
}