﻿using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class Usuarios : System.Web.UI.MasterPage
    {
        E_Profesor profesor;
        string rolProfesor;
        string cargoPtofesor;
        //------------
        protected void Page_Load(object sender, EventArgs e)
        {
            profesor = (E_Profesor)Session["Profesor"];
            rolProfesor = (string)Session["Rol"];
            cargoPtofesor = (string)Session["Cargo"];
            if (profesor == null)
            {
                Server.Transfer("~/Default.aspx", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    labelNombreUsuario.Text = profesor.NombreProfesor;
                    Cargar_Notificaciones(-1,-1);
                }
                
            }
        }
        //-------------------------------------------
        public void Cargar_Notificaciones(int cantPendientesDocente, int cantPendientesValidador)
        {
            if (cantPendientesDocente==-1 && cantPendientesValidador==-1)
            {
                int contadorSolPendProfesor = 0;
                int contadorSolPenValidador = 0;
                //-------------------
                N_Rol nRol = new N_Rol();
                E_Rol rolUsuario = nRol.BuscaRolPorId(profesor.IdRol);
                //----------------------
                N_SolicitudSalidas nSolicitudSalidas = new N_SolicitudSalidas();
                List<E_SolicitudSalidasJoin> datosListaSolPendientesDocente = nSolicitudSalidas.BuscaSolicitudPendienteProfesor(profesor.IdProfesor);
                if (datosListaSolPendientesDocente != null)
                {
                    contadorSolPendProfesor = datosListaSolPendientesDocente.Count;
                }

                //--------------------
                List<E_SolicitudSalidasJoin> datosListaSolPendientesValidador = nSolicitudSalidas.BuscaSolicitudesPendientesValidador(rolUsuario.DescripcionRol);
                if (datosListaSolPendientesValidador != null)
                {
                    contadorSolPenValidador = datosListaSolPendientesValidador.Count;
                }
                //------------------------------------------------------
                contadorNotificaciones.Text = Convert.ToString(contadorSolPendProfesor + contadorSolPenValidador);
            }
            else
            {
                contadorNotificaciones.Text = Convert.ToString(cantPendientesDocente + cantPendientesValidador);
            }
          

        }
        //--------------
        public void Mostrar_Notificacion(string msj, string TipoColor)
        {
            string script = string.Format("Notificaciones({0},{1});", msj, TipoColor);
            ScriptManager.RegisterStartupScript(Page, Page.ClientScript.GetType(), "mostrarNotificacion", script, true);
        }

    }
}