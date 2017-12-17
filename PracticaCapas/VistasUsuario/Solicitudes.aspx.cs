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
            CargarTablaSolicitudes();
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
                E_SolicitudSalidas solicitud = nSolicitudSalidas.BuscaSolicitudPorId(idBuscaSolicitud);
                Document doc = new Document(PageSize.LETTER);
                // Indicamos donde vamos a guardar el documento
                //PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(Server.MapPath("~/Resources") + "/prueba.pdf", FileMode.Create));
                //string nombreArchivo = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
                string nombreArchivo = Server.MapPath("~/Resources/") + "OficioC-"+solicitud.FechaCreacion+"-"+solicitud.Folio+".pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(nombreArchivo, FileMode.Create));

               
                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle("Oficio Comision");
                //doc.AddCreator("Roberto Torres");

                // Abrimos el archivo
                doc.Open();
                //---------------
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Escribimos el encabezamiento en el documento
                doc.Add(new Paragraph("Oficio"));
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("Por el siguiente medio me permito solicitar"));
                // Creamos una tabla que contendrá el nombre, apellido y país
                // de nuestros visitante.
                /*PdfPTable tblPrueba = new PdfPTable(3);
                tblPrueba.WidthPercentage = 100;

                // Configuramos el título de las columnas de la tabla
                PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
                clNombre.BorderWidth = 0;
                clNombre.BorderWidthBottom = 0.75f;

                PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
                clApellido.BorderWidth = 0;
                clApellido.BorderWidthBottom = 0.75f;

                PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
                clPais.BorderWidth = 0;
                clPais.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clApellido);
                tblPrueba.AddCell(clPais);

                // Llenamos la tabla con información
                clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
                clNombre.BorderWidth = 0;

                clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
                clApellido.BorderWidth = 0;

                clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
                clPais.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clNombre);
                tblPrueba.AddCell(clApellido);
                tblPrueba.AddCell(clPais);
                //-------------
                doc.Add(tblPrueba);*/

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
                //btnEditarSol.Visible = false;
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
                    //btnEditarSol.Visible = true;
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
            //btnEditarSol.Visible = true;
            btnEnviarSolicitud.Visible = false;
            //-----------------------
            //ddlCarrera.SelectedValue = 0;
            //ddlPeriodo.;
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
            //btnEditarSol.Visible = false;
            btnEnviarSolicitud.Visible = true;
            //---------------------
            txtNombre.Text = profesor.NombreProfesor;
            txtNoEmpleado.Text = profesor.NumeroEmpleado;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConsultaEditar", "openModalSolicitudes();", true);
        }

   
    }
}