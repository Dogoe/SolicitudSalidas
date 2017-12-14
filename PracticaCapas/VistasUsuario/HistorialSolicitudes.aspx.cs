using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class HistorialSolicitudes : System.Web.UI.Page
    {
        N_SolicitudSalidas nSolicitudSalidas;
        E_Profesor profesor;
        protected void Page_Load(object sender, EventArgs e)
        {
            profesor = (E_Profesor)Session["Profesor"];
            if (profesor == null && !IsPostBack)
            {
                Server.Transfer("~/Default.aspx", true);
            }
            else
            {
                N_Rol nRol = new N_Rol();
                E_Rol rolUsuario = nRol.BuscaRolPorId(profesor.IdRol);
                //---------------------
                if(rolUsuario.NombreRol != "Administrador"){
                    tabAdministrador.Style.Add("display", "none");
                }
                
                CargarTablaSolicitudes();
            }
        }
        //------------------------------------
        private void CargarTablaSolicitudes()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            List<E_SolicitudSalidas> datosListaTodasLasSolicitudes = nSolicitudSalidas.LstSolicitud();
            //List<E_SolicitudSalidas> datosListaTodasLasSolicitudes = nSolicitudSalidas.ListInnerJoinSolicitud();
            if (datosListaTodasLasSolicitudes.Count > 0)
            {

                gvTodasLasSolicitudes.DataSource = datosListaTodasLasSolicitudes;
                gvTodasLasSolicitudes.DataBind();
                //-------------------------
            }
            else
            {
                msj.Text = "No contiene Registros la tabla.";
            }
        }
        //------------------------------------------------------
        protected void gvTodasLasSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodasLasSolicitudes.PageIndex = e.NewPageIndex;
            CargarTablaSolicitudes();
        }

        protected void gvTodasLasSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Consultar")
            {
                //-------------
                //Se obtiene la celda del gridview donde se encuentra el id de la solicitud
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvTodasLasSolicitudes.Rows[index];
                HiddenField GvTxtIdSolicitud = (HiddenField)row.FindControl("IdSolicitud");
                int idBuscaSolicitud = Convert.ToInt32(GvTxtIdSolicitud.Value);
                //------------

               // ConsultarEditarSolicitud(idBuscaSolicitud, "Consultar");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "cargaPestaniaDocentes", "cargaPestaniaDocentes();", true);
            }
        }
    }
}