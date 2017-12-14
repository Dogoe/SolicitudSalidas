using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Solicitudes : System.Web.UI.Page
    {

        N_SolicitudSalidas nSolicitudSalidas;
        N_Rol nRol;
        E_Profesor profesor;
        E_Rol rolUsuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            profesor = (E_Profesor)Session["Profesor"];
            if (profesor == null)
            {
                Server.Transfer("~/Default.aspx", true);
            }
            else
            {
                nRol = new N_Rol();
                rolUsuario = nRol.BuscaRolPorId(profesor.IdRol);
                //lblTituloTabValidador.Text = rolUsuario.DescripcionRol;
                if (!IsPostBack)
                {
                    //---------------------
                    if (rolUsuario.NombreRol != "Administrador")
                    {
                        tabAdministrador.Style.Add("display", "none");

                    }
                    else
                    {
                        CargarTablaTodasSolicitudes();
                    }
                    //-----------------
                    //CargarTablaSolicitudesPendientesDocente();
                    //Actualizar_Contador();
                   
                    CargarTablaSolicitudes();
                    CargarDropDownLists();
                }
            }
        }
        //-------------------------------------------------------------------------------------------
        protected void CargarDropDownLists()
        {
            /*N_Categoria nCategoria = new N_Categoria();
            DataTable datosListaCategoria = nCategoria.DT_LstCategoria();
            //-------------------Carga ddl sobre las categorias-------------------------------------
            foreach (DataRow row in datosListaCategoria.Rows)
            {
                ListItem oItem = new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                ddlCategoria.Items.Add(oItem);
            }
            ddlCategoria.DataBind();*/
            //-----------------------------------------
            N_Carrera nCarrera = new N_Carrera();
            DataTable datosListaCarrera = nCarrera.DT_LstCarrera();
            //-------------------Cargar ddl sobre las carreras------------------------------------
            foreach (DataRow row in datosListaCarrera.Rows)
            {
                ListItem oItem = new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                ddlCarrera.Items.Add(oItem);
            }
            ddlCarrera.DataBind();
            //--------------------------------------
            N_Periodo nPeriodo = new N_Periodo();
            DataTable datosListaPeriodo = nPeriodo.DT_LstPeriodo();
            //-------------------Cargar ddl sobre las carreras------------------------------------
            foreach (DataRow row in datosListaPeriodo.Rows)
            {
                ListItem oItem = new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                ddlPeriodo.Items.Add(oItem);
            }
            ddlPeriodo.DataBind();
            
        }
        //------------------------------------
        private void CargarTablaSolicitudes()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            //nRol = new N_Rol();
            //E_Rol rolProfesor = nRol.BuscaRolPorId(profesor.IdProfesor);
            //List<E_SolicitudSalidas> datosListaMisSolicitudes;
            //------------------------------------------------------
            List<E_SolicitudSalidas> datosListaMisSolicitudes = nSolicitudSalidas.BuscaSolicitudPorIdProfesor(profesor.IdProfesor);
            //--------------------------------------------
            if (datosListaMisSolicitudes.Count > 0)
            {

                gvMisSolicitudes.DataSource = datosListaMisSolicitudes;
                gvMisSolicitudes.DataBind();
                //-------------------------
            }
            else
            {
                gvMisSolicitudes.DataSource = null;
                gvMisSolicitudes.DataBind();
                msj.Text = "No contiene Registros la tabla.";
            }
            
            /*nSolicitudSalidas = new N_SolicitudSalidas();
            List<E_SolicitudSalidas> datosListaMisSolicitudes = nSolicitudSalidas.BuscaSolicitudPorIdProfesor(profesor.IdProfesor);
            if (datosListaMisSolicitudes.Count> 0)
            {

                gvMisSolicitudes.DataSource = datosListaMisSolicitudes;
                gvMisSolicitudes.DataBind();
                //-------------------------
            }
            else
            {
                msj.Text = "No contiene Registros la tabla.";
            }*/
        }
        //------------------------------------
        private void CargarTablaTodasSolicitudes()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            //nRol = new N_Rol();
            //E_Rol rolProfesor = nRol.BuscaRolPorId(profesor.IdProfesor);
            //List<E_SolicitudSalidas> datosListaMisSolicitudes;
            //------------------------------------------------------
            List<E_SolicitudSalidas> datosListaTodasLasSolicitudes = nSolicitudSalidas.LstSolicitud();
            //--------------------------------------------
            if (datosListaTodasLasSolicitudes.Count > 0)
            {

                gvTodasLasSolicitudes.DataSource = datosListaTodasLasSolicitudes;
                gvTodasLasSolicitudes.DataBind();
                //-------------------------
            }
            else
            {
                gvTodasLasSolicitudes.DataSource = null;
                gvTodasLasSolicitudes.DataBind();
                msj.Text = "No contiene Registros la tabla.";
            }
            /*nSolicitudSalidas = new N_SolicitudSalidas();
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
            }*/
        }
        //------------------------------------------------------
        protected void gvMisSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMisSolicitudes.PageIndex = e.NewPageIndex;
            CargarTablaSolicitudes();
        }
        //------------------------------------------------------
        protected void gvTodasLasSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodasLasSolicitudes.PageIndex = e.NewPageIndex;
            CargarTablaSolicitudes();
        }
        //----------------------------------------------------------
        protected void gvMisSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TABSeleccionada.Value = "docente";
        }
        //--------------------------------------------------------
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
                TABSeleccionada.Value = "administrador";
                // ConsultarEditarSolicitud(idBuscaSolicitud, "Consultar");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "cargaPestaniaDocentes", "cargaPestaniaDocentes();", true);
            }
        }
        //----------------------------------------------
        protected void Enviar_Solicitud_Click(object sender, EventArgs e)
        {
            E_SolicitudSalidas nuevaSolicitud = new E_SolicitudSalidas();
            nuevaSolicitud.IdProfesor = profesor.IdProfesor;
            nuevaSolicitud.IdCarrera = Convert.ToInt32(ddlCarrera.SelectedValue);
            nuevaSolicitud.IdPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue); ;
            nuevaSolicitud.IdEstadoSolicitudSalida = 1; //EstadoProceso;
            nuevaSolicitud.Folio = "F" + ddlPeriodo.DataTextField + nuevaSolicitud.IdSolicitud; //Falta establecer bien el criterio del folio; //Falta generar folio
            nuevaSolicitud.FechaCreacion = DateTime.Now;
            nuevaSolicitud.FechaModificacion = DateTime.Now;
            nuevaSolicitud.UrlReporte = ""; //Falta implementar
            nuevaSolicitud.ComentarioRechazado = ""; //Se ueda vacio al crearse
            nuevaSolicitud.CACEI = cBoxActividadCACEI.Checked;
            nuevaSolicitud.Licenciatura = cBoxActividadLicenciatura.Checked;
            nuevaSolicitud.Personal = cBoxActividadPersonal.Checked;
            nuevaSolicitud.ISO = cBoxActividadIso.Checked;
            nuevaSolicitud.Posgrado = cBoxActividadPosgrado.Checked;
            nuevaSolicitud.OtraActividad = txtActividadOtros.Text;
            nuevaSolicitud.NombreEvento = txtNombreEvento.Text;
            nuevaSolicitud.CostoEvento = (float)Convert.ToDecimal(txtCostoEvento.Text);
            nuevaSolicitud.LugarEvento = txtLugarEvento.Text;
            //---------------------
            string tempFechaRegreso = txtFechaLLegada.Text + " " + txtHoraLlegada.Text;
            nuevaSolicitud.FechaHoraRegreso = Convert.ToDateTime(tempFechaRegreso);
            //----------------------
            string tempFechaSalida = txtFechaSalida.Text + " " + txtHoraSalida.Text;
            nuevaSolicitud.FechaHoraSalida = Convert.ToDateTime(tempFechaSalida);
            nuevaSolicitud.Hospedaje = cBoxHospedaje.Checked;
            nuevaSolicitud.Transporte = Convert.ToInt32(txtCantPersonas.Text.ToString());
            nuevaSolicitud.Combustible = cBoxCombustible.Checked;
            nuevaSolicitud.Viatico = cBoxViaticos.Checked;
            nuevaSolicitud.OficioComision = cBoxOficioComision.Checked;
            nuevaSolicitud.OtroRecurso = txtRecursoSolicitadoOtro.Text;
            nuevaSolicitud.ValCoordinador =false;
            nuevaSolicitud.ValSubdirector = false;
            nuevaSolicitud.ValAdministradorAcademico = false;
            nuevaSolicitud.ValDirector = false;
            nuevaSolicitud.ValPosgrado = false;
            nuevaSolicitud.ValUnica = false;
            //---------------------------------------
            //validarCampos();
            //----------------------------------------
            nSolicitudSalidas.InsertaSolicitud(nuevaSolicitud);
            //------------------------------------------------
            CargarTablaSolicitudes();
            /*N_Solicitud nuevaSolicitud = new N_Solicitud();
            nuevaSolicitud.Crear_Solicitud(-1, folio, nombre_solicitante, numero_empleado, id_categoria, id_carrera,
                evento, recurso, actividad, validacion, id_estado, fecha_creacion, fecha_modificacion, URL_reporte,
                correo_solicitante, comentario_rechazado, leido);
            CargarTablaSolicitudes();*/
        }

       
        //----------------------------------

    }
}