var idIncidente = -1;
var fecha = "";
var incidenteSeleccionado = null;
var incidencia = null;
var registros = null;


function obtenerRegistrosIncidentes() {
    var modal = document.getElementById('myModal');
    modal.style.display = "block";
    let params = new URLSearchParams(location.search);
    idIncidente = params.get('Id');
    fecha = params.get('Fecha');
    //console.log("idIncidente: " + idIncidente + ", fecha: " + fecha);
    $.ajax({
        type: 'POST',
        url: '/Incidente/ObtenerRegistrosIncidentes',
        data: {
            'Fecha': fecha,
            'Id': idIncidente
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            modal.style.display = "none";
            if (data.validacion == true) {
                registros = data.registros;
                incidencia = data.incidente;
                //console.log(registros);
                datosIncidentes(data.incidente, registros.length);
                tablaRegistroIncidentes(registros);
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Aún no existen registros de incidentes para la fecha " + fecha);
                $("#modal-alerta").modal("show");

                $('#OPI').DataTable();
            }
        },
        error: function () {
            modal.style.display = "none";
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas en la función obtenerRegistrosIncidentes en vista incidente.');
            $("#modal-alerta").modal("show");
        }
    });
}


function datosIncidentes(incidente, cantRegistros) {
    document.getElementById("descripcion").innerHTML = incidente["nombreAgrupacionTiempo"] + " - " + incidente["descripcionClasificacion"] + " - " + incidente["nombreZona"];
    document.getElementById("idIncidencia").innerHTML = incidente["idIncidente"];
    document.getElementById("fechaIncidencia").innerHTML = fecha;
    document.getElementById("cantIncidentes").innerHTML = cantRegistros;
}

function tablaRegistroIncidentes(registros) {
    //console.log(registros);
    $('#OPI').DataTable({
        'data': registros,
        'order': [[0, "asc"]],
        'columns': [
            { "data": "id" },
            //{ "data": "refOrden" },
            {
                "render": function (data, type, full, meta) {
                    var refOrden = "";
                    if (full.refOrden == "-1") {
                        refOrden = 'Sin orden asociada';
                    }
                    else {
                        refOrden = full.refOrden 
                    }
                    return refOrden;
                }
            },

            
            {
                "data": "fechaHoraInicio", render: function (d) {
                    return moment(d).format("YYYY-MM-DD HH:mm:ss");
                }
            },
            {
                "data": "fechaHoraTermino", render: function (d) {
                    var fechaTermino = moment(d).format("YYYY-MM-DD HH:mm:ss");
                    if (fechaTermino != "2020-01-01 00:00:00") {
                        return fechaTermino;
                    }
                    return " - ";
                }
            },

            { "data": "cantMinutos" },

            {
                "render": function (data, type, full, meta) {
                    var progresoOrden = " - ";
                    if (full.progresoOrden != "-1") {
                        switch (full.estadoOrden) {
                            case "Pausada":
                                progresoOrden = "<span class='label bg-pause'>" + full.progresoOrden + "%</span>";
                                break;
                            case "Pospuesta":
                                progresoOrden = "<span class='label bg-postpone'>" + full.progresoOrden + "%</span>"
                                break;
                        }

                    }
                    return progresoOrden;
                }
            },

            {
                "render": function (data, type, full, meta) {
                    var estadoOrden = " - ";
                    if (full.estadoOrden!= "-") {
                        switch (full.estadoOrden) {
                            case "Pausada":
                                estadoOrden = "<span class='label bg-pause'>" + full.estadoOrden + "</span>";
                                break;
                            case "Pospuesta":
                                estadoOrden = "<span class='label bg-postpone'>" + full.estadoOrden + "</span>"
                                break;
                        }
                    }
                    return estadoOrden;
                }
            },
            { "data": "observacion" },
            {
                "render": function (data, type, full, meta) {
                    var acciones = "";
                    acciones = '<button class="btn bg-orange" onclick="editarObservacionIncidente(' + full.id + ')" title="Editar observacion"><div><i class="glyphicon glyphicon-pencil"></i></div></button>'
                    if (moment(full.fechaHoraTermino).format("YYYY-MM-DD HH:mm:ss")=="2020-01-01 00:00:00") {
                        acciones += '<button class="btn btn-success" onclick="alertaFinalizarIncidente(' + full.id + ')" title="Finalizar Incidente"><div><i class="glyphicon glyphicon-ok"></i></div></button>';
                    }

                    return acciones;
                }
            },

        ]
    });
}

