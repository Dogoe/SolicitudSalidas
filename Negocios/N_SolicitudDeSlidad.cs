/*
-------------------------------------------------------------------------------

Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
Proyecto: [Poner_Nombre_Del_Proyecto]
Archivo: N_SolicitudDeSlidad.cs
Fecha de creación: 01/12/2017

-----------------------------------------------------------------------------------

Función: [Poner_La_Una_Descripción_De_LaFunción_Principal_Del_Archivo]

-----------------------------------------------------------------------------------
	D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
-----------------------------------------------------------------------------------
*/

using System.Linq;
using System.Data;
using System.Collections.Generic;

using DatosSQL;
using Entidades;
using System.Data.Common;
using System.Data.SqlClient;

namespace Negocios
{
    public class N_Carrera
	{
		D_IBM_Datos ObjIBM = new D_IBM_Datos();
		D_Listados ObjLst = new D_Listados();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Carrera.
		public string InsertaCarrera(E_Carrera pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_Carrera>(SP.IBM_Carrera, pEntidad); }

		public string BorraCarrera(int pIdCarrera) { E_Carrera Entidad = new E_Carrera { Accion = Acciones.Borrar, IdCarrera = pIdCarrera }; return ObjIBM.IBM_Entidad<E_Carrera>(SP.IBM_Carrera, Entidad); }

		public string ModificaCarrera(E_Carrera pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_Carrera>(SP.IBM_Carrera, pEntidad); }

		// Listado generales de la clase Carrera en formato DataTable y List<E_Carrera>.
		public DataTable DT_LstCarrera() { return ObjLst.DT_ListadoGeneral(TB.tbCarrera, TB.tbCarreraOrdenadoPor); }

		public List<E_Carrera> LstCarrera() { return D_ConvierteDatos.ConvertirDTALista<E_Carrera>(DT_LstCarrera()); }

		// Busquedas de la claseCarrera por diferente Criterios
		public E_Carrera BuscaCarreraPorId(int pIdCarrera) { return (from Carrera in LstCarrera() where Carrera.IdCarrera == pIdCarrera select Carrera).FirstOrDefault(); }

	}
	public class N_Categoria
	{
		D_IBM_Datos ObjIBM = new D_IBM_Datos();
		D_Listados ObjLst = new D_Listados();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Categoria.
		public string InsertaCategoria(E_Categoria pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_Categoria>(SP.IBM_Categoria, pEntidad); }

		public string BorraCategoria(int pIdCategoria) { E_Categoria Entidad = new E_Categoria { Accion = Acciones.Borrar, IdCategoria = pIdCategoria }; return ObjIBM.IBM_Entidad<E_Categoria>(SP.IBM_Categoria, Entidad); }

		public string ModificaCategoria(E_Categoria pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_Categoria>(SP.IBM_Categoria, pEntidad); }

		// Listado generales de la clase Categoria en formato DataTable y List<E_Categoria>.
		public DataTable DT_LstCategoria() { return ObjLst.DT_ListadoGeneral(TB.tbCategoria, TB.tbCategoriaOrdenadoPor); }

		public List<E_Categoria> LstCategoria() { return D_ConvierteDatos.ConvertirDTALista<E_Categoria>(DT_LstCategoria()); }

		// Busquedas de la claseCategoria por diferente Criterios
		public E_Categoria BuscaCategoriaPorId(int pIdCategoria) { return (from Categoria in LstCategoria() where Categoria.IdCategoria == pIdCategoria select Categoria).FirstOrDefault(); }

	}
    public class N_Periodo
    {
        D_IBM_Datos ObjIBM = new D_IBM_Datos();
        D_Listados ObjLst = new D_Listados();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase Categoria.
        public string InsertaPeriodo(E_Periodo pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_Periodo>(SP.IBM_Periodo, pEntidad); }

        public string BorraPeriodo(int pIdPeriodo) { E_Periodo Entidad = new E_Periodo { Accion = Acciones.Borrar, IdPeriodo = pIdPeriodo }; return ObjIBM.IBM_Entidad<E_Periodo>(SP.IBM_Periodo, Entidad); }

        public string ModificaPeriodo(E_Periodo pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_Periodo>(SP.IBM_Periodo, pEntidad); }

        // Listado generales de la clase Categoria en formato DataTable y List<E_Categoria>.
        public DataTable DT_LstPeriodo() { return ObjLst.DT_ListadoGeneral(TB.tbPeriodo, TB.tbPeriodoOrdenadoPor); }

        public List<E_Periodo> LstPeriodo() { return D_ConvierteDatos.ConvertirDTALista<E_Periodo>(DT_LstPeriodo()); }

        // Busquedas de la claseCategoria por diferente Criterios
        public E_Periodo BuscaPeriodoPorId(int pIdPeriodo) { return (from Periodo in LstPeriodo() where Periodo.IdPeriodo == pIdPeriodo select Periodo).FirstOrDefault(); }

    }
    public class N_EstadoSolicitudSalida
	{
		D_IBM_Datos ObjIBM = new D_IBM_Datos();
		D_Listados ObjLst = new D_Listados();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase EstadoSolicitudSalida.
		public string InsertaEstadoSolicitudSalida(E_EstadoSolicitudSalida pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_EstadoSolicitudSalida>(SP.IBM_EstadoSolicitudSalida, pEntidad); }

