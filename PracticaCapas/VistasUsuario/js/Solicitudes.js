$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    var tabSeleccionada = $('#ContentPlaceHolder_TABSeleccionada').val();
    $('#tabSolicitudesPendientes a[href="#' + tabSeleccionada + '"]').tab('show');



});
function openModalSolicitudes() {
    $('#ModalModificarConsultarSolicitud').modal('show');
}

//-------------------
function openModalConfirmar() {
    $('#ContentPlaceHolder_txtNombreEvento').removeAttr("required");
    $('#ContentPlaceHolder_txtLugarEvento').removeAttr("required");
    $('#ContentPlaceHolder_txtFechaSalida').removeAttr("required");
    $('#ContentPlaceHolder_txtHoraSalida').removeAttr("required");
    $('#ContentPlaceHolder_txtFechaRegreso').removeAttr("required");
    $('#ContentPlaceHolder_txtHoraRegreso').removeAttr("required");
    $('#ContentPlaceHolder_txtRecursoSolicitadoOtro').removeAttr("required");
    $('#ContentPlaceHolder_txtCantPersonas').removeAttr("required");
    $('#ContentPlaceHolder_txtActividadOtros').removeAttr("required");
    //----------------------

    $('#ModalConfirmarSolicitud').modal('show');
}
//------------------
function abrirPDF(url) {
    //debugger
    window.open(url, "_blank");
    //window.open(url, "Diseño Web", "width=300, height=200");
}
function Notificaciones(msj, color) {
    $.notify({
        // options
        icon: 'glyphicon glyphicon-warning-sign',
        message: msj,
    }, {
            // settings
            type: color,
            allow_dismiss: true,
            newest_on_top: true,
            placement: {
                from: "top",
                align: "right"
            },
            delay: 4000,
            timer: 1000,
            mouse_over: null,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
        });
}