function editarObservacionIncidente(id) {
    idIncidenteRegistrado = id;
    incidenteSeleccionado = registros.filter(registro => registro.id == id)[0];

    switch (incidenteSeleccionado["estadoOrden"]) {
        case "Pausada":
            if (document.getElementById('modal-header-incicente').classList.contains('bg-maroon')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-maroon');

            }
            else if (document.getElementById('modal-header-incicente').classList.contains('bg-green')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-green');

            }

            if (!document.getElementById('modal-header-incicente').classList.contains('bg-orange')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-orange');
            }
            break;
        case "Pospuesta":
            if (document.getElementById('modal-header-incicente').classList.contains('bg-orange')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-orange');
            }
            else if (document.getElementById('modal-header-incicente').classList.contains('bg-green')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-green');
            }

            if (!document.getElementById('modal-header-incicente').classList.contains('bg-maroon')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-maroon');
            }
            break;
        default:
            if (document.getElementById('modal-header-incicente').classList.contains('bg-orange')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-orange');
            }
            else if (document.getElementById('modal-header-incicente').classList.contains('bg-maroon')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-maroon');
            }

            if (!document.getElementById('modal-header-incicente').classList.contains('bg-green')) {
                document.getElementById('modal-header-incicente').classList.toggle('bg-green');
            }
            break;
    }


    var refOrden = incidenteSeleccionado["refOrden"];

    if (refOrden == "-1") {
        refOrden = "Sin orden asociada";
    }

    document.getElementById("idIncidente").innerHTML = incidenteSeleccionado["id"];
    document.getElementById("numeroOrden").innerHTML = refOrden;
    document.getElementById("fechaHoraInicioDetalle").innerHTML = moment(incidenteSeleccionado["fechaHoraInicio"]).format("YYYY-MM-DD HH:mm:ss");
    document.getElementById("fechaHoraTerminoDetalle").innerHTML = moment(incidenteSeleccionado["fechaHoraTermino"]).format("YYYY-MM-DD HH:mm:ss");

    document.getElementById("nombreAgrupacionTiempo").innerHTML = incidencia["nombreAgrupacionTiempo"];
    document.getElementById("descripcionClasificacion").innerHTML = incidencia["descripcionClasificacion"];
    document.getElementById("aclaracionClasificacion").innerHTML = incidencia["aclaracionClasificacion"];
    document.getElementById("nombreZona").innerHTML = incidencia["nombreZona"];

    document.getElementById("observacion").value = incidenteSeleccionado["observacion"];
    $("#modal-Incidencia").modal("show");

}


function alertaFinalizarIncidente(id) {
    idIncidenteRegistrado = id;
    incidenteSeleccionado = registros.filter(registro => registro.id == id)[0];
    switch (incidenteSeleccionado["estadoOrden"]) {
        case "Pausada":
            if (document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-maroon')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-maroon');

            }
            else if (document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-green')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-green');

            }

            if (!document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-orange')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-orange');
            }
            break;
        case "Pospuesta":
            if (document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-orange')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-orange');
            }
            else if (document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-green')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-green');
            }

            if (!document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-maroon')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-maroon');
            }
            break;
        default:
            if (document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-orange')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-orange');
            }
            else if (document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-maroon')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-maroon');
            }

            if (!document.getElementById('modal-header-confirm-finalizar').classList.contains('bg-green')) {
                document.getElementById('modal-header-confirm-finalizar').classList.toggle('bg-green');
            }
            break;
    }

    $('#title-confirm-finalizar').text("Finalizar incidencia");
    $('#body-confirm-finalizar').text('¿Seguro que desea finalizar la incidencia N°' + id + "?");
    $("#modal-confirm-finalizar").modal("show");
}

$('#btnConfirmModIncidencia').click(function () {
    var observacion = $("#observacion").val();
    $.ajax({
        url: "/Incidente/ActualizarObservacionIncidente",
        method: "POST",
        async: "false",
        data: {
            "IdIncidente": idIncidenteRegistrado,
            'Observacion': observacion
        },
        success: function (data) {
            if (data == 1) {
                $('#modal-Incidencia').modal('hide');
                obtenerRegistrosIncidentes();
                $('#title-confirm').text("Modificación exitosa");
                $('#body-confirm').text('La observación de la incidencia N°' + idIncidenteRegistrado + " se ha modificado correctamente.");
                $("#modal-confirm").modal("show");
            }
            else if (data == -1) {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('La observación incidencia N°' + idIncidenteRegistrado + " se ha podido modificar. Por favor, intentelo nuevamente");
                $("#modal-alerta").modal("show");
            }

            idIncidenteRegistrado = -1;
        }
    });

});




$('#btnConfirmFinalizar').click(function () {
    $('#modal-confirm-finalizar').modal('hide');
    $.ajax({
        url: "/Incidente/FinalizarIncidenciaPorId",
        method: "POST",
        async: "false",
        data: {
            "IdIncidente": idIncidenteRegistrado,
            'FechaHoraTermino': moment(new Date()).format('YYYY-MM-DD HH:mm:ss')
        },
        success: function (data) {
            if (data == 1) {
                obtenerRegistrosIncidentes();
                $('#title-confirm').text("Incidencia finalizada");
                $('#body-confirm').text('La incidencia N°' + idIncidenteRegistrado + " se ha finalizado correctamente.");
                $("#modal-confirm").modal("show");
            }
            else if (data == -1) {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('La incidencia N°' + idIncidenteRegistrado + " se ha podido finalizar. Intentelo nuevamente");
                $("#modal-alerta").modal("show");
            }

            idIncidenteRegistrado = -1;
        }
    });
    
});