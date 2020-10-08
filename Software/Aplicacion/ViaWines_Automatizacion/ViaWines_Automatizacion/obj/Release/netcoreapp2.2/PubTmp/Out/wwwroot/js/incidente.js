var fecha = "2020-10-01";
var incidentes = null;

function ObtenerFechaIncidentes() {
    $.ajax({
        type: 'POST',
        url: '/Incidente/ObtenerFechaIncidentes',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data) {
            // An array of dates
            var eventDates = {};

            for (var i = 0; i < data.length; i++) {
                eventDates[new Date(data[i])] = new Date(data[i]);
            }

            // datepicker
            if ($('#datepicker').val() != "") {
                $('#datepicker').datepicker("destroy");;
            }

            $('#datepicker').datepicker({
                destroy: true,
                beforeShowDay: function (date) {
                    var highlight = eventDates[date];
                    if (highlight) {
                        return [true, 'fechaIncidente'];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", new Date());
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con datepicker en vista incidente.');
            $("#modal-alerta").modal("show");
            //alert('Problemas con datepicker en vista proceso.');
        }
    });
}


function obtenerOPI() {
    var modal = document.getElementById('myModal');
    modal.style.display = "block";

    fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    $.ajax({
        type: 'POST',
        url: '/Incidente/ObtenerOPIDia',
        data: {
            'Fecha': fecha
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            modal.style.display = "none";
            if (data.validacion == true) {
                var OPIDia = data.opiDia;
                //console.log(OPIDia);
                tablaOPI(OPIDia);
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Aún no existen incidentes para la fecha " + fecha);
                $("#modal-alerta").modal("show");

                $('#OPI').DataTable();
            }
        },
        error: function () {
            modal.style.display = "none";
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas en la funcion obtenerOPI en vista incidente.');
            $("#modal-alerta").modal("show");
        }
    });
    //resetear();
}

function tablaOPI(OPI) {
    $('#OPI').DataTable({
        'data': OPI,
        'order': [[5, "asc"]],
        'columns': [
            { "data": "codigoCorto" },
            { "data": "codigoLargo" },
            { "data": "tiempo" },
            { "data": "clasificacion" },
            { "data": "aclaracion" },
            { "data": "zona" },
            { "data": "cantIncidentes" },
            {
                "render": function(data, type, full, meta) {
                    if (full.cantIncidentes != 0) {
                        return '<button class="btn btn-success" onclick="ver(' + full.codigoCorto + ')" title="Ver incidente"><div><i class="glyphicon glyphicon-eye-open"></i></div></button>';
                    }
                    return '';
                }
            }
        ]
    });

}

function ver(id) {
    window.location.href = "/Incidente/DetalleIncidente/?Id=" + id + "&Fecha=" + fecha;
}




/**
 * Obtiene las incidencias de la base de datos para ser seleecionable al momento de registrar una de estas a las ordenes
 * */
function obtenerInicidencias() {
    $.ajax({
        type: 'POST',
        url: '/Incidente/LeerOPI',
        async: 'false',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data) {
            console.log(data)
            if (data.length != 0) {
                incidentes = data;
            }
        }
    });
}

/**
 * Muestra los componentes del modal de registro de incidente segun el tipo, si es por código o por formulario.
 * */
function tipoIngresoIncidencia() {
    var tipoIncidenteSelect = document.getElementById("opcionIncidencia");
    var tipoIncidente = tipoIncidenteSelect.options[tipoIncidenteSelect.selectedIndex].value;

    var codigoIncidencia = document.getElementById('codigoIncidenciadiv');
    var descripcionIncidente1 = document.getElementById('descripcionIncidente1');
    var tiempo = document.getElementById('tiempodiv');
    var clasificacion = document.getElementById('clasificaciondiv');
    var descripcionIncidente2 = document.getElementById('descripcionIncidente2');
    //var observacion = document.getElementById('observaciondiv');

    if (tipoIncidente == 1) {
        codigoIncidencia.style.display = 'block';
        descripcionIncidente1.style.display = 'block';
        tiempo.style.display = 'none';
        clasificacion.style.display = 'none';
        descripcionIncidente2.style.display = 'none';

    }
    else {
        codigoIncidencia.style.display = 'none';
        descripcionIncidente1.style.display = 'none';
        tiempo.style.display = 'block';
        clasificacion.style.display = 'block';
        descripcionIncidente2.style.display = 'block';
    }
    iniciarSelectPrincipalesIncidentes();
    resetearDatosIncidencia();
    $('#clasificacion').empty();
    $('#clasificacion').append('<option disabled selected value="-1">Seleccione la clasificación</option>');
    //observacion.style.display = 'none';
}

/**
 * Inicializa los select principales del modal incidencias. Estos son #condigoIncidencia para cuando el usuario seleccione que desea buscar la incidencia directa 
 * por el codigo corto y #tiempo que es el select de las agrupaciones de tiempo
 * */
function iniciarSelectPrincipalesIncidentes() {
    $('#codigoIncidencia').empty();
    $('#codigoIncidencia').append('<option disabled selected value="-1">Seleccione el código de la incidencia</option>');

    for (var i = 0; incidentes != "" && i < incidentes.length; i++) {
        $('#codigoIncidencia').append("<option  value='" + incidentes[i]["idIncidente"] + "'>" + incidentes[i]["idIncidente"] + "</option>");
    }

    var agrupacionTiempo = [];
    var idAgrupacionAux = [];
    for (var i = 0; incidentes != "" && i < incidentes.length; i++) {
        if (agrupacionTiempo.length != 0) {
            idAgrupacionAux = agrupacionTiempo.filter(agrupacion => agrupacion.idAgrupacionTiempo == incidentes[i]["idAgrupacionTiempo"]);
            if (idAgrupacionAux.length == 0) {
                agrupacionTiempo.push({
                    'idAgrupacionTiempo': incidentes[i]["idAgrupacionTiempo"],
                    'nombreAgrupacionTiempo': incidentes[i]["nombreAgrupacionTiempo"]
                });
            }
        }
        else {
            agrupacionTiempo.push({
                'idAgrupacionTiempo': incidentes[i]["idAgrupacionTiempo"],
                'nombreAgrupacionTiempo': incidentes[i]["nombreAgrupacionTiempo"]
            });
        }
    }

    $('#tiempo').empty();
    $('#tiempo').append('<option disabled selected value="-1">Seleccione el tipo de tiempo</option>');

    for (var i = 0; agrupacionTiempo != "" && i < agrupacionTiempo.length; i++) {
        $('#tiempo').append("<option  value='" + agrupacionTiempo[i]["idAgrupacionTiempo"] + "'>" + agrupacionTiempo[i]["nombreAgrupacionTiempo"] + "</option>");
    }
}

function mostrarIncidenciaCodigo() {
    var codigoIncidenciaSelec = document.getElementById("codigoIncidencia");
    var codigoIncidente = codigoIncidenciaSelec.options[codigoIncidenciaSelec.selectedIndex].value;
    incidenteSeleccionado = incidentes.filter(incidente => incidente.idIncidente == codigoIncidente);

    document.getElementById("nombreAgrupacionTiempo1").innerHTML = incidenteSeleccionado[0]["nombreAgrupacionTiempo"];
    document.getElementById("descripcionClasificacion1").innerHTML = incidenteSeleccionado[0]["descripcionClasificacion"];
    document.getElementById("aclaracionClasificacion1").innerHTML = incidenteSeleccionado[0]["aclaracionClasificacion"];
    document.getElementById("nombreZona1").innerHTML = incidenteSeleccionado[0]["nombreZona"];
}


function iniciarSelectClasificacionIncidencia() {
    var idTiempoIncidenciaSelect = document.getElementById("tiempo");
    var idTiempo = idTiempoIncidenciaSelect.options[idTiempoIncidenciaSelect.selectedIndex].value;
    var clasificacionInicidentes = incidentes.filter(incidente => incidente.idAgrupacionTiempo == idTiempo);

    $('#clasificacion').empty();
    $('#clasificacion').append('<option disabled selected value="-1">Seleccione la clasificación</option>');

    for (var i = 0; i < clasificacionInicidentes.length; i++) {
        if (clasificacionInicidentes[i]["descripcionClasificacion"] == "Transporte") {
            $('#clasificacion').append("<option  value='" + clasificacionInicidentes[i]["idClasificacion"] + "'>" + clasificacionInicidentes[i]["descripcionClasificacion"] + " - " + clasificacionInicidentes[i]["nombreZona"] + "</option>");
        }
        else {
            $('#clasificacion').append("<option  value='" + clasificacionInicidentes[i]["idClasificacion"] + "'>" + clasificacionInicidentes[i]["descripcionClasificacion"] + "</option>");

        }
    }
    resetearDatosIncidencia();
}

function mostrarIncidenciaCodigo1() {
    var agrupacionTiempoIncidenciaSelect = document.getElementById("tiempo");
    var idAgrupacionTiempoIncidencia = agrupacionTiempoIncidenciaSelect.options[agrupacionTiempoIncidenciaSelect.selectedIndex].value;

    var clasificacionInicdenteSelect = document.getElementById("clasificacion");
    var idClasificacionInicdente = clasificacionInicdenteSelect.options[clasificacionInicdenteSelect.selectedIndex].value;

    incidenteSeleccionado = incidentes.filter(incidente => incidente.idAgrupacionTiempo == idAgrupacionTiempoIncidencia && incidente.idClasificacion == idClasificacionInicdente);

    document.getElementById("aclaracionClasificacion2").innerHTML = incidenteSeleccionado[0]["aclaracionClasificacion"];
    document.getElementById("nombreZona2").innerHTML = incidenteSeleccionado[0]["nombreZona"];
}

function resetearDatosIncidencia() {
    document.getElementById("nombreAgrupacionTiempo1").innerHTML = "-";
    document.getElementById("descripcionClasificacion1").innerHTML = "-";
    document.getElementById("aclaracionClasificacion1").innerHTML = "-";
    document.getElementById("nombreZona1").innerHTML = "-";
    document.getElementById("aclaracionClasificacion2").innerHTML = "-";
    document.getElementById("nombreZona2").innerHTML = "-";
    document.getElementById("observacion").value = "";
}

$('#btnAgregarIncidencia').click(function () {
    resetearDatosIncidencia();
    tipoIngresoIncidencia();
    iniciarSelectPrincipalesIncidentes();
    $("#modal-agregar-incidencia").modal("show");
});

$('#btnConfirmarIncidencia').click(function () {
    if (incidenteSeleccionado.length != 0) {
        var datos = "";

        if ($("#observacion").val() != "") {
            datos = {
                'IdIncidente': incidenteSeleccionado[0]["idIncidente"],
                'FechaHoraInicio': moment(new Date()).format('YYYY-MM-DD HH:mm:ss'),
                'Observacion': $("#observacion").val(),
            };
        }
        else {
            datos = {
                'IdIncidente': incidenteSeleccionado[0]["idIncidente"],
                'FechaHoraInicio': moment(new Date()).format('YYYY-MM-DD HH:mm:ss'),
                'Observacion': 'Sin Observación',
            };
        }
        registrarIncidencia(datos);
        $("#modal-agregar-incidencia").modal("hide");
        resetearDatosIncidencia();
        incidenteSeleccionado = "";
    }
    else {
        $('#title-alert').text("Alerta");
        $('#body-alert').text("Existen campos incompletos. Favor de completar el formulario de incidencia.");
        $("#modal-alerta").modal("show");
    }
});

function registrarIncidencia(datos) {
    //console.log(datos);
    $.ajax({
        url: "/Incidente/RegistrarIncidencia",
        method: "POST",
        async: "false",
        data: datos,
        success: function (data) {
            //console.log(data);
            if (data.registroExitoso) {
                $('#title-confirm').text(data.titulo);
                $('#body-confirm').text(data.contenido);
                $("#modal-confirm").modal("show");
                obtenerOPI();
            }
            else {
                $('#title-alert').text(data.titulo);
                $('#body-alert').text(data.contenido);
                $("#modal-alerta").modal("show");
            }
        }
    });
}

