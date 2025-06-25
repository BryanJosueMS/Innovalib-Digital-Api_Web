using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.Entity;
using Proyecto_PrograV.DATA;

namespace Proyecto_PrograV.PAGES.Login
{
    public partial class Login : System.Web.UI.Page
    {
        Proyecto_PrograVEntities1 entities = new Proyecto_PrograVEntities1 ();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //evento click que valida el login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    lblMessage.Text = "Por favor, complete todos los campos.";
                    lblMessage.Visible = true;
                    return;
                }

                var usuario = entities.Database.SqlQuery<UsuarioResultado>("EXEC SP_ValidarUsuario @Email, @Contrasena",
                new SqlParameter("@Email", email),
                new SqlParameter("@Contrasena", password)).FirstOrDefault();


                if (usuario != null)
                {
                    Session["Usuario"] = usuario.email;
                    Session["Rol"] = usuario.Rol;
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    lblMessage.Text = "Acceso denegado, favor verifique sus credenciales e intente de nuevo.";
                    lblMessage.Visible = true;
                }

            }
            catch (Exception )
            {
            }
        }

        public class UsuarioResultado
        {
            public int usuario_id { get; set; }
            public string email { get; set; }
            public string Rol { get; set; }
        }


    }
}