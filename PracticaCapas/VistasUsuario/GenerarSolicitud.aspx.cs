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
    public partial class GenerarSolicitud : System.Web.UI.Page
    {
        /*EUsuario_Uabc usuario;
        ERol_Usuario rolUser;*/
        protected void Page_Load(object sender, EventArgs e)
        {
            
            /*N_Usuario nUsuario = new N_Usuario();
            //-----------------------------------
            usuario = (EUsuario_Uabc)Session["Usuario"];
            rolUser = (ERol_Usuario)Session["Rol_Usuario"];*/
            //----------------------------------
            if (!IsPostBack)
            {

                //txtNombre.Text = 
                /*txtNombre.Text = usuario.Nombre;
                txtNoEmpleado.Text = Convert.ToString(usuario.NoEmpleado);
                N_Categoria nCategoria = new N_Categoria();
                DataSet datosListaCategoria = nCategoria.ListaCategoria();
                //-------------------
                foreach (DataRow row in datosListaCategoria.Tables[0].Rows)
                {
                    ListItem oItem = new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                    ddlCategoria.Items.Add(oItem);
                }
                ddlCategoria.DataBind();
                //-----------------------------------------
                N_Carrera nCarrera = new N_Carrera();
                DataSet datosListaCarrera = nCarrera.ListaCarrera();
                //-------------------
                foreach (DataRow row in datosListaCarrera.Tables[0].Rows)
                {
                    ListItem oItem = new ListItem(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                    ddlCarrera.Items.Add(oItem);
                }
                ddlCarrera.DataBind();*/
            }
        }
        //----------------------------------------------
        protected void Enviar_Solicitud_Click(object sender, EventArgs e)
        {
            /*string folio = "D";
            
            int id_categoria = Convert.ToInt32(ddlCategoria.SelectedValue);
            int id_carrera = Convert.ToInt32(ddlCarrera.SelectedValue);
            //-------------llenar evento---------------
            EEvento evento = new EEvento();
            evento.Nombre_Evento = txtNombreEvento.Text;
            evento.Costo = (float)Convert.ToDecimal(txtCostoEvento.Text); 
            evento.Lugar = txtLugarEvento.Text;

            string tempFechaRegreso = txtFechaLLegada.Text + " " +  txtHoraLlegada.Text;
            evento.Fecha_Hora_Regreso = Convert.ToDateTime(tempFechaRegreso);
            //----
            string tempFechaSalida = txtFechaSalida.Text + " "+ txtHoraSalida.Text;
            evento.Fecha_Hora_Salida = Convert.ToDateTime(tempFechaSalida);
            //-----------llenar Recurso solicitado---------------
            ERecurso_Solicitado recurso = new ERecurso_Solicitado();
            recurso.Hospedaje = cBoxHospedaje.Checked;
            recurso.Transporte = Convert.ToInt32(txtCantPersonas.Text.ToString());
            recurso.Combustible = cBoxCombustible.Checked;
            recurso.Viatico = cBoxViaticos.Checked;
            recurso.Oficio_Comision = cBoxOficioComision.Checked;
            recurso.Otro = txtRecursoSolicitadoOtro.Text;
            //------------llenar Actividad-------------------
            EActividad actividad = new EActividad();
            actividad.CACEI = cBoxActividadCACEI.Checked;
            actividad.Licenciatura = cBoxActividadLicenciatura.Checked;
            actividad.Personal = cBoxActividadPersonal.Checked;
            actividad.ISO = cBoxActividadIso.Checked;
            actividad.Posgrado = cBoxActividadPosgrado.Checked;
            actividad.Otro = txtActividadOtros.Text;
            //-----------llenar Validacion------------------
            EValidacion validacion = new EValidacion();
            validacion.Coordinador = false;
            validacion.Subdirector = false;
            validacion.Administrador = false;
            validacion.Director = false;
            validacion.Posgrado = false;
            validacion.Unica = false;
            //----------------------------
            int id_estado = 1;
            //------------------------------------------------
            DateTime fecha_creacion = DateTime.Now;  //falta la hora exacta
            DateTime fecha_modificacion = DateTime.Now;//falta la hora exacta
            string URL_reporte = "";
            EUsuario_Uabc usuario = (EUsuario_Uabc)Session["Usuario"];
            string nombre_solicitante = usuario.Nombre;
            nombre_solicitante.Trim();
            int numero_empleado = usuario.NoEmpleado;
            string correo_solicitante = usuario.Email;
            correo_solicitante.Trim();
            string comentario_rechazado = "";
            bool leido = false;
            //------------------------------------------------
            N_Solicitud nuevaSolicitud = new N_Solicitud();
            nuevaSolicitud.Crear_Solicitud(-1,folio,nombre_solicitante,numero_empleado,id_categoria,id_carrera,
                evento,recurso,actividad,validacion,id_estado, fecha_creacion,fecha_modificacion,URL_reporte,
                correo_solicitante,comentario_rechazado,leido);*/
        }
    }
}