		public string BorraEstadoSolicitudSalida( int pIdEstadoSolicitudSalida) { E_EstadoSolicitudSalida Entidad = new E_EstadoSolicitudSalida { Accion = Acciones.Borrar, IdEstadoSolicitudSalida = pIdEstadoSolicitudSalida }; return ObjIBM.IBM_Entidad<E_EstadoSolicitudSalida>(SP.IBM_EstadoSolicitudSalida, Entidad); }

		public string ModificaEstadoSolicitudSalida(E_EstadoSolicitudSalida pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_EstadoSolicitudSalida>(SP.IBM_EstadoSolicitudSalida, pEntidad); }

		// Listado generales de la clase EstadoSolicitudSalida en formato DataTable y List<E_EstadoSolicitudSalida>.
		public DataTable DT_LstEstadoSolicitudSalida() { return ObjLst.DT_ListadoGeneral(TB.tbEstadoSolicitudSalida, TB.tbEstadoSolicitudSalidaOrdenadoPor); }

		public List<E_EstadoSolicitudSalida> LstEstadoSolicitudSalida() { return D_ConvierteDatos.ConvertirDTALista<E_EstadoSolicitudSalida>(DT_LstEstadoSolicitudSalida()); }

		// Busquedas de la claseEstadoSolicitudSalida por diferente Criterios
		public E_EstadoSolicitudSalida BuscaEstadoSolicitudSalidaPorId(int IdEstadoSolicitudSalida) { return (from EstadoSolicitudSalida in LstEstadoSolicitudSalida() where EstadoSolicitudSalida.IdEstadoSolicitudSalida == IdEstadoSolicitudSalida select EstadoSolicitudSalida).FirstOrDefault(); }

	}
	public class N_Rol
	{
		D_IBM_Datos ObjIBM = new D_IBM_Datos();
		D_Listados ObjLst = new D_Listados();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Rol.
		public string InsertaRol(E_Rol pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_Rol>(SP.IBM_Rol, pEntidad); }

		public string BorraRol(int pIdRol) { E_Rol Entidad = new E_Rol { Accion = Acciones.Borrar, IdRol = pIdRol }; return ObjIBM.IBM_Entidad<E_Rol>(SP.IBM_Rol, Entidad); }

		public string ModificaRol(E_Rol pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_Rol>(SP.IBM_Rol, pEntidad); }

		// Listado generales de la clase Rol en formato DataTable y List<E_Rol>.
		public DataTable DT_LstRol() { return ObjLst.DT_ListadoGeneral(TB.tbRol, TB.tbRolOrdenadoPor); }

		public List<E_Rol> LstRol() { return D_ConvierteDatos.ConvertirDTALista<E_Rol>(DT_LstRol()); }

		// Busquedas de la claseRol por diferente Criterios
		public E_Rol BuscaRolPorId(int pIdRol) { return (from Rol in LstRol() where Rol.IdRol == pIdRol select Rol).FirstOrDefault(); }

	}
	public class N_Profesor
	{
		D_IBM_Datos ObjIBM = new D_IBM_Datos();
		D_Listados ObjLst = new D_Listados();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Profesor.
		public string InsertaProfesor(E_Profesor pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_Profesor>(SP.IBM_Profesor, pEntidad); }

		public string BorraProfesor(int pIdProfesor) { E_Profesor Entidad = new E_Profesor { Accion = Acciones.Borrar, IdProfesor = pIdProfesor }; return ObjIBM.IBM_Entidad<E_Profesor>(SP.IBM_Profesor, Entidad); }

		public string ModificaProfesor(E_Profesor pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_Profesor>(SP.IBM_Profesor, pEntidad); }

		// Listado generales de la clase Profesor en formato DataTable y List<E_Profesor>.
		public DataTable DT_LstProfesor() { return ObjLst.DT_ListadoGeneral(TB.tbProfesor, TB.tbProfesorOrdenadoPor); }

		public List<E_Profesor> LstProfesor() { return D_ConvierteDatos.ConvertirDTALista<E_Profesor>(DT_LstProfesor()); }

		// Busquedas de la claseProfesor por diferente Criterios
		public E_Profesor BuscaProfesorPorId(int pIdProfesor) { return (from Profesor in LstProfesor() where Profesor.IdProfesor == pIdProfesor select Profesor).FirstOrDefault(); }
        public E_Profesor BuscaProfesorPorCorreo(string pEmailProfesor) { return (from Profesor in LstProfesor() where Profesor.EmailProfesor == pEmailProfesor select Profesor).FirstOrDefault(); }

    }
	public class N_SolicitudSalidas
	{
        N_EstadoSolicitudSalida nEstado = new N_EstadoSolicitudSalida();
        //------------------------
        D_IBM_Datos ObjIBM = new D_IBM_Datos();
		D_Listados ObjLst = new D_Listados();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Solicitud.
		public string InsertaSolicitud(E_SolicitudSalidas pEntidad) { pEntidad.Accion = Acciones.Insertar; return ObjIBM.IBM_Entidad<E_SolicitudSalidas>(SP.IBM_SolicitudSalida, pEntidad); }

