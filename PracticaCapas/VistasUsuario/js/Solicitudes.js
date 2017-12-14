$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    var tabSeleccionada = $('#ContentPlaceHolder_TABSeleccionada').val();
    //console.log(algo);
    $('#tabSolicitudesPendientes a[href="#' + tabSeleccionada + '"]').tab('show');
    //$('#tabHistorialSolicitudes a[href="#' + algo + '"]').tab('show');
    
    
});
function openModal() {
    $('#ModalModificarConsultarSolicitud').modal('show');
}
//-------------------
function openModalConfirmar() {
    $('#ContentPlaceHolder_txtNombreEvento').removeAttr("required");
    $('#ContentPlaceHolder_txtLugarEvento').removeAttr("required");
    $('#ContentPlaceHolder_txtFechaSalida').removeAttr("required");
    $('#ContentPlaceHolder_txtHoraSalida').removeAttr("required");
    $('#ContentPlaceHolder_txtFechaLLegada').removeAttr("required");
    $('#ContentPlaceHolder_txtHoraLlegada').removeAttr("required");
    $('#ContentPlaceHolder_txtRecursoSolicitadoOtro').removeAttr("required");
    $('#ContentPlaceHolder_txtCantPersonas').removeAttr("required");
    $('#ContentPlaceHolder_txtActividadOtros').removeAttr("required");
    //----------------------
    
    $('#ModalConfirmarSolicitud').modal('show');
    //$('#tabSolicitudesPendientes a[href="' + "#validador" + '"]').tab('show');
}
//------------------

/*$("body").on("click", "[id*=gvSolicitudesPendientesAdmin] .Aceptar", function () {
    //-----------------------------------
    var row = $(this).closest("tr");
    var Id = row.find(".IdSolicitud").find("span").html();
    console.log(Id);
    //$('#ContentPlaceHolder_txtIdSolicitudHidde').val(Id);
    $('#ModalAceptarSolicitud').modal('show');

    //return false;
});*/
//--------------
