var ordenes = "";
var fecha = "";
var modal = "";

/**
 * Se encarga de actualizar el estado de una orden en particular
 * @param {int} estado
 */
function Actualizar_Estado(estado)
{
    var orden = $("#numeroOrden").val();
    var fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var datos = {
        'OrdenFabricacion': orden,
        'Estado': estado,
        'Fecha': fecha
    };
    $.ajax(
        {
            url: '/Proceso/ActualizarEstadoProceso',
            data: datos,
            //contentType: "application/json; charset=utf-8",
            datatype: "json",
            type: 'POST',
            success: function (data) {
                switch (estado) {
                    case 1:
                        $('#modal-inicio').modal('hide');
                        $('#title-confirm').text("Iniciar proceso");
                        $('#body-confirm').text('El proceso se ha iniciado correctamente');
                        $("#modal-confirm").modal("show");
                        //alert('El proceso se ha iniciado correctamente');
                        break;
                    case 2:
                        $("#modal-pausar").modal('hide');
                        $('#title-confirm').text("Pausar proceso");
                        $('#body-confirm').text('El proceso se ha iniciado correctamente');
                        $("#modal-confirm").modal("show");
                        //alert('El proceso se ha pausado correctamente');
                        break;
                    case 3:
                        $("#modal-posponer").modal('hide');
                        $('#title-confirm').text("Posponer proceso");
                        $('#body-confirm').text('El proceso se ha pospueto correctamente');
                        $("#modal-confirm").modal("show");
                        //alert('El proceso se ha pospueto correctamente');
                        break;
                    default:
                        $("#modal-finalizar").modal('hide');
                        $('#title-confirm').text("Finalizar proceso");
                        $('#body-confirm').text('El proceso se ha finalizado correctamente');
                        $("#modal-confirm").modal("show");
                        //alert('El proceso se ha finalizado correctamente');
                        break;
                }
                
            },
            error: function () {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("El proceso no se ha iniciado correctamente. Intentelo mas tarde.");
                $("#modal-alerta").modal("show");
                //alert('El proceso no se ha iniciado correctamente. Intentelo mas tarde.')
            }
        });
}

/**
 * Dada la accion a ejecutar sobre una orden, se verifica si es posible realizarlo
 * @param {int} tipoAccion
 */
function exist_proces_ini(tipoAccion)
{
    var orden = $("#numeroOrden").val();
    if (orden == null) {
        orden = -1;
    }
    var datos = {
        'OrdenFabricacion': orden,
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
        var orden = ordenes.filter(orden => orden.ordenFabricacion == numeroOrden);
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
    monitoreo(modelo["ordenFabricacion"], modelo["botellasPlanificadas"], modelo["cajasPlanificadas"], modelo["formatoCaja"]);
}



/**
 * Ayuda a obtener la cantidad de cajas y botellas para insertarla en los indicadores correspondiente. Ademas ayuda a la creacion de las tablas que 
 * muestran los registros de cajas y botelllas. Para ello obtiene un listado de botellas y cajas para luego separarlo en dos lista y enviarlo a las
 * funciones encargadas completar los indicadores de cantidad de botellas y cajas y al las tablas de registros de botellas y cajas
 * @param {int} OrdenFabricacion
 * @param {int} botellasPlan
 * @param {int} cajasPlan
 */
function monitoreo(OrdenFabricacion, botellasPlan, cajasPlan, formato)
{
    fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
        'Fecha': fecha
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

            indicadorCantBotellas1(cantBotellas, botellasPlan);
            indicadorCantCajas1(cantCajas, cajasPlan);
            indicadorCantBotellasEquiv1(botellasEquiv, botellasPlan);
            indicadorVelocidadPorMin(OrdenFabricacion, 'botella');
            indicadorVelocidadPorMin(OrdenFabricacion, 'caja');
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

function indicadorVelocidadPorMin(OrdenFabricacion, tipoMaterial) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
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
            $('#numeroOrden').append("<option value='" + ordenes[i]["ordenFabricacion"] + "'selected><span class='label bg-start'>" + ordenes[i]["ordenFabricacion"] + "</span ></option >");
            Orden(ordenes[i]);
        }
        else {
            $('#numeroOrden').append("<option  value='" + ordenes[i]["ordenFabricacion"] + "'> <span class='label bg-gray'>" + ordenes[i]["ordenFabricacion"] + "</span></option>");
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
    document.getElementById("porcentCajas").innerHTML = "-%";

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

function fechaActual() {
    var fecha = new Date();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();

    var output = fecha.getFullYear() + '-'
        + (mes < 10 ? '0' : '') + mes + '-'
        + (dia < 10 ? '0' : '') + dia;

    return output;
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
                modal.style.display = "none";
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
        success: function (data) {
            if (data.length != 0) {
                modal.style.display = "none";
                mostrarOrdenDefault(data);
            }
            else
            {
                modal.style.display = "none";
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
        if (modal != "") {
            modal.style.display = "none";
        }
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

    if ((ordenes != null || ordenes != "" || typeof ordenes!='undefined') && ordenes.length > 0) {
        var orden = ordenes.filter(orden => orden.estado == 1 && orden.ordenFabricacion == numeroOrden);
        obtenerOrdenesAbiertasActualizadas();
        var ordenAux = ordenes.filter(orden => orden.estado == 1 && orden.ordenFabricacion == numeroOrden);
        if (orden.length != 0 && ordenAux.length != 0) {
            if (ordenAux.estado != orden.estado) {
                location.reload();
            }
            else {
                monitoreo(numeroOrden, orden[0]["botellasPlanificadas"], orden[0]["cajasPlanificadas"], orden[0]["formatoCaja"]);
            }
        }
        else if (ordenAux.length != 0) {
            location.reload();
        }
    }
    document.getElementById("horaActualizacionIndicadoresOrden").innerHTML = obtenerHora();
}
setInterval(actualizarTablasMonitoreo, 30000);

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
setInterval(actualizarPagina, 50000);