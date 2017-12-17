using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Notificaciones : System.Web.UI.Page
    {
        N_SolicitudSalidas nSolicitudSalidas;
        E_Profesor profesor;
        string rolProfesor;
        string cargoProfesor;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            profesor = (E_Profesor)Session["Profesor"];
            rolProfesor = (string)Session["Rol"];
            cargoProfesor = (string)Session["Cargo"];
            if (profesor == null)
            {
                Server.Transfer("~/Default.aspx", true);
            }
            else
            {
                
                lblTituloTabValidador.Text = cargoProfesor;
                if (!IsPostBack)
                {
                    //---------------------
                    if (rolProfesor != Rol.Administrador && rolProfesor != Rol.Academico)
                    {
                        tabValidador.Style.Add("display", "none");

                    }
                    else
                    {
                        CargarTablaSolicitudesValidador();
                    }
                    //-----------------
                    CargarTablaSolicitudesPendientesDocente();
                    Actualizar_Contador();


                    CargarDropDownLists();
                }
            }
        }
        //-----------------
        private void CargarTablaSolicitudesValidador()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            List<E_SolicitudSalidasJoin> datosListaSolicitudesValidador;
            //------------------------------------------------------
            datosListaSolicitudesValidador = nSolicitudSalidas.BuscaSolicitudesPendientesValidador(cargoProfesor);
            //--------------------------------------------
            if (datosListaSolicitudesValidador.Count > 0)
            {

                gvSolicitudesPendientesAdmin.DataSource = datosListaSolicitudesValidador;
                gvSolicitudesPendientesAdmin.DataBind();
                //-------------------------
            }
            else
            {
                gvSolicitudesPendientesAdmin.DataSource = null;
                gvSolicitudesPendientesAdmin.DataBind();
                msj.Text = MsjNotificacion.Msj_Sin_Sol_Pendientes;
            }

            contadorNotificacionesValidador.Text = Convert.ToString(datosListaSolicitudesValidador.Count);
            Actualizar_Contador();
        }
        //-----------------
        private void CargarTablaSolicitudesPendientesDocente()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            List<E_SolicitudSalidasJoin> datosListaSolicitudesPendientesDocente = nSolicitudSalidas.BuscaSolicitudPendienteProfesor(profesor.IdProfesor);
            //------------------------------------------------------
            
            if (datosListaSolicitudesPendientesDocente.Count > 0)
            {

                gvSolicitudesPendientesDocente.DataSource = datosListaSolicitudesPendientesDocente;
                gvSolicitudesPendientesDocente.DataBind();
                //-------------------------
            }
            else
            {
                gvSolicitudesPendientesDocente.DataSource = null;
                gvSolicitudesPendientesDocente.DataBind();
                msjTablaDocente.Text = MsjNotificacion.Msj_Sin_Sol_Pendientes;
            }

            contadorNotificacionesDocente.Text = Convert.ToString(datosListaSolicitudesPendientesDocente.Count);
            Actualizar_Contador();
        }
        //------------------------------------------------------
        protected void gvSolicitudesPendientesAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSolicitudesPendientesAdmin.PageIndex = e.NewPageIndex;
            CargarTablaSolicitudesValidador();
        }
        //-------------------------------------------------------
        protected void gvSolicitudesPendientesDocente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSolicitudesPendientesDocente.PageIndex = e.NewPageIndex;
            CargarTablaSolicitudesPendientesDocente();
        }

        protected void gvSolicitudesPendientesAdmin_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            int index, idBuscaSolicitud;
            try
            {
                //Se obtiene la celda del gridview donde se encuentra el id de la solicitud
                index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSolicitudesPendientesAdmin.Rows[index];
                HiddenField GvTxtIdSolicitud = (HiddenField)row.FindControl("IdSolicitud");
                idBuscaSolicitud = Convert.ToInt32(GvTxtIdSolicitud.Value);
            }
            catch
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Tabla, ColorNotificacion.Rojo);
                return;
            }
            if (e.CommandName == "Consultar")
            {
                ConsultarEditarSolicitud(idBuscaSolicitud,"Consultar");
            }
            //----------------------
            if (e.CommandName == "Aceptar")
            {
                txtIdSolicitudIdSolicitudHidde.Text = Convert.ToString(idBuscaSolicitud);
                lblTituloModalConfirmar.Text = "Aceptar Solicitud";
                lblMsjContenidoModal.Text = "¿Estas seguro de Aceptar esta solicitud?";
                //-----------------------------
                lblMsjComentarioRechazado.Visible = false;
                txtComentarioRechazar.Visible = false;
                btnRechazarSolicitud.Visible = false;
                btnAceptarSolicitud.Visible = true;
                btnAprobarSolicitud.Visible = false;
                btnUploadReporte.Visible = false;
                FileUpload.Visible = false;
                //----------------------------
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConfirmar", "openModalConfirmar();", true);
                CargarTablaSolicitudesValidador();


            }
            //----------------------
            if (e.CommandName == "Rechazar")
            {
                //------------------------------
                txtIdSolicitudIdSolicitudHidde.Text = Convert.ToString(idBuscaSolicitud);
                lblTituloModalConfirmar.Text = "Rechazar Solicitud";
                lblMsjContenidoModal.Text = "¿Estas seguro de Rechazar esta solicitud?";
                lblMsjComentarioRechazado.Text = "Por favor indica la raz&oacute;n";
                //----------------------------
                lblMsjComentarioRechazado.Visible = true;
                txtComentarioRechazar.Visible = true;
                btnAceptarSolicitud.Visible = false;
                btnRechazarSolicitud.Visible = true;
                btnAprobarSolicitud.Visible = false;
                btnUploadReporte.Visible = false;
                FileUpload.Visible = false;
                //----------------------------
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalRechazar", "openModalConfirmar();", true);
                CargarTablaSolicitudesValidador();
            }
            //----------------------
            if (e.CommandName == "Aprobar")
            {
                txtIdSolicitudIdSolicitudHidde.Text = Convert.ToString(idBuscaSolicitud);
                lblTituloModalConfirmar.Text = "Aprobar Solicitud";
                lblMsjContenidoModal.Text = "¿Estas seguro de Aprobar esta solicitud?";
                lblMsjComentarioRechazado.Text = "";
                //--------------------
                lblMsjComentarioRechazado.Visible = false;
                txtComentarioRechazar.Visible = false;
                btnRechazarSolicitud.Visible = false;
                btnAceptarSolicitud.Visible = false;
                btnUploadReporte.Visible = false;
                FileUpload.Visible = false;
                btnAprobarSolicitud.Visible = true;
                
                //---------------
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalAprobar", "openModalConfirmar();", true);
                CargarTablaSolicitudesValidador();
            }
            //
            TABSeleccionada.Value = "validador";
        }
        //---------------------------------------------------------
        protected void gvSolicitudesPendientesDocente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index, idBuscaSolicitud;
            try
            {
                //Se obtiene la celda del gridview donde se encuentra el id de la solicitud
                index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSolicitudesPendientesDocente.Rows[index];
                HiddenField GvTxtIdSolicitud = (HiddenField)row.FindControl("IdSolicitud");
                idBuscaSolicitud = Convert.ToInt32(GvTxtIdSolicitud.Value);
            }
            catch
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Tabla, ColorNotificacion.Rojo);
                return;
            }
            if (e.CommandName == "Consultar")
            {
                ConsultarEditarSolicitud(idBuscaSolicitud,"Consultar");
            }
            //--------------------
            if (e.CommandName == "Editar")
            {
                ConsultarEditarSolicitud(idBuscaSolicitud, "Editar");
            }
            //----------------
            if (e.CommandName == "SubirReporte")
            {
                //---------------
                txtIdSolicitudIdSolicitudHidde.Text = Convert.ToString(idBuscaSolicitud);
                lblTituloModalConfirmar.Text = "Subir Reporte";
                lblMsjContenidoModal.Text = "Por favor, Selecciona el archivo";
                lblMsjComentarioRechazado.Text = "";
                //--------------------
                lblMsjComentarioRechazado.Visible = false;
                txtComentarioRechazar.Visible = false;
                btnRechazarSolicitud.Visible = false;
                btnAceptarSolicitud.Visible = false;
                btnAprobarSolicitud.Visible = false;
                btnUploadReporte.Visible = true;
                FileUpload.Visible = true;
                //--------------
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalSubir", "openModalConfirmar();", true);
            }
            //-------------
            TABSeleccionada.Value = "docente";
        }
        //--------------------------------
        protected void ConsultarEditarSolicitud(int idSol, string accion)
        {

            //-----------------------
            //Se obtiene la solicitud
            nSolicitudSalidas = new N_SolicitudSalidas();
            E_SolicitudSalidas solicitud = nSolicitudSalidas.BuscaSolicitudPorId(idSol);
            //------------------------------------
            //Se obtiene el profesor de esa solicitud
            N_Profesor nProfesor = new N_Profesor();
            E_Profesor profesorSolicitud = nProfesor.BuscaProfesorPorId(solicitud.IdProfesor);
            //----------------------------------------
            //Se rellenan todos los datos en los campos de la vista
            idSolEnModal.Value = Convert.ToString(solicitud.IdSolicitud);
            txtNombre.Text = profesorSolicitud.NombreProfesor;
            txtNoEmpleado.Text = profesorSolicitud.NumeroEmpleado;
            ddlCarrera.SelectedValue = Convert.ToString(solicitud.IdCarrera);
            ddlPeriodo.SelectedValue = Convert.ToString(solicitud.IdPeriodo);
            cBoxActividadCACEI.Checked = solicitud.CACEI;
            cBoxActividadLicenciatura.Checked = solicitud.Licenciatura;
            cBoxActividadPersonal.Checked = solicitud.Personal;
            cBoxActividadIso.Checked = solicitud.ISO;
            cBoxActividadPosgrado.Checked = solicitud.Posgrado;
            txtActividadOtros.Text = solicitud.OtraActividad;
            txtNombreEvento.Text = solicitud.NombreEvento;
            txtCostoEvento.Text = Convert.ToString(solicitud.CostoEvento);
            txtLugarEvento.Text = solicitud.LugarEvento;
            //---------------------
            string[] fechaHoraLlegadaArraysolicitud = solicitud.FechaHoraRegreso.ToString().Split(' ');
            //string tempFechaRegreso = txtFechaLLegada.Text + " " + txtHoraLlegada.Text;
            //nuevaSolicitud.FechaHoraRegreso = Convert.ToDateTime(tempFechaRegreso);
            //----------------------
            //string tempFechaSalida = txtFechaSalida.Text + " " + txtHoraSalida.Text;
            //nuevaSolicitud.FechaHoraSalida = Convert.ToDateTime(tempFechaSalida);
            //------------------------
            cBoxHospedaje.Checked = solicitud.Hospedaje;
            txtCantPersonas.Text = Convert.ToString(solicitud.Transporte);
            cBoxCombustible.Checked = solicitud.Combustible;
            cBoxViaticos.Checked = solicitud.Viatico;
            cBoxOficioComision.Checked = solicitud.OficioComision;
            txtRecursoSolicitadoOtro.Text = solicitud.OtroRecurso;
            //---------------
            if (accion == "Consultar")
            {
                //-------------------------
                //Se inhabilitan todos los campos para ue solo sirvan de consulta
                ddlCarrera.Enabled = false;
                ddlPeriodo.Enabled = false;
                cBoxActividadCACEI.Enabled = false;
                cBoxActividadLicenciatura.Enabled = false;
                cBoxActividadPersonal.Enabled = false;
                cBoxActividadIso.Enabled = false;
                cBoxActividadPosgrado.Enabled = false;
                txtActividadOtros.ReadOnly = true;
                txtNombreEvento.ReadOnly = true;
                txtCostoEvento.ReadOnly = true;
                txtLugarEvento.ReadOnly = true;
                cBoxHospedaje.Enabled = false;
                txtCantPersonas.ReadOnly = true;
                cBoxCombustible.Enabled = false;
                cBoxViaticos.Enabled = false;
                cBoxOficioComision.Enabled = false;
                txtRecursoSolicitadoOtro.ReadOnly = true;
                btnEditarSol.Visible = false;
            }
            else
            {
                if (accion == "Editar")
                {
                    //-------------------------
                    //Se habilitan todos los campos para poder editar los campos
                    ddlCarrera.Enabled = true;
                    ddlPeriodo.Enabled = true;
                    cBoxActividadCACEI.Enabled = true;
                    cBoxActividadLicenciatura.Enabled = true;
                    cBoxActividadPersonal.Enabled = true;
                    cBoxActividadIso.Enabled = true;
                    cBoxActividadPosgrado.Enabled = true;
                    txtActividadOtros.ReadOnly = false;
                    txtNombreEvento.ReadOnly = false;
                    txtCostoEvento.ReadOnly = false;
                    txtLugarEvento.ReadOnly = false;
                    cBoxHospedaje.Enabled = true;
                    txtCantPersonas.ReadOnly = false;
                    cBoxCombustible.Enabled = true;
                    cBoxViaticos.Enabled = true;
                    cBoxOficioComision.Enabled = true;
                    txtRecursoSolicitadoOtro.ReadOnly = false;
                    btnEditarSol.Visible = true;
                }
            }

            //--------------------------------
            //Se abre el modal donde se contiene la informacion
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConsultaEditar", "openModalSolicitudes();", true);
        }
        //----------------------------------------------------------

        protected void gvSolicitudesPendientesAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkButonAprobar = (e.Row.FindControl("linkButonAprobar") as LinkButton);
                if(rolProfesor != Rol.Administrador)
                {
                    linkButonAprobar.Visible = false;
                }
            }
        }
        //----------------
        protected void gvSolicitudesPendientesDocente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //-------------------DescripcionEstado
                Label lblEstadoSol = (e.Row.FindControl("lblDescripcionEstado") as Label);
                string estadoSol = lblEstadoSol.Text;
                LinkButton linkButonEditarSol = (e.Row.FindControl("linkButonEditarSol") as LinkButton);
                LinkButton linkButonSubirReporte = (e.Row.FindControl("linkButonSubirReporte") as LinkButton);
                if (estadoSol == EstadosSolicitudString.Rechazado)
                {
                    
                    linkButonEditarSol.Visible = true;
                }
                else
                {
                    linkButonEditarSol.Visible = false;
                }
                if (estadoSol == EstadosSolicitudString.Reporte)
                {

                    linkButonSubirReporte.Visible = true;
                }
                else
                {
                    linkButonSubirReporte.Visible = false;
                }
            }
        }
        //----------------
        protected void CargarDropDownLists()
        {

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
        //-----------------
        protected void Actualizar_Contador()
        {
            int intContadorNotDocente = Convert.ToInt32(contadorNotificacionesDocente.Text);
            int intContadorNotValidador = Convert.ToInt32(contadorNotificacionesValidador.Text);
            (this.Master as Usuarios).Cargar_Notificaciones(intContadorNotDocente, intContadorNotValidador);
           
        }
        //---------------
        protected void btnAprobarSolicitud_Click(object sender, EventArgs e)
        {
            
            //----------------
            //--------------
            int idSolicitud = Convert.ToInt32(txtIdSolicitudIdSolicitudHidde.Text); //se optiene el id de la solicitud a aceptar
            //---------------
            nSolicitudSalidas = new N_SolicitudSalidas();
            E_SolicitudSalidas solicitud = nSolicitudSalidas.BuscaSolicitudPorId(idSolicitud);//se obtiene la solicitud
            //E_SolicitudSalidas obtenerSol = nSolicitudSalidas.BuscaSolicitudPorId(idSolicitud);
            //--------------
            if (rolProfesor == Rol.Administrador)
            {
                solicitud.ComentarioRechazado = txtComentarioRechazar.Text;
                solicitud.IdEstadoSolicitudSalida = EstadosSolicitud.Aceptado; //estado solicitud Aceptado
                solicitud.ValUnica = true; //Se hace referencia ala aprobacion total solo de un usuario administrativo
                string res = nSolicitudSalidas.ModificaSolicitud(solicitud);
                if (res.Contains("Exito:"))
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Aprobar_Solicitud,ColorNotificacion.Verde);
                }
                else
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Aprobar_Solicitud, ColorNotificacion.Rojo);
                }
                CargarTablaSolicitudesValidador();
            }
            else
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Msj_Usuario_Sin_Permiso, ColorNotificacion.Amarillo);
            }

        }
        //---------------
        protected void btnRechazarSolicitud_Click(object sender, EventArgs e)
        {
            int idRolProfesor = profesor.IdRol;
            //----------------
            //N_Rol nRol = new N_Rol();
            //E_Rol rolProfesor = nRol.BuscaRolPorId(idRolProfesor);//se obtiene el rol del profesor
            //--------------
            int idSolicitud = Convert.ToInt32(txtIdSolicitudIdSolicitudHidde.Text); //se optiene el id de la solicitud a aceptar
            //---------------
            nSolicitudSalidas = new N_SolicitudSalidas();
            E_SolicitudSalidas solicitud = nSolicitudSalidas.BuscaSolicitudPorId(idSolicitud);//se obtiene la solicitud
            //E_SolicitudSalidas obtenerSol = nSolicitudSalidas.BuscaSolicitudPorId(idSolicitud);
            //--------------
            if (rolProfesor == Rol.Administrador || rolProfesor == Rol.Administrador)
            {
                solicitud.ComentarioRechazado = txtComentarioRechazar.Text;
                solicitud.IdEstadoSolicitudSalida = EstadosSolicitud.Rechazado; //estado solicitud rechazada
                //-------------------
                string res = nSolicitudSalidas.ModificaSolicitud(solicitud);
                if (res.Contains("Exito:"))
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Rechazar_Solicitud, ColorNotificacion.Verde);
                }
                else
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Rechazar_Solicitud, ColorNotificacion.Rojo);
                }
                CargarTablaSolicitudesValidador();
            }
            else
            {
               (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Msj_Usuario_Sin_Permiso,ColorNotificacion.Amarillo);
            }


        }
        //-----------------
        protected void btnAceptarSolicitud_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(txtIdSolicitudIdSolicitudHidde.Text); //se optiene el id de la solicitud a aceptar
            //---------------
            nSolicitudSalidas = new N_SolicitudSalidas();
            E_SolicitudSalidas solicitud = nSolicitudSalidas.BuscaSolicitudPorId(idSolicitud);//se obtiene la solicitud
            //--------------
            if (cargoProfesor == Cargo.Subdirector)
            {
                solicitud.ValSubdirector = true;
                

            }
            else
            {
                if (cargoProfesor == Cargo.Coordinador)
                {
                    solicitud.ValCoordinador = true;
                }
                else
                {
                    if (cargoProfesor == Cargo.AdministradorAcademico)
                    {

                        solicitud.ValAdministradorAcademico = true;
                    }
                    else
                    {
                        if (cargoProfesor == Cargo.Director)
                        {
                            solicitud.ValDirector = true;
                        }
                        else
                        {
                            if (cargoProfesor == Cargo.Posgrado)
                            {
                                solicitud.ValPosgrado = true;
                                solicitud.IdEstadoSolicitudSalida = EstadosSolicitud.Aceptado;
                            }
                        }
                    }
                }
            }
            string res = nSolicitudSalidas.ModificaSolicitud(solicitud);
            if (res.Contains("Exito:")){
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Aceptar_Solicitud, ColorNotificacion.Verde);
            }
            else
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Aceptar_Solicitud, ColorNotificacion.Rojo);
            }
            CargarTablaSolicitudesValidador();
        }
        //-----------------
        protected void btnEditarSol_Click(object sender, EventArgs e)
        {
            //E_SolicitudSalidas solicitudEditar = new E_SolicitudSalidas();
            nSolicitudSalidas = new N_SolicitudSalidas();
            if(idSolEnModal.Value != null)
            {
                int idSolEditar = Convert.ToInt32(idSolEnModal.Value);
                //-------------------------
                E_SolicitudSalidas solicitudEditar = nSolicitudSalidas.BuscaSolicitudPorId(idSolEditar);
                solicitudEditar.IdProfesor = profesor.IdProfesor;
                solicitudEditar.IdCarrera = Convert.ToInt32(ddlCarrera.SelectedValue);
                solicitudEditar.IdPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue); ;
                solicitudEditar.IdEstadoSolicitudSalida = EstadosSolicitud.Procceso; 
                solicitudEditar.FechaModificacion = DateTime.Now;
                solicitudEditar.CACEI = cBoxActividadCACEI.Checked;
                solicitudEditar.Licenciatura = cBoxActividadLicenciatura.Checked;
                solicitudEditar.Personal = cBoxActividadPersonal.Checked;
                solicitudEditar.ISO = cBoxActividadIso.Checked;
                solicitudEditar.Posgrado = cBoxActividadPosgrado.Checked;
                solicitudEditar.OtraActividad = txtActividadOtros.Text;
                solicitudEditar.NombreEvento = txtNombreEvento.Text;
                solicitudEditar.CostoEvento = (float)Convert.ToDecimal(txtCostoEvento.Text);
                solicitudEditar.LugarEvento = txtLugarEvento.Text;
                //---------------------
                string tempFechaRegreso = txtFechaLLegada.Text + " " + txtHoraLlegada.Text;
                solicitudEditar.FechaHoraRegreso = Convert.ToDateTime(tempFechaRegreso);
                //----------------------
                string tempFechaSalida = txtFechaSalida.Text + " " + txtHoraSalida.Text;
                solicitudEditar.FechaHoraSalida = Convert.ToDateTime(tempFechaSalida);
                solicitudEditar.Hospedaje = cBoxHospedaje.Checked;
                solicitudEditar.Transporte = Convert.ToInt32(txtCantPersonas.Text.ToString());
                solicitudEditar.Combustible = cBoxCombustible.Checked;
                solicitudEditar.Viatico = cBoxViaticos.Checked;
                solicitudEditar.OficioComision = cBoxOficioComision.Checked;
                solicitudEditar.OtroRecurso = txtRecursoSolicitadoOtro.Text;
                //---------------------------------------
                //solicitudEditar.ValSubdirector = false;
                //validarCampos();
                //----------------------------------------
                string res = nSolicitudSalidas.ModificaSolicitud(solicitudEditar);
                if (res.Contains("Exito:"))
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Modificar_Solicitud,ColorNotificacion.Verde);
                }
                else
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Modificar_Solicitud, ColorNotificacion.Rojo);
                }
                CargarTablaSolicitudesPendientesDocente();
            }
           
        }
        //----------------
        protected void btnUploadReporte_Click(object sender, EventArgs e)
        {
            bool fileOK = false;
            if (FileUpload.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload.FileName).ToLower();
                String[] allowedExtensions ={".pdf"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
                //-----
                if (fileOK)
                {
                    try
                    {
                        int idSol = Convert.ToInt32(txtIdSolicitudIdSolicitudHidde.Text);
                        nSolicitudSalidas = new N_SolicitudSalidas();
                        E_SolicitudSalidas sol = nSolicitudSalidas.BuscaSolicitudPorId(idSol);
                        //string pathRelativo = sol.Folio+"-"+ sol.FechaCreacion+"-"+FileUpload.FileName;
                        string pathCompletoArchivoNuevo = Server.MapPath(Directorio.ReportesDeSalidas) + FileUpload.FileName;
                        if (File.Exists(pathCompletoArchivoNuevo))
                        {
                            (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Msj_Nombre_Archivo_Ya_Existe, ColorNotificacion.Amarillo);
                        }
                        else
                        {
                            FileUpload.PostedFile.SaveAs(pathCompletoArchivoNuevo);
                            //(this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Al_Subir_Archivo, ColorNotificacion.Verde);
                            //-------------
                            
                            sol.IdEstadoSolicitudSalida = EstadosSolicitud.Terminado;
                            sol.UrlReporte = FileUpload.FileName;
                            string res = nSolicitudSalidas.ModificaSolicitud(sol);
                            if (res.Contains("Exito:"))
                            {
                                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Al_Subir_Archivo, ColorNotificacion.Verde);
                                
                            }
                            else
                            {
                                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Terminar_Sol, ColorNotificacion.Rojo);
                            }
                            CargarTablaSolicitudesPendientesDocente();

                        }
                        
                    }
                    catch 
                    {
                        (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_General, ColorNotificacion.Rojo);
                    }
                }
                else
                {
                    (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Msj_Extensiones_Permitidas_Archivo, ColorNotificacion.Amarillo);
                }
            }
            else
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Msj_Sin_Seleccionar_Archivo, ColorNotificacion.Amarillo);
            }

            
        }

        //-----------------



        //-----------------

    }
}