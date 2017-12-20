using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Solicitudes : System.Web.UI.Page
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
                
                //lblTituloTabValidador.Text = rolUsuario.DescripcionRol;
                if (!IsPostBack)
                {
                    //---------------------
                    if (rolProfesor != Rol.Administrador)
                    {
                        tabAdministrador.Style.Add("display", "none");

                    }
                    else
                    {
                        CargarTablaTodasSolicitudes();
                    }
                    //-----------------
                   
                    CargarTablaSolicitudes();
                    CargarDropDownLists();
                }
            }
        }
        //-------------------------------------------------------------------------------------------
        protected void CargarDropDownLists()
        {
            //-----------------------------------------
            N_Carrera nCarrera = new N_Carrera();
            DataTable datosListaCarrera = nCarrera.DT_LstCarrera();
            //-------------------Cargar ddl sobre las carreras------------------------------------
            foreach (DataRow row in datosListaCarrera.Rows)
            {
                System.Web.UI.WebControls.ListItem oItem = new System.Web.UI.WebControls.ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                ddlCarrera.Items.Add(oItem);
            }
            ddlCarrera.DataBind();
            //--------------------------------------
            N_Periodo nPeriodo = new N_Periodo();
            DataTable datosListaPeriodo = nPeriodo.DT_LstPeriodo();
            //-------------------Cargar ddl sobre las carreras------------------------------------
            foreach (DataRow row in datosListaPeriodo.Rows)
            {
                System.Web.UI.WebControls.ListItem oItem = new System.Web.UI.WebControls.ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                ddlPeriodo.Items.Add(oItem);
            }
            ddlPeriodo.DataBind();
            
        }
        //------------------------------------
        private void CargarTablaSolicitudes()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            //------------------------------------------------------
            List<E_SolicitudSalidasJoin> datosListaMisSolicitudes = nSolicitudSalidas.BuscaSolicitudPorIdProfesor(profesor.IdProfesor);
            //--------------------------------------------
            if (datosListaMisSolicitudes.Count > 0)
            {

                gvMisSolicitudes.DataSource = datosListaMisSolicitudes;
                gvMisSolicitudes.DataBind();
                msj.Text = "";
                //-------------------------
            }
            else
            {
                gvMisSolicitudes.DataSource = null;
                gvMisSolicitudes.DataBind();
                msj.Text = MsjNotificacion.Msj_Sin_Sol;
            }
        }
        //------------------------------------
        private void CargarTablaTodasSolicitudes()
        {
            nSolicitudSalidas = new N_SolicitudSalidas();
            //------------------------------------------------------
            List<E_SolicitudSalidasJoin> datosListaTodasLasSolicitudes = nSolicitudSalidas.ListSolicitudesSalidaJoin(Acciones.ConsultarTodo);
            //--------------------------------------------
            if (datosListaTodasLasSolicitudes.Count > 0)
            {

                gvTodasLasSolicitudes.DataSource = datosListaTodasLasSolicitudes;
                gvTodasLasSolicitudes.DataBind();
               // msj.Text = "";
                //-------------------------
            }
            else
            {
                gvTodasLasSolicitudes.DataSource = null;
                gvTodasLasSolicitudes.DataBind();
                //msj.Text = MsjNotificacion.Msj_Sin_Sol;
            }
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
            CargarTablaTodasSolicitudes();
        }
        //----------------------------------------------------------
        protected void gvMisSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index, idBuscaSolicitud;
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMisSolicitudes.Rows[index];
                HiddenField GvTxtIdSolicitud = (HiddenField)row.FindControl("IdSolicitud");
                idBuscaSolicitud = Convert.ToInt32(GvTxtIdSolicitud.Value);
            }
            catch
            {
                return;
            } 
            //-----------------------
           if (e.CommandName == "Consultar")
            {
                ConsultarEditarSolicitud(idBuscaSolicitud, "Consultar");
           }
            
            TABSeleccionada.Value = "docente";
        }
        //--------------------------------------------------------
        protected void gvTodasLasSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index, idBuscaSolicitud;
            try
            {
                //Se obtiene la celda del gridview donde se encuentra el id de la solicitud
                index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvTodasLasSolicitudes.Rows[index];
                HiddenField GvTxtIdSolicitud = (HiddenField)row.FindControl("IdSolicitud");
                idBuscaSolicitud = Convert.ToInt32(GvTxtIdSolicitud.Value);
            }
            catch
            {
                return;
            }
            //--------------------
            if (e.CommandName == "Consultar")
            {
                ConsultarEditarSolicitud(idBuscaSolicitud, "Consultar");
            }
            if (e.CommandName == "GenerarOficio")
            {
                nSolicitudSalidas = new N_SolicitudSalidas();
                E_SolicitudSalidasJoin solicitud = nSolicitudSalidas.BuscaSolicitudPorIdJoin(idBuscaSolicitud);
                N_Profesor nProfesor = new N_Profesor();
                E_Profesor profesorSol = nProfesor.BuscaProfesorPorId(solicitud.IdProfesor); 
                Document doc = new Document(PageSize.LETTER);
                // Indicamos donde vamos a guardar el documento
                //PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(Server.MapPath("~/Resources") + "/prueba.pdf", FileMode.Create));
                //string nombreArchivo = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
                string nombreArchivo = Server.MapPath("~/OficioComisionSolicitud/") +solicitud.Folio+solicitud.CicloPeriodo+profesorSol.NumeroEmpleado+"OficioC.pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(nombreArchivo, FileMode.Create));
                //---------------------
                doc.AddTitle("Oficio Comision");
                //------------------
                doc.Open();
                //---------------
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                Font fuenteTitulo = new Font(iTextSharp.text.Font.FontFamily.HELVETICA,20, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                Font fuenteSubtitulo = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                // Escribimos el encabezamiento en el documento
                //doc.AddHeader("NAME","CONTENIDO");
                Paragraph tituloOficio = new Paragraph("Universidad Autónoma de Baja California", fuenteTitulo);
                tituloOficio.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloOficio);
                Paragraph subtituloOficio = new Paragraph("FACULTAD DE INGENIERIA, ARQUITECTURA Y DISEÑO", fuenteSubtitulo);
                subtituloOficio.Alignment = Element.ALIGN_CENTER;
                doc.Add(subtituloOficio);
                doc.Add(Chunk.NEWLINE);

                DateTime diaActual = Convert.ToDateTime(DateTime.Now);
                Paragraph infoEmision = new Paragraph("SUBDIRECCIÓN\n"
                            + solicitud.CicloPeriodo+ " ASUNTO: Oficio Comisión\n"+
                            "Ensenada, B,C, a "+ diaActual, fuenteSubtitulo);
                infoEmision.Alignment = Element.ALIGN_RIGHT;
                doc.Add(infoEmision);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                Paragraph encabezado = new Paragraph(profesorSol.APaternoProfesor+" " + profesor.AMaternoProfesor +" "+ profesorSol.NombreProfesor+"\n"
                   + "No. De empleado: "+profesorSol.NumeroEmpleado,fuenteSubtitulo);
                encabezado.Alignment = Element.ALIGN_LEFT;
                doc.Add(encabezado);
                Paragraph encabezado2 = new Paragraph("PRESENTE",fuenteTitulo);
                encabezado2.Alignment = Element.ALIGN_LEFT;
                doc.Add(encabezado2);
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("Por medio del presente la subdirección a mi cargo comisiona a ustede el dia "+diaActual
                    +" del año en curso"));
                doc.Add(Chunk.NEWLINE);

                Paragraph motivo = new Paragraph("MOTIVO: Solicitud de Salida",fuenteSubtitulo);
                motivo.Alignment = Element.ALIGN_LEFT;
                doc.Add(motivo);
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("     Asisimismo, se le solicita entregar a este Dependencia el reporte de actividades o la constancia respectiva" +
                    "de forma impresa o electrónica"));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("En espera que reciba de conformidad, me despido de usted con un cordial saludo."));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                Paragraph atentamente = new Paragraph("ATENTAMENTE", fuenteTitulo);
                atentamente.Alignment = Element.ALIGN_CENTER;
                doc.Add(atentamente);
                Paragraph atentamente2 = new Paragraph("\"POR LA REALIZACION PLENA DEL HOMBRE\"", fuenteSubtitulo);
                atentamente2.Alignment = Element.ALIGN_CENTER;
                doc.Add(atentamente2);
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                Paragraph responable = new Paragraph(profesor.NombreProfesor + " "+profesor.APaternoProfesor +" " + profesor.AMaternoProfesor+"\n"
                    +cargoProfesor, fuenteTitulo);
                responable.Alignment = Element.ALIGN_CENTER;
                doc.Add(responable);


                

                doc.Close();
                writer.Close();
                //Server.
                //string script = string.Format("abrirPDF('{0}')", nombreArchivo);
                /*string script = string.Format("abrirPDF('{0}')", "../Resoruces/prueba.pdf");
                ScriptManager.RegisterStartupScript(Page, Page.ClientScript.GetType(), "abrirPDF", script, true);*/
                //Server.Transfer(nombreArchivo);
            }
            TABSeleccionada.Value = "administrador";

        }
        //----------------------------------------------
        protected void Enviar_Solicitud_Click(object sender, EventArgs e)
        {
            E_SolicitudSalidas nuevaSolicitud = new E_SolicitudSalidas();
            nSolicitudSalidas = new N_SolicitudSalidas();
            //--------------
            nuevaSolicitud.IdProfesor = profesor.IdProfesor;
            nuevaSolicitud.IdCarrera = Convert.ToInt32(ddlCarrera.SelectedValue);
            nuevaSolicitud.IdPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue); ;
            nuevaSolicitud.IdEstadoSolicitudSalida = EstadosSolicitud.Procceso; //EstadoProceso;
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
            string tempFechaRegreso = txtFechaRegreso.Text + " " + txtHoraRegreso.Text;
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
            string res = nSolicitudSalidas.InsertaSolicitud(nuevaSolicitud);
            if (res.Contains("Exito:"))
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Exito_Crear_Solicitud, ColorNotificacion.Verde);

            }
            else
            {
                (this.Master as Usuarios).Mostrar_Notificacion(MsjNotificacion.Error_Crear_Solicitud, ColorNotificacion.Rojo);
            }
            //------------------------------------------------
            CargarTablaSolicitudes();
        }
        //----------------------------------
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
            //----------
            //thisDate1.ToString("MMMM dd, yyyy");
            //string[] fechaHoraLlegadaArraysolicitud = solicitud.FechaHoraRegreso.ToString().Split(' ');
            DateTime fechaHoraRegreso = Convert.ToDateTime(solicitud.FechaHoraRegreso.ToString());
            txtFechaRegreso.Text = fechaHoraRegreso.ToString("yyyy-MM-dd");
            txtHoraRegreso.Text = fechaHoraRegreso.ToString("HH:ff");
            //txtFechaLLegada.Text = fechaHoraLlegadaArraysolicitud[0];
            //----------------------------------------
            DateTime fechaHoraSalida = Convert.ToDateTime(solicitud.FechaHoraSalida.ToString());
            txtFechaSalida.Text = fechaHoraSalida.ToString("yyyy-MM-dd");
            txtHoraSalida.Text = fechaHoraSalida.ToString("HH:ff");
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
                txtFechaSalida.ReadOnly = true;
                txtHoraSalida.ReadOnly = true;
                txtFechaRegreso.ReadOnly = true;
                txtHoraRegreso.ReadOnly = true;
                btnEnviarSolicitud.Visible = false;
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
                    txtFechaSalida.ReadOnly = false;
                    txtHoraSalida.ReadOnly = false;
                    txtFechaRegreso.ReadOnly = false;
                    txtHoraRegreso.ReadOnly = false;
                    btnEnviarSolicitud.Visible = false;
                }
            }

            //--------------------------------
            //Se abre el modal donde se contiene la informacion
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConsultaEditar", "openModalSolicitudes();", true);
        }
        //----------------------
        protected void NuevaSolicitudClick(object sender, EventArgs e)
        {
            //----------
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
            txtFechaSalida.ReadOnly = false;
            txtHoraSalida.ReadOnly = false;
            txtFechaRegreso.ReadOnly = false;
            txtHoraRegreso.ReadOnly = false;
            btnEnviarSolicitud.Visible = false;
            //-----------------------
            txtFechaSalida.Text = "";
            txtFechaRegreso.Text = "";
            txtHoraSalida.Text = "";
            txtHoraRegreso.Text = "";
            txtNombre.Text = "";
            txtNoEmpleado.Text = "";
            cBoxActividadCACEI.Checked = false;
            cBoxActividadLicenciatura.Checked = false;
            cBoxActividadPersonal.Checked = false;
            cBoxActividadIso.Checked = false;
            cBoxActividadPosgrado.Checked = false;
            txtActividadOtros.Text = "";
            txtNombreEvento.Text = "";
            txtCostoEvento.Text = "";
            txtLugarEvento.Text = "";
            cBoxHospedaje.Checked = false;
            txtCantPersonas.Text = "";
            cBoxCombustible.Checked = false;
            cBoxViaticos.Checked = false;
            cBoxOficioComision.Checked = false;
            txtRecursoSolicitadoOtro.Text = "";
            txtFechaSalida.Text = "";
            txtHoraSalida.Text = "";
            txtFechaRegreso.Text = "";
            txtHoraRegreso.Text = "";
            btnEnviarSolicitud.Visible = true;
            //---------------------
            txtNombre.Text = profesor.NombreProfesor;
            txtNoEmpleado.Text = profesor.NumeroEmpleado;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConsultaEditar", "openModalSolicitudes();", true);
        }

   
    }
}