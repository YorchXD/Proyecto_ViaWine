var ordenes = "";
var incidentes = "";
var incidenteSeleccionado = "";
var fecha = "";
var modal = "";
var cantCajasPlanAux = 0;
var cantCajasAux=0

$('#btnInicio').click(function () { exist_proces_ini(1); });
$('#btnInicioProceso').click(function () {
    var ordenSelect = document.getElementById("numeroOrden");
    var idOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    Finalizar_Incidencia(idOrden);
    Actualizar_Estado(1);
});
$('#btnPausar').click(function () {
    exist_proces_ini(2);
});
$('#btnPausarProceso').click(function () {
    Actualizar_Estado(2);
});
$('#btnPosponer').click(function () { exist_proces_ini(3); });
$('#btnPosponerProceso').click(function () {
    var ordenSelect = document.getElementById("numeroOrden");
    var idOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    Finalizar_Incidencia(idOrden);
    Actualizar_Estado(3);
});
$('#btnFinalizar').click(function () { exist_proces_ini(4); });
$('#btnFinalizarProceso').click(function () {
    var ordenSelect = document.getElementById("numeroOrden");
    var idOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    Finalizar_Incidencia(idOrden);
    Actualizar_Estado(4);
});
$('#btnConfirm').click(function () {
    estado = "";
    location.reload();
});

$('#btnConfirmarIncidencia').click(function () {
    if (incidenteSeleccionado.length != 0) {
        //console.log(incidenteSeleccionado);

        var ordenSelect = document.getElementById("numeroOrden");
        var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;

        var orden = ordenes.filter(orden => orden.id == numeroOrden);
        //console.log(orden[0]);
        var estadoOrden = ""

        switch (orden[0]["estado"]) {
            case 2:
                estadoOrden = "Pausada";
                break;
            case 3:
                estadoOrden = "Pospuesta";
                break;
        }

        var datos = "";
        var progresoOrden = parseFloat((cantCajasAux / cantCajasPlanAux) * 100).toFixed(2).replace(".", ",");
        //var progresoOrden = Number(((cantCajasAux / cantCajasPlanAux) * 100).toFixed(2));
        //console.log(progresoOrden);

        if ($("#observacion").val() != "") {
            datos = {
                'IdOrden': numeroOrden,
                'IdIncidente': incidenteSeleccionado[0]["idIncidente"],
                'EstadoOrden': estadoOrden,
                'FechaHoraInicio': moment(new Date()).format('YYYY-MM-DD HH:mm:ss'),
                'Observacion': $("#observacion").val()
            };
        }
        else {
            datos = {
                'IdOrden': numeroOrden,
                'IdIncidente': incidenteSeleccionado[0]["idIncidente"],
                'EstadoOrden': estadoOrden,
                'FechaHoraInicio': moment(new Date()).format('YYYY-MM-DD HH:mm:ss'),
                'Observacion': 'Sin Observación',
                'Progreso': progresoOrden,
            };
        }
        registrarIncidencia(datos);
        $("#modal-Incidencia").modal("hide");
        resetearDatosIncidencia();
        incidenteSeleccionado = "";

        /*if (incidenteSeleccionado[0]["reqObservacion"] == 'No') {
            datos = {
                'IdOrden': numeroOrden,
                'IdIncidente': incidenteSeleccionado[0]["idIncidente"],
                'EstadoOrden': estadoOrden,
                'FechaHoraInicio': moment(new Date()).format('YYYY-MM-DD HH:mm:ss'),
                'Observacion': 'Sin Observación',
                'Progreso': progresoOrden,
            };
            //console.log(datos);
            registrarIncidencia(datos);
            $("#modal-Incidencia").modal("hide");
            resetearDatosIncidencia();
            incidenteSeleccionado = "";
            
        }
        else {
            if ($("#observacion").val() != "") {
                datos = {
                    'IdOrden': numeroOrden,
                    'IdIncidente': incidenteSeleccionado[0]["idIncidente"],
                    'EstadoOrden': estadoOrden,
                    'FechaHoraInicio': moment(new Date()).format('YYYY-MM-DD HH:mm:ss'),
                    'Observacion': $("#observacion").val()
                };
                registrarIncidencia(datos);
                $("#modal-Incidencia").modal("hide");
                resetearDatosIncidencia();
                incidenteSeleccionado = "";
                //console.log(datos);
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Existen campos incompletos. Favor de completar el formulario de incidencia.");
                $("#modal-alerta").modal("show");
            }
        }*/
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
        url: "/Proceso/RegistrarIncidencia",
        method: "POST",
        async: "false",
        data: datos,
        success: function (data) {
            //console.log(data);
            if (data.registroExitoso) {

                if (document.getElementById('modal-header-confirm').classList.contains('bg-orange')) {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-orange');

                }
                else if (document.getElementById('modal-header-confirm').classList.contains('bg-maroon')) {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-maroon');
                }

                if (datos.EstadoOrden == "Pausada") {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-orange');
                    //$("#modal-pausar").modal('hide');
                    $('#title-confirm').text("Pausar proceso");
                    $('#body-confirm').text('El proceso se ha pausado correctamente');
                    $("#modal-confirm").modal("show");
                }
                else if (datos.EstadoOrden == "Pospuesta") {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-maroon');
                    //$("#modal-posponer").modal('hide');
                    $('#title-confirm').text("Posponer proceso");
                    $('#body-confirm').text('El proceso se ha pospueto correctamente');
                    $("#modal-confirm").modal("show");
                }
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("No se ha registrado la incidencia correctamente. Intentelo nuevamente.");
                $("#modal-alerta").modal("show");
            }
        }
    });
}

/**
 * Funcion que ingresa fecha y hora de termino de una incidencia en caso de que exista una sin terminar
 * @param {any} IdOrden
 */
function Finalizar_Incidencia(IdOrden) {
    $.ajax({
        url: "/Proceso/FinalizarIncidencia",
        method: "POST",
        async: "false",
        data: {
            "IdOrden": IdOrden,
            'FechaHoraTermino': moment(new Date()).format('YYYY-MM-DD HH:mm:ss')
        },
        success: function (data) {
            if (data == 1) {
                console.log("Si la orden ha estado pospuesta o pausada, se ha registrado el tiempo en que finalizó en caso contrario, como existia incidencia");
            }
            else if (data == -1) {
                console.log("Existe un proble al momento de registrar el fin de la incidencia en caso de que la orden se encontrara pospuesta o pausada.")
            }
        }
    });
}

/**
 * Obtiene las incidencias de la base de datos para ser seleecionable al momento de registrar una de estas a las ordenes
 * */
function obtenerInicidencias() {
    $.ajax({
        type: 'POST',
        url: '/Proceso/LeerIncidencias',
        async: 'false',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data) {
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

    /*var observacion = document.getElementById('observaciondiv');
    if (incidenteSeleccionado[0]["reqObservacion"] == "Si") {
        observacion.style.display = 'block';
    }
    else {
        observacion.style.display = 'none';
    }*/
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
    /*var observacion = document.getElementById('observaciondiv');
    observacion.style.display = 'none';*/
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

    /*var observacion = document.getElementById('observaciondiv');
    if (incidenteSeleccionado[0]["reqObservacion"] == "Si") {
        observacion.style.display = 'block';
    }
    else {
        observacion.style.display = 'none';
    }*/
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

/**
 * Se encarga de actualizar el estado de una orden en particular
 * @param {int} estado
 */
function Actualizar_Estado(estado)
{
    var idOrden = $("#numeroOrden").val();
    var fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var datos = {
        //'OrdenFabricacion': orden,
        'Id': idOrden,
        'Estado': estado,
        'Fecha': fecha
    };
    $.ajax(
        {
            url: '/Proceso/ActualizarEstadoProceso',
            data: datos,
            datatype: "json",
            async:'false',
            type: 'POST',
            success: function (data) {

                if (document.getElementById('modal-header-confirm').classList.contains('bg-purple')) {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-purple');
                }
                else if (document.getElementById('modal-header-confirm').classList.contains('bg-orange')) {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-orange');

                }
                else if (document.getElementById('modal-header-confirm').classList.contains('bg-maroon')) {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-maroon');
                }
                else if (document.getElementById('modal-header-confirm').classList.contains('bg-olive')) {
                    document.getElementById('modal-header-confirm').classList.toggle('bg-olive');
                }

                switch (estado) {
                    case 1:
                        document.getElementById('modal-header-confirm').classList.toggle('bg-purple');
                        $('#modal-inicio').modal('hide');
                        $('#title-confirm').text("Iniciar proceso");
                        $('#body-confirm').text('El proceso se ha iniciado correctamente');
                        $("#modal-confirm").modal("show");
                        break;
                    case 2:
                        for (var i = 0; i < ordenes.length; i++) {
                            if (ordenes[i]["id"] == idOrden) {
                                ordenes[i]["estado"] = 2;
                                break;
                            }
                        }
                        $("#modal-pausar").modal('hide');
                        resetearDatosIncidencia();
                        tipoIngresoIncidencia();
                        iniciarSelectPrincipalesIncidentes();

                        if (document.getElementById('modal-header-incicente').classList.contains('bg-maroon')) {
                            document.getElementById('modal-header-incicente').classList.toggle('bg-maroon');
                        }

                        if (!document.getElementById('modal-header-incicente').classList.contains('bg-orange')) {
                            document.getElementById('modal-header-incicente').classList.toggle('bg-orange');
                        }

                        $("#modal-Incidencia").modal("show");
                        break;
                    case 3:
                        for (var i = 0; i < ordenes.length; i++) {
                            if (ordenes[i]["id"] == idOrden) {
                                ordenes[i]["estado"] = 3;
                                break;
                            }
                        }
                        $("#modal-posponer").modal('hide');
                        resetearDatosIncidencia();
                        tipoIngresoIncidencia();
                        iniciarSelectPrincipalesIncidentes();

                        if (document.getElementById('modal-header-incicente').classList.contains('bg-orange')) {
                            document.getElementById('modal-header-incicente').classList.toggle('bg-orange');
                        }

                        if (!document.getElementById('modal-header-incicente').classList.contains('bg-maroon')) {
                            document.getElementById('modal-header-incicente').classList.toggle('bg-maroon');
                        }

                        $("#modal-Incidencia").modal("show");
                        
                        break;
                    default:
                        document.getElementById('modal-header-confirm').classList.toggle('bg-olive');
                        $("#modal-finalizar").modal('hide');
                        $('#title-confirm').text("Finalizar proceso");
                        $('#body-confirm').text('El proceso se ha finalizado correctamente');
                        $("#modal-confirm").modal("show");
                        break;
                }
                
            },
            error: function () {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("El proceso no se ha iniciado correctamente. Intentelo mas tarde.");
                $("#modal-alerta").modal("show");
            }
        });
}

/**
 * Dada la accion a ejecutar sobre una orden, se verifica si es posible realizarlo
 * @param {int} tipoAccion
 */
function exist_proces_ini(tipoAccion)
{
    var idOrden = $("#numeroOrden").val();
    if (idOrden == null) {
        idOrden = -1;
    }
    var datos = {
        'IdOrden': idOrden,
        'OpcionAccion': tipoAccion
    };
    $.ajax(
    {
        url: '/Proceso/Exit_proces_ini',
        data: datos,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        type: 'GET',
        success: function (data)
        {
            if (data.existeProceso)
            {
                switch (tipoAccion)
                {
                    case 1:
                        $('#title-ini-process').text(data.titulo);
                        $('#body-ini-process').text(data.contenido);
                        $("#modal-inicio").modal("show");
                        break;
                    case 2:
                        $('#title-pause-process').text(data.titulo);
                        $('#body-pause-process').text(data.contenido);
                        $("#modal-pausar").modal("show");
                        break;
                    case 3:
                        $('#title-postpone-process').text(data.titulo);
                        $('#body-postpone-process').text(data.contenido);
                        $("#modal-posponer").modal("show");
                        break;
                    default:
                        $('#title-finalize-process').text(data.titulo);
                        $('#body-finalize-process').text(data.contenido);
                        $("#modal-finalizar").modal("show");
                        break;
                }
            }
            else
            {
                $('#title-alert').text(data.titulo);
                $('#body-alert').text(data.contenido);
                $("#modal-alerta").modal("show");
            }
        },
        error: function ()
        {
            $('#title-alert').text("Alerta");
            $('#body-alert').text("Error inesperado, vuelva a intentarlo más tarde o contáctese con Tibox para informar en detalle cuando ocurrió el error.");
            $("#modal-alerta").modal("show");
            //alert("Error inesperado, vuelva a intentarlo más tarde o contáctese con Tibox para informar en detalle cuando ocurrió el error.");
        },
    });
}

function mostrarOrden()
{
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    if (ordenes != null) {
        var orden = ordenes.filter(orden => orden.id == numeroOrden);
        Orden(orden[0]);
    }
}

function Orden(modelo)
{
    document.getElementById("SKU").innerHTML = modelo["sku"];
    document.getElementById("descripcionProducto").innerHTML = modelo["descripcion"];
    document.getElementById("cantCajasPlan").innerHTML = modelo["cajasPlanificadas"];
    document.getElementById("cantBotellasPlan").innerHTML = modelo["botellasPlanificadas"];
    var fechaHoraInicio = moment(new Date(modelo["fechaHoraInicio"])).format('YYYY-MM-DD HH:mm:ss');
    var fechaHoraTermino = moment(new Date(modelo["fechaHoraTermino"])).format('YYYY-MM-DD HH:mm:ss');
    if (fechaHoraInicio != '2020-01-01 00:00:00') {
        document.getElementById("fechaHoraInicio").innerHTML = fechaHoraInicio;
    }
    else {
        document.getElementById("fechaHoraInicio").innerHTML = '-';
    }

    if (fechaHoraTermino != '2020-01-01 00:00:00') {
        document.getElementById("fechaHoraTermino").innerHTML = fechaHoraTermino;
    }
    else {
        document.getElementById("fechaHoraTermino").innerHTML = '-';
    }

    document.getElementById("fechaPlan").innerHTML = (modelo["fechaFabricacion"]).split('T')[0];
    document.getElementById("formatoCaja").innerHTML = modelo["formatoCaja"];
    switch (modelo["estado"]) {
        case 0:
            document.getElementById("estado").innerHTML = 'No iniciada';
            break;
        case 1:
            document.getElementById("estado").innerHTML = 'Iniciada';
            break;
        case 2:
            document.getElementById("estado").innerHTML = 'Pausada';
            break;
        case 3:
            document.getElementById("estado").innerHTML = 'Pospuesta';
            break;
        default:
            document.getElementById("estado").innerHTML = 'Finalizada';
    }
    monitoreo(modelo["id"], modelo["botellasPlanificadas"], modelo["cajasPlanificadas"], modelo["formatoCaja"]);
}



/**
 * Ayuda a obtener la cantidad de cajas y botellas para insertarla en los indicadores correspondiente. Ademas ayuda a la creacion de las tablas que 
 * muestran los registros de cajas y botelllas. Para ello obtiene un listado de botellas y cajas para luego separarlo en dos lista y enviarlo a las
 * funciones encargadas completar los indicadores de cantidad de botellas y cajas y al las tablas de registros de botellas y cajas
 * @param {int} idOrden
 * @param {int} botellasPlan
 * @param {int} cajasPlan
 */
function monitoreo(idOrden, botellasPlan, cajasPlan, formato)
{
    var datos = {
        'IdOrden': idOrden
    };
    $.ajax({
        url: "/Proceso/GetMonitoreoMateriales",
        method: "POST",
        data: datos,
        success: function (data) {
            
            var botellas = {};
            var cajas = {};
            var cantBotellas = 0;
            var cantCajas = 0;
            var botellasEquiv = 0;
            var cantBotellasCajas = parseInt(formato.split("x")[0]);
            if (Object.entries(data).length != 0) {
                botellas = data.filter(element => element.tipo == "Botella");
                cajas = data.filter(element => element.tipo == "Caja");
                cantBotellas = botellas.length;
                cantCajas = cajas.length;
                botellasEquiv = cantCajas * cantBotellasCajas
            }

            cantCajasAux = cantCajas;
            cantCajasPlanAux = cajasPlan;

            indicadorCantBotellas1(cantBotellas, botellasPlan);
            indicadorCantCajas1(cantCajas, cajasPlan);
            indicadorCantBotellasEquiv1(botellasEquiv, botellasPlan);
            indicadorVelocidadPorMin(idOrden, 'botella');
            indicadorVelocidadPorMin(idOrden, 'caja');
            monitoreoBotellas1(botellas);
            monitoreoCajas1(cajas);
        }
    })
}

/**
 * Redondea un numero decimal dejandolo con dos decimales
 * @param {float} num
 */
function roundToTwo(num) {
    return +(Math.round(num + "e+2") + "e-2");
}

/**
 * Inserta la cantidad de botellas y el porcentaje de avance que hay segun lo planificado en el indicador de botellas
 * @param {int} cantBotellas
 * @param {int} botellasPlan
 */
function indicadorCantBotellas1(cantBotellas, botellasPlan)
{
    porcentaje = roundToTwo((cantBotellas * 100.0) / botellasPlan);
    document.getElementById("cantBotellas").innerHTML = cantBotellas;
    document.getElementById("progresoBotellas").innerHTML = "<div class='progress-bar' style='width:" + porcentaje + "%'></div>";
    document.getElementById("porcentBotellas").innerHTML = "" + porcentaje + "% de avance";
}

/**
 * Inserta la cantidad de cajas y el porcentaje de avance que hay segun lo planificado en el indicador de cajas
 * @param {int} cantCajas
 * @param {int} cajasPlan
 */
function indicadorCantCajas1(cantCajas, cajasPlan) {
    porcentaje = roundToTwo((cantCajas * 100.0) / cajasPlan);
    document.getElementById("cantCajas").innerHTML = cantCajas;
    document.getElementById("progresoCajas").innerHTML = "<div class='progress-bar' style='width:" + porcentaje + "%'></div>";
    document.getElementById("porcentCajas").innerHTML = "" + porcentaje + "% de avance";
}

/**
 * Inserta la cantidad de botellas equivalentes respecto a la cantidad de cajas contabilizadas segun lo planificado
 * @param {any} cantBotellasEquiv
 * @param {any} botellasPlan
 */
function indicadorCantBotellasEquiv1(cantBotellasEquiv, botellasPlan) {
    porcentaje = roundToTwo((cantBotellasEquiv * 100.0) / botellasPlan);
    document.getElementById("cantBotellasEquiv").innerHTML = cantBotellasEquiv;
    document.getElementById("progresoBotellasEquiv").innerHTML = "<div class='progress-bar' style='width:" + porcentaje + "%'></div>";
    document.getElementById("porcentBotellasEquiv").innerHTML = "" + porcentaje + "% de avance";
}

function indicadorVelocidadPorMin(idOrden, tipoMaterial) {
    var datos = {
        'IdOrden': idOrden,
        'TipoMaterial': tipoMaterial
    };
    $.ajax({
        url: "/Proceso/GetVelocidadPorMin",
        method: "POST",
        data: datos,
        success: function (data)
        {
            if (tipoMaterial == "botella") {
                document.getElementById("cantBotellasMin").innerHTML = data;
            }
            else {
                document.getElementById("cantCajasMin").innerHTML = data;
            }
            
        }
    })
}

function monitoreoBotellas1(botellas) {

    $('#tablaBotellas').DataTable({
        'data': botellas,
        'order': [[0, "desc"]],
        'columns': [
            { "data": "id"},
            {
                "data": "fechaHora", render: function (d) {
                    return moment(d).format("YYYY-MM-DD HH:mm:ss");
                }},
        ]
    });
}

/**
 * Obtiene la hora actual y la convierte en un formato estandarizado hh:mm
 * */
function obtenerHora() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();

    if (h < 10) {
        h = '0' + h;
    }

    if (m < 10) {
        m = '0' + m;
    }
    return h + ":" + m;
}

/**
 * Obtiene la fecha actual y la convierte en formato estandarizado YYYY-MM-DD
 * */
function fechaActual() {
    var fecha = new Date();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();

    var output = fecha.getFullYear() + '-'
        + (mes < 10 ? '0' : '') + mes + '-'
        + (dia < 10 ? '0' : '') + dia;

    return output;
}

function monitoreoCajas1(cajas) {

    $('#tablaCajas').DataTable({
        'data': cajas,
        'order': [[0, "desc"]],
        'columns': [
            { "data": "id" },
            {
                "data": "fechaHora", render: function (d) {
                    return moment(d).format("YYYY-MM-DD HH:mm:ss");
                }},
        ],
    });
}


function fechasOrdenes(fechaEnviada) {
    var fechaAux;
    $.ajax({
        type: 'POST',
        url: '/Proceso/ObtenerFecha',
        data: {'Opcion': 1},
        dataType: 'json',
        async: false,
        success: function (data) {
            // An array of dates
            var eventDates = {};
            var valFechaFuturaDefault = 0;
            var parts = fechaEnviada.split('-');
            fechaAux = new Date(parts[0], parts[1] - 1, parts[2]);

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
                        return [true, 'ordenesDia'];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", fechaAux);
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con datepicker en vista proceso.');
            $("#modal-alerta").modal("show");
            //alert('Problemas con datepicker en vista proceso.');
        }
    });
}

function iniciarOrdenesSelect(ordenes) {
    $('#numeroOrden').empty();
    $('#numeroOrden').append('<option disabled selected value="-1">Seleccione una orden</option>');

    for (var i = 0; ordenes != null && i < ordenes.length; i++) {
        if (ordenes[i]["estado"] == 1 || ordenes[i]["estado"] == 2) {
            $('#numeroOrden').append("<option value='" + ordenes[i]["id"] + "'selected>" + ordenes[i]["ordenFabricacion"] + "</option >");
            Orden(ordenes[i]);
        }
        else {
            $('#numeroOrden').append("<option  value='" + ordenes[i]["id"] + "'>" + ordenes[i]["ordenFabricacion"] + "</option>");
        }
    }
}

function resetear() {
    $('#numeroOrden').empty();
    $('#numeroOrden').append('<option disabled selected value="-1">Seleccione una orden</option>');

    document.getElementById("SKU").innerHTML = "-";
    document.getElementById("descripcionProducto").innerHTML = "-";
    document.getElementById("cantCajasPlan").innerHTML = "-";
    document.getElementById("cantBotellasPlan").innerHTML = "-";
    document.getElementById("fechaHoraInicio").innerHTML = "-";
    document.getElementById("fechaHoraTermino").innerHTML = "-";
    document.getElementById("fechaPlan").innerHTML = "-";
    document.getElementById("formatoCaja").innerHTML = "-";
    document.getElementById("estado").innerHTML = "-";
    var cantTablaBotella = $('#tablaBotellas').DataTable().page.info().recordsTotal;
    var cantTablaCajas = $('#tablaCajas').DataTable().page.info().recordsTotal;

    document.getElementById("cantBotellas").innerHTML = "-";
    document.getElementById("progresoBotellas").innerHTML = "<div class='progress-bar' style='width:" + 0 + "%'></div>";
    document.getElementById("porcentBotellas").innerHTML = "-% de avance";

    document.getElementById("cantCajas").innerHTML = "-";
    document.getElementById("progresoCajas").innerHTML = "<div class='progress-bar' style='width:" + 0 + "%'></div>";
    document.getElementById("porcentCajas").innerHTML = "-% de avance";

    document.getElementById("cantBotellasEquiv").innerHTML = "-";
    document.getElementById("progresoBotellasEquiv").innerHTML = "<div class='progress-bar' style='width:" + 0 + "%'></div>";
    document.getElementById("porcentBotellasEquiv").innerHTML = "-% de avance";

    document.getElementById("cantBotellasMin").innerHTML = "-";
    document.getElementById("cantCajasMin").innerHTML = "-";

    if (cantTablaBotella > 0) {
        $('#tablaBotellas').DataTable().clear();
        $('#tablaBotellas').DataTable().destroy();
    }

    if (cantTablaCajas > 0) {
        $('#tablaCajas').DataTable().clear();
        $('#tablaCajas').DataTable().destroy();
    }
}

function obtenerOrdenes() {
    modal = document.getElementById('myModal');
    modal.style.display = "block";

    var fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var tipo = 1;
    $.ajax({
        type: 'POST',
        url: '/Proceso/GetOrdenes',
        data: {
            'Tipo': tipo,
            'Fecha': fecha
        },
        dataType: 'json',
        //async: false,
        success: function (data) {
            modal.style.display = "none";
            if (data.validacion == true) {
                ordenes = data.ordenes;
                iniciarOrdenesSelect(data.ordenes);
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Aun no existen ordenes para la fecha " + fecha);
                $("#modal-alerta").modal("show");

                $('#tablaBotellas').DataTable();
                $('#tablaCajas').DataTable();
            }
        },
        error: function () {
            modal.style.display = "none";
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas en la funcion obtenerOrdenes en vista proceso.');
            $("#modal-alerta").modal("show");
        }
    });
    resetear();
}

function obtenerOrdenesAbiertas() {
    modal = document.getElementById('myModal');
    modal.style.display = "block";
    $.ajax({
        type: 'POST',
        url: '/Proceso/LeerOrdenesAbiertas',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data)
        {
            modal.style.display = "none";
            if (data.length != 0)
            {
                mostrarOrdenDefault(data);
            }
            else
            {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Aun no existen ordenes abiertas para la fecha " + fecha);
                $("#modal-alerta").modal("show");
            }
            
        },
        error: function () {
            modal.style.display = "none";
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas en la funcion obtenerOrdenesAbiertas en vista proceso.');
            $("#modal-alerta").modal("show");
        }
    });
}

function mostrarOrdenDefault(datos) {
    fecha = "";
    for (var i = 0; i < datos.length; i++) {
        if (datos[i]["estado"] == 1 || datos[i]["estado"] == 2) {
            fecha = (datos[i]["fechaFabricacion"]).split('T')[0];
        }
    }

    if (fecha == "") {
        fecha = fechaActual();
    }

    ordenes = datos.filter(orden => (orden.fechaFabricacion).split('T')[0] == fecha);
    fechasOrdenes(fecha);
    if (ordenes.length == 0) {
        $('#title-alert').text("Alerta");
        $('#body-alert').text("Aun no existen ordenes abiertas para la fecha " + fecha);
        $("#modal-alerta").modal("show");

    }
    else {
        iniciarOrdenesSelect(ordenes);
    }
}

function obtenerOrdenesAbiertasActualizadas() {
    $.ajax({
        type: 'POST',
        url: '/Proceso/LeerOrdenesAbiertas',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.length != 0) {
                fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
                ordenes = data.filter(orden => (orden.fechaFabricacion).split('T')[0] == fecha);
            }
        }
    });
}