		public string BorraSolicitud(int pIdSolicitud) { E_SolicitudSalidas Entidad = new E_SolicitudSalidas { Accion = Acciones.Borrar, IdSolicitud = pIdSolicitud }; return ObjIBM.IBM_Entidad<E_SolicitudSalidas>(SP.IBM_SolicitudSalida, Entidad); }

		public string ModificaSolicitud(E_SolicitudSalidas pEntidad) { pEntidad.Accion = Acciones.Modificar; return ObjIBM.IBM_Entidad<E_SolicitudSalidas>(SP.IBM_SolicitudSalida, pEntidad); }

		// Listado generales de la clase Solicitud en formato DataTable y List<E_Solicitud>.
		public DataTable DT_LstSolicitud() { return ObjLst.DT_ListadoGeneral(TB.tbSolicitudSalidas, TB.tbSolicitudSalidasOrdenadoPor); }

		public List<E_SolicitudSalidas> LstSolicitud() { return D_ConvierteDatos.ConvertirDTALista<E_SolicitudSalidas>(DT_LstSolicitud()); }
        public List<E_SolicitudSalidasJoin> ListSolicitudesSalidaJoin(string accion)
        {
            List<DbParameter> LstParametros = new List<DbParameter> { new SqlParameter("@accion", accion) };
            return D_ConvierteDatos.ConvertirDTALista<E_SolicitudSalidasJoin>(ObjLst.DT_GetListado(SP.LstTodasLasSolicitudes, LstParametros));
        }

        // Busquedas de la claseSolicitud por diferente Criterios
        public E_SolicitudSalidas BuscaSolicitudPorId(int pIdSolicitud) { return (from Solicitud in LstSolicitud() where Solicitud.IdSolicitud == pIdSolicitud select Solicitud).FirstOrDefault(); }
        public List<E_SolicitudSalidasJoin> BuscaSolicitudPorIdProfesor(int pIdProfesor) { return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.IdProfesor == pIdProfesor select Solicitud).ToList(); }
        public List<E_SolicitudSalidasJoin> BuscaSolicitudPendienteProfesor(int pIdProfesor) { return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.IdProfesor == pIdProfesor where Solicitud.IdEstadoSolicitudSalida != 1 where Solicitud.IdEstadoSolicitudSalida != 4 where Solicitud.IdEstadoSolicitudSalida != 6 select Solicitud).ToList(); }
        //----------------
        //public List<E_SolicitudSalidasJoin> ListSolicitudesSalidaJoin() { return (List<E_SolicitudSalidasJoin>)(from Solicitud in LstSolicitud() join Estado in nEstado.LstEstadoSolicitudSalida() on Solicitud.IdEstadoSolicitudSalida equals Estado.IdEstadoSolicitudSalida select Solicitud); }
        //Obtener Solicitudes dependiendo del nivel de validacion en el ue se encuentra en usuario
        public List<E_SolicitudSalidasJoin> BuscaSolicitudesPendientesValidador(string cargoValidador) {
            if (cargoValidador == "Subdirector")
            {
                return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.ValSubdirector == false where Solicitud.ValUnica == false where Solicitud.IdEstadoSolicitudSalida == 1 select Solicitud).ToList();
            }
            else
            {
                if (cargoValidador == "Coordinador")
                {
                    return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.ValCoordinador == false where Solicitud.ValSubdirector == true where Solicitud.ValUnica == false where Solicitud.IdEstadoSolicitudSalida == 1 select Solicitud).ToList();
                }
                else
                {
                    if (cargoValidador == "AdministradorAcademico")
                    {
                        return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.ValAdministradorAcademico == false where Solicitud.ValCoordinador == true where Solicitud.ValUnica == false where Solicitud.IdEstadoSolicitudSalida == 1 select Solicitud).ToList();
                    }
                    else
                    {
                        if (cargoValidador == "Director")
                        {
                            return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.ValDirector == false where Solicitud.ValAdministradorAcademico == true where Solicitud.ValUnica == false where Solicitud.IdEstadoSolicitudSalida == 1 select Solicitud).ToList();
                        }
                        else
                        {
                            if (cargoValidador == "Posgrado")
                            {
                                return (from Solicitud in ListSolicitudesSalidaJoin(Acciones.ConsultarTodo) where Solicitud.ValPosgrado == false where Solicitud.ValDirector == true where Solicitud.ValUnica == false where Solicitud.IdEstadoSolicitudSalida == 1 select Solicitud).ToList();
                            }
                            else
                            {
                                return null;
                            }
                          
                        }
                    }
                }
            }
            
        }

    }
}

