using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TB
    {
        // Tablas de la base de datos y campos de ordenación
        public static string tbCarrera = "Carrera";
        public static string tbCarreraOrdenadoPor = "IdCarrera, NombreCarrera, IdCoordinador";
        //-----------------------------
        public static string tbCategoria = "Categoria";
        public static string tbCategoriaOrdenadoPor = "IdCategoria, NombreCategoria, ClaveCategoria";
        //-----------------------------------
        public static string tbPeriodo = "Periodo";
        public static string tbPeriodoOrdenadoPor = "IdPeriodo";
        //-----------------------------
        public static string tbEstadoSolicitudSalida = "EstadoSolicitudSalida";
        public static string tbEstadoSolicitudSalidaOrdenadoPor = "IdEstadoSolicitudSalida";
        //-----------------------------------
        public static string tbSolicitudSalidas = "SolicitudSalidas";
        public static string tbSolicitudSalidasOrdenadoPor = "IdSolicitud";
        //-----------------------------------
        public static string tbProfesor = "Profesor";
        public static string tbProfesorOrdenadoPor = "IdProfesor";
        //-------------------------------
        public static string tbRol = "Rol";
        public static string tbRolOrdenadoPor = "NombreRol";
        //tbProfesor

    }

    // StoreProcedure
    public class SP
    {
        public static string IBM_Carrera = "IBM_Carrera";
        public static string IBM_Categoria = "IBM_Categoria";
        public static string IBM_SolicitudSalida = "IBM_SolicitudSalida";
        public static string IBM_EstadoSolicitudSalida = "IBM_EstadoSolicitudSalida";
        public static string IBM_Rol = "IBM_Rol";
        public static string IBM_Profesor = "IBM_Profesor";
        public static string IBM_Periodo = "IBM_Periodo";
        //---------------
        public static string L_SolicitudSalida = "L_SolicitudSalida";
        /*public static string IBM_Modulo = "IBM_Modulo";
        public static string IBM_Accion = "IBM_Accion";

        public static string IB_UsuarioSistemaRol = "IB_UsuarioSistemaRol";
        public static string IB_SistemaModulo = "IB_SistemaModulo";
        public static string IB_RolModulo = "IB_RolModulo";
        public static string IB_ModuloAccion = "IB_ModuloAccion";*/
    }

    // Acciones del sistema
    public class Acciones
    {
        public static string Insertar = "INSERTAR";
        public static string Borrar = "BORRAR";
        public static string Modificar = "MODIFICAR";
    }


}
