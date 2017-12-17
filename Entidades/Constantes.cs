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
        //Generales
        public static string IBM_Carrera = "IBM_Carrera";
        public static string IBM_Categoria = "IBM_Categoria";
        public static string IBM_SolicitudSalida = "IBM_SolicitudSalida";
        public static string IBM_EstadoSolicitudSalida = "IBM_EstadoSolicitudSalida";
        public static string IBM_Rol = "IBM_Rol";
        public static string IBM_Profesor = "IBM_Profesor";
        public static string IBM_Periodo = "IBM_Periodo";
        //---------------
        //------Particulares
        public static string LstTodasLasSolicitudes = "LstTodasLasSolicitudes";
    }

    // Acciones del sistema
    public class Acciones
    {
        public static string Insertar = "INSERTAR";
        public static string Borrar = "BORRAR";
        public static string Modificar = "MODIFICAR";
        //---------
        public static string ConsultarTodo = "CONSULTAR_TODO";
    }
    //Estados de las solicitudes
    public class EstadosSolicitud
    {
        public static int Procceso = 1;
        public static int Aceptado = 2;
        public static int Rechazado = 3;
        public static int Cancelado = 4;
        public static int Reporte = 5;
        public static int Terminado = 6;
    }
    //Estados de las solicitudes
    public class EstadosSolicitudString
    {
        public static string Procceso = "Procceso";
        public static string Aceptado = "Aceptado";
        public static string Rechazado = "Rechazado";
        public static string Cancelado = "Cancelado";
        public static string Reporte = "Reporte";
        public static string Terminado = "Terminado";
    }
    //Mensajes de notificaciones de error o de exito
    public class MsjNotificacion
    {
        //Mensajes de exito
        public static string Exito_Al_Subir_Archivo = "'El archivo se ha guardado correctamente'";
        public static string Exito_Aceptar_Solicitud = "'La solicitud se ha aceptado correctamente'";
        public static string Exito_Aprobar_Solicitud = "'La solicitud se ha aprobado correctamente'";
        public static string Exito_Rechazar_Solicitud = "'La solicitud se ha rechazado correctamente'";
        public static string Exito_Modificar_Solicitud = "'La solicitud se ha modificado correctamente'";
        public static string Exito_Crear_Solicitud = "'La solicitud se ha creado correctamente'";
        public static string Exito_Terminar_Sol = "'La solicitud ha cambiado a estado terminado correctamente'";
        //Mensajes error
        public static string Error_General = "'Ocurrido un error, favor de contactar a soporte'";
        public static string Error_Tabla = "'Ocurrido un error al obtener datos de la tabla'";
        public static string Error_Aceptar_Solicitud = "'Ha ocurrido un error al intentar Aceptar la solicitud'";
        public static string Error_Aprobar_Solicitud = "'Ha ocurrido un error al intentar Aprobar la solicitud'";
        public static string Error_Rechazar_Solicitud = "'Ha ocurrido un error al intentar Rechazar la solicitud'";
        public static string Error_Modificar_Solicitud = "'Ha ocurrido un error al intentar Modificar la solicitud'";
        public static string Error_Crear_Solicitud = "'Ha ocurrido un error al intentar Crear la solicitud'";
        public static string Error_Terminar_Sol = "'La solicitud no se ha podido cambiar a estado terminado'";
        //public static string Error_Subir_ = "'La solicitud no se ha podido cambiar a estado terminado'";
        //Mensajes info
        public static string Msj_Sin_Sol_Pendientes = "'No tiene notificaciones pendientes.'";
        public static string Msj_Sin_Sol = "'No Se encontraron registros.'";
        public static string Msj_Usuario_Sin_Permiso = "'No tienes permisos para realizar esta accion.'";
        public static string Msj_Extensiones_Permitidas_Archivo = "'Solo se aceptan documentos con extension .pdf'";
        public static string Msj_Sin_Seleccionar_Archivo = "'No seleccionaste ningun archivo'";
        public static string Msj_Nombre_Archivo_Ya_Existe = "'El nombre del archivo ya existe, intenta cambiar el nombre para guardarlo'";
    }
    //Colores para las notificaciones
    public class ColorNotificacion
    {
        public static string Rojo = "'danger'";
        public static string Verde = "'success'";
        public static string Amarillo = "'warning'";
        public static string Azul = "'info'";
    }
    //Path donde se guardaran los reportes de los maestros
    public class Directorio
    {
        public static string ReportesDeSalidas = "~/ReportesSalidas/";
    }
    //Roles en el sistema
    public class Rol
    {
        public static string Administrador = "Administrador";
        public static string Academico = "Academico";
        public static string Docente = "Docente";
    }
    //Cargos en el sistema
    public class Cargo
    {
        public static string Subdirector = "Subdirector";
        public static string Coordinador = "Coordinador";
        public static string AdministradorAcademico = "AdministradorAcademico";
        public static string Director = "Director";
        public static string Posgrado = "Posgrado";
    }

}