function actualizarTablasMonitoreo()
{
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;

    if ((ordenes != null || ordenes != "" || typeof ordenes != 'undefined') && ordenes.length > 0 && numeroOrden!='-1' ) {
        var orden = ordenes.filter(orden => orden.estado == 1 && orden.id == numeroOrden);
        obtenerOrdenesAbiertasActualizadas();
        var ordenAux = ordenes.filter(orden => orden.id == numeroOrden);
        if (orden.length != 0 && ordenAux.length != 0) {
            if (ordenAux[0].estado != orden[0].estado) {
                location.reload();
            }
            else {
                monitoreo(numeroOrden, orden[0]["botellasPlanificadas"], orden[0]["cajasPlanificadas"], orden[0]["formatoCaja"]);
            }
        }
        /*else if (ordenAux.length != 0) {
            location.reload();
        }*/
    }
    document.getElementById("horaActualizacionIndicadoresOrden").innerHTML = obtenerHora();
}
setInterval(actualizarTablasMonitoreo, 60000);

var moviendo = false;
$(document).on('mousemove', function () {
    moviendo = true;
});

function actualizarPagina() {
    if (!moviendo) {
        // No ha habido movimiento desde 50 un segundo
        var ordenSelect = document.getElementById("numeroOrden");
        var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
        if (numeroOrden == '-1') {
            location.reload();
        }
    }
    else {
        moviendo = false;
    }
}
setInterval(actualizarPagina, 60000 * 2);