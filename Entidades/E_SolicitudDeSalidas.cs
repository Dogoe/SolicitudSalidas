/*
-------------------------------------------------------------------------------

Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
Proyecto: [Poner_Nombre_Del_Proyecto]
Archivo: E_SolicitudDeSalidas.cs
Fecha de creación: 01/12/2017

-----------------------------------------------------------------------------------

Función: [Poner_La_Una_Descripción_De_LaFunción_Principal_Del_Archivo]

-----------------------------------------------------------------------------------
	D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
-----------------------------------------------------------------------------------
*/

using System;

namespace Entidades
{
	public class E_Carrera
	{
		#region Atributos
		private string _Accion;
		private int _IdCarrera;
		private string _NombreCarrera;
		private int _IdCoordinador;
		#endregion

		#region Constructor
		public E_Carrera()
		{
			_Accion = string.Empty;
			_IdCarrera = 0;
			_NombreCarrera = string.Empty;
			_IdCoordinador = 0;
		}
		#endregion

		#region Encapsulamiento
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}
		public int IdCarrera
		{
			get { return _IdCarrera; }
			set {  _IdCarrera = value; }
		}
		public string NombreCarrera
		{
			get { return _NombreCarrera; }
			set {  _NombreCarrera = value; }
		}
		public int IdCoordinador
		{
			get { return _IdCoordinador; }
			set {  _IdCoordinador = value; }
		}
		#endregion
	}
	public class E_Categoria
	{
		#region Atributos
		private string _Accion;
		private int _IdCategoria;
		private string _NombreCategoria;
		private string _ClaveCategoria;
		#endregion

		#region Constructor
		public E_Categoria()
		{
			_Accion = string.Empty;
			_IdCategoria = 0;
			_NombreCategoria = string.Empty;
			_ClaveCategoria = string.Empty;
		}
		#endregion

		#region Encapsulamiento
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}
		public int IdCategoria
		{
			get { return _IdCategoria; }
			set {  _IdCategoria = value; }
		}
		public string NombreCategoria
		{
			get { return _NombreCategoria; }
			set {  _NombreCategoria = value; }
		}
		public string ClaveCategoria
		{
			get { return _ClaveCategoria; }
			set {  _ClaveCategoria = value; }
		}
		#endregion
	}
    public class E_Periodo
    {
        #region Atributos
        private string _Accion;
        private int _IdPeriodo;
        private string _CicloPeriodo;
        private DateTime? _FechaInicialPeriodo;
        private DateTime? _FechaFinalPeriodo;
        private int _Activo;
        #endregion

        #region Constructor
        public E_Periodo()
        {
            _Accion = string.Empty;
            _IdPeriodo = 0;
            _CicloPeriodo = string.Empty;
            _FechaInicialPeriodo = Convert.ToDateTime(DateTime.Now);
            _FechaFinalPeriodo = Convert.ToDateTime(DateTime.Now);
            _Activo = 0;
        }
        #endregion

        #region Encapsulamiento
        public string Accion
        {
            get { return _Accion; }
            set { _Accion = value; }
        }
        public int IdPeriodo { get => _IdPeriodo; set => _IdPeriodo = value; }
        public string CicloPeriodo { get => _CicloPeriodo; set => _CicloPeriodo = value; }
        public DateTime? FechaInicialPeriodo { get => _FechaInicialPeriodo; set => _FechaInicialPeriodo = value; }
        public DateTime? FechaFinalPeriodo { get => _FechaFinalPeriodo; set => _FechaFinalPeriodo = value; }
        public int Activo { get => _Activo; set => _Activo = value; }

        #endregion
    }
    public class E_EstadoSolicitudSalida
	{
		#region Atributos
		private string _Accion;
		private int _IdEstadoSolicitudSalida;
		private string _DescripcionEstado;
		#endregion

		#region Constructor
		public E_EstadoSolicitudSalida()
		{
			_Accion = string.Empty;
			_IdEstadoSolicitudSalida = 0;
			_DescripcionEstado = string.Empty;
		}
		#endregion

		#region Encapsulamiento
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}
		public int IdEstadoSolicitudSalida
		{
			get { return _IdEstadoSolicitudSalida; }
			set {  _IdEstadoSolicitudSalida = value; }
		}
		public string DescripcionEstado
		{
			get { return _DescripcionEstado; }
			set {  _DescripcionEstado = value; }
		}
		#endregion
	}
	public class E_Rol
	{
		#region Atributos
		private string _Accion;
		private int _IdRol;
		private string _NombreRol;
		private string _DescripcionRol;
		#endregion

		#region Constructor
		public E_Rol()
		{
			_Accion = string.Empty;
			_IdRol = 0;
			_NombreRol = string.Empty;
			_DescripcionRol = string.Empty;
		}
		#endregion

		#region Encapsulamiento
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}
		public int IdRol
		{
			get { return _IdRol; }
			set {  _IdRol = value; }
		}
		public string NombreRol
		{
			get { return _NombreRol; }
			set {  _NombreRol = value; }
		}
		public string DescripcionRol
		{
			get { return _DescripcionRol; }
			set {  _DescripcionRol = value; }
		}
		#endregion
	}
	public class E_Profesor
	{
		#region Atributos
		private string _Accion;
		private int _IdProfesor;
		private int _IdCategoria;
		private int _IdRol;
		private string _NumeroEmpleado;
		private string _NombreProfesor;
		private string _APaternoProfesor;
		private string _AMaternoProfesor;
		private string _EmailProfesor;
		#endregion

		#region Constructor
		public E_Profesor()
		{
			_Accion = string.Empty;
			_IdProfesor = 0;
			_IdCategoria = 0;
			_IdRol = 0;
			_NumeroEmpleado = string.Empty;
			_NombreProfesor = string.Empty;
			_APaternoProfesor = string.Empty;
			_AMaternoProfesor = string.Empty;
			_EmailProfesor = string.Empty;
		}
		#endregion

		#region Encapsulamiento
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}
		public int IdProfesor
		{
			get { return _IdProfesor; }
			set {  _IdProfesor = value; }
		}
		public int IdCategoria
		{
			get { return _IdCategoria; }
			set {  _IdCategoria = value; }
		}
		public int IdRol
		{
			get { return _IdRol; }
			set {  _IdRol = value; }
		}
		public string NumeroEmpleado
		{
			get { return _NumeroEmpleado; }
			set {  _NumeroEmpleado = value; }
		}
		public string NombreProfesor
		{
			get { return _NombreProfesor; }
			set {  _NombreProfesor = value; }
		}
		public string APaternoProfesor
		{
			get { return _APaternoProfesor; }
			set {  _APaternoProfesor = value; }
		}
		public string AMaternoProfesor
		{
			get { return _AMaternoProfesor; }
			set {  _AMaternoProfesor = value; }
		}
		public string EmailProfesor
		{
			get { return _EmailProfesor; }
			set {  _EmailProfesor = value; }
		}
		#endregion
	}
	public class E_SolicitudSalidas
	{
		#region Atributos
		private string _Accion;
		private int _IdSolicitud;
		private int _IdProfesor;
		private int _IdCarrera;
        private int _IdPeriodo;
		private int _IdEstadoSolicitudSalida;
		private string _Folio;
		private DateTime? _FechaCreacion;
		private DateTime? _FechaModificacion;
		private string _UrlReporte;
		private string _ComentarioRechazado;
		private Boolean _CACEI;
		private Boolean _Licenciatura;
		private Boolean _Personal;
		private Boolean _ISO;
		private Boolean _Posgrado;
		private string _OtraActividad;
		private string _NombreEvento;
		private double _CostoEvento;
		private string _LugarEvento;
		private DateTime? _FechaHoraSalida;
		private DateTime? _FechaHoraRegreso;
		private Boolean _Hospedaje;
		private int _Transporte;
		private Boolean _Combustible;
		private Boolean _Viatico;
		private Boolean _OficioComision;
		private string _OtroRecurso;
		private Boolean _ValCoordinador;
		private Boolean _ValSubdirector;
		private Boolean _ValAdministradorAcademico;
		private Boolean _ValDirector;
		private Boolean _ValPosgrado;
		private Boolean _ValUnica;
		#endregion

		#region Constructor
		public E_SolicitudSalidas()
		{
			_Accion = string.Empty;
			_IdSolicitud = 0;
			_IdProfesor = 0;
			_IdCarrera = 0;
            _IdPeriodo = 0;
            _IdEstadoSolicitudSalida = 0;
			_Folio = string.Empty;
			_FechaCreacion = Convert.ToDateTime(DateTime.Now);
			_FechaModificacion = Convert.ToDateTime(DateTime.Now);
			_UrlReporte = string.Empty;
			_ComentarioRechazado = string.Empty;
			_CACEI = false;
			_Licenciatura = false;
			_Personal = false;
			_ISO = false;
			_Posgrado = false;
			_OtraActividad = string.Empty;
			_NombreEvento = string.Empty;
			_CostoEvento = 0;
			_LugarEvento = string.Empty;
			_FechaHoraSalida = Convert.ToDateTime(DateTime.Now);
			_FechaHoraRegreso = Convert.ToDateTime(DateTime.Now);
			_Hospedaje = false;
			_Transporte = 0;
			_Combustible = false;
			_Viatico = false;
			_OficioComision = false;
			_OtroRecurso = string.Empty;
			_ValCoordinador = false;
			_ValSubdirector = false;
			_ValAdministradorAcademico = false;
			_ValDirector = false;
			_ValPosgrado = false;
			_ValUnica = false;
		}
		#endregion

		#region Encapsulamiento
		public string Accion
		{
			get { return _Accion; }
			set { _Accion = value; }
		}
		public int IdSolicitud
		{
			get { return _IdSolicitud; }
			set {  _IdSolicitud = value; }
		}
		public int IdProfesor
		{
			get { return _IdProfesor; }
			set {  _IdProfesor = value; }
		}
		public int IdCarrera
		{
			get { return _IdCarrera; }
			set {  _IdCarrera = value; }
		}
        public int IdPeriodo
        {
            get { return _IdPeriodo; }
            set { _IdPeriodo = value; }
        }
        public int IdEstadoSolicitudSalida
		{
			get { return _IdEstadoSolicitudSalida; }
			set {  _IdEstadoSolicitudSalida = value; }
		}
		public string Folio
		{
			get { return _Folio; }
			set {  _Folio = value; }
		}
		public DateTime? FechaCreacion
		{
			get { return _FechaCreacion; }
			set {  _FechaCreacion = value; }
		}
		public DateTime? FechaModificacion
		{
			get { return _FechaModificacion; }
			set {  _FechaModificacion = value; }
		}
		public string UrlReporte
		{
			get { return _UrlReporte; }
			set {  _UrlReporte = value; }
		}
		public string ComentarioRechazado
		{
			get { return _ComentarioRechazado; }
			set {  _ComentarioRechazado = value; }
		}
		public Boolean CACEI
		{
			get { return _CACEI; }
			set {  _CACEI = value; }
		}
		public Boolean Licenciatura
		{
			get { return _Licenciatura; }
			set {  _Licenciatura = value; }
		}
		public Boolean Personal
		{
			get { return _Personal; }
			set {  _Personal = value; }
		}
		public Boolean ISO
		{
			get { return _ISO; }
			set {  _ISO = value; }
		}
		public Boolean Posgrado
		{
			get { return _Posgrado; }
			set {  _Posgrado = value; }
		}
		public string OtraActividad
		{
			get { return _OtraActividad; }
			set {  _OtraActividad = value; }
		}
		public string NombreEvento
		{
			get { return _NombreEvento; }
			set {  _NombreEvento = value; }
		}
		public double CostoEvento
		{
			get { return _CostoEvento; }
			set {  _CostoEvento = value; }
		}
		public string LugarEvento
		{
			get { return _LugarEvento; }
			set {  _LugarEvento = value; }
		}
		public DateTime? FechaHoraSalida
		{
			get { return _FechaHoraSalida; }
			set {  _FechaHoraSalida = value; }
		}
		public DateTime? FechaHoraRegreso
		{
			get { return _FechaHoraRegreso; }
			set {  _FechaHoraRegreso = value; }
		}
		public Boolean Hospedaje
		{
			get { return _Hospedaje; }
			set {  _Hospedaje = value; }
		}
		public int Transporte
		{
			get { return _Transporte; }
			set {  _Transporte = value; }
		}
		public Boolean Combustible
		{
			get { return _Combustible; }
			set {  _Combustible = value; }
		}
		public Boolean Viatico
		{
			get { return _Viatico; }
			set {  _Viatico = value; }
		}
		public Boolean OficioComision
		{
			get { return _OficioComision; }
			set {  _OficioComision = value; }
		}
		public string OtroRecurso
		{
			get { return _OtroRecurso; }
			set {  _OtroRecurso = value; }
		}
		public Boolean ValCoordinador
		{
			get { return _ValCoordinador; }
			set {  _ValCoordinador = value; }
		}
		public Boolean ValSubdirector
		{
			get { return _ValSubdirector; }
			set {  _ValSubdirector = value; }
		}
		public Boolean ValAdministradorAcademico
		{
			get { return _ValAdministradorAcademico; }
			set {  _ValAdministradorAcademico = value; }
		}
		public Boolean ValDirector
		{
			get { return _ValDirector; }
			set {  _ValDirector = value; }
		}
		public Boolean ValPosgrado
		{
			get { return _ValPosgrado; }
			set {  _ValPosgrado = value; }
		}
		public Boolean ValUnica
		{
			get { return _ValUnica; }
			set {  _ValUnica = value; }
		}
		#endregion
	}
}

