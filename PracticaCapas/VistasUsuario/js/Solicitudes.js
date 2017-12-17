$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    var tabSeleccionada = $('#ContentPlaceHolder_TABSeleccionada').val();
    //console.log(algo);
    $('#tabSolicitudesPendientes a[href="#' + tabSeleccionada + '"]').tab('show');
    //$('#tabHistorialSolicitudes a[href="#' + algo + '"]').tab('show');
    /*$.notify({
        // options
        message: "Hello World"
    }, {
            // settings
            type: "danger"
        });*/
   
    
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
/*function abrirPDF(url) {
    var a = document.createElement("a");
    a.target = "_blank";
    a.href = url;
    a.click();
    //window.open(url, "Diseño Web", "width=300, height=200");
}*/
function abrirPDF(url) {
    //debugger
    window.open(url, "_blank");
    //window.open(url, "Diseño Web", "width=300, height=200");
}
function Notificaciones(msj,color) {
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
//window.open("myurl/files/" + nombreArchivo + ".pdf", "_blank");
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
