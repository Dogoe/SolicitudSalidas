using System;
using Entidades;
using Negocios;
using System.Web;

namespace PracticaCapas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        //--------------------------------------------
        protected void btnTryLogin_click(object sender, EventArgs e)
        {
            N_Profesor nProfesor = new N_Profesor();
            //----------------------
            E_Profesor profesor = nProfesor.BuscaProfesorPorCorreo(EmailLogin.Text);
            if (profesor == null)
            {
                msj.Text = "El correo no pertenece a ningun profesor";

            }
            else
            {
                N_Rol nRol = new N_Rol();
                E_Rol rolUsuario = new E_Rol();
                rolUsuario = nRol.BuscaRolPorId(profesor.IdRol);
                Session["Profesor"] = profesor;
                Session["Rol"] = rolUsuario.NombreRol;
                Session["Cargo"] = rolUsuario.DescripcionRol;
                Server.Transfer("~/VistasUsuario/Inicio.aspx", true);
            }

        }
    }
}