using Proyecto_PrograV.DATA;
using System;
using System.Data.Entity.Core.Objects;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_PrograV.PAGES.Categoria
{
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1();
        private int _categoriaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out _categoriaId))
                {
                    hfCategoriaId.Value = _categoriaId.ToString();
                    CargarCategoria(_categoriaId);
                }
                else
                {
                    MostrarError("ID de categoría no válido");
                    btnActualizar.Enabled = false;
                }
            }
        }

        //metodo que mapea los datos de la categoria a modificar
        private void CargarCategoria(int categoriaId)
        {
            try
            {
                var categoria = entities.categoria.Find(categoriaId);
                if (categoria != null)
                {
                    txtNombre.Text = categoria.nombre;
                }
                else
                {
                    MostrarError("Categoría no encontrada");
                    btnActualizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar categoría: " + ex.Message);
                RegistrarError(ex);
                btnActualizar.Enabled = false;
            }
        }

        //evento click que actualiza los datos de la categoria a modificar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && int.TryParse(hfCategoriaId.Value, out _categoriaId))
            {
                try
                {
                    string nombre = txtNombre.Text.Trim();

                    // Parámetro de salida
                    ObjectParameter p_respuesta = new ObjectParameter("p_respuesta", typeof(int));

                    // Llamar al procedimiento almacenado
                    entities.sp_actualizar_categoria(
                        p_categoria_id: _categoriaId,
                        p_nombre: nombre,
                        p_respuesta: p_respuesta
                    );

                    // Verificar la respuesta
                    if ((int)p_respuesta.Value > 0)
                    {
                        MostrarExito("Categoría actualizada correctamente");
                        Response.Redirect("/PAGES/Categoria/ResultadoModificarCategoria.aspx");
                    }
                    else
                    {
                        MostrarError("No se pudo actualizar la categoría");
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("Error al actualizar categoría: " + ex.Message);
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