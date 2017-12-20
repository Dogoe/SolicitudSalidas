using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Inicio : System.Web.UI.Page
    {
        E_Profesor profesor;
        protected void Page_Load(object sender, EventArgs e)
        {
            profesor = (E_Profesor)Session["Profesor"];
            if (profesor == null)
            {
                Server.Transfer("~/Default.aspx", true);
            }
            else
            {
                if (!IsPostBack)
                {

                }
            }
        }
    }
}