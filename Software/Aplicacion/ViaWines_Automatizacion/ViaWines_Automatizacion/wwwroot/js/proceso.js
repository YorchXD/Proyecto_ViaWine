﻿/**
 * Se encarga de actualizar el estado de una orden en particular
 * @param {int} estado
 */
function Actualizar_Estado(estado)
{
    var orden = $("#numeroOrden").val();
    var datos = {
        'OrdenFabricacion': orden,
        'Estado': estado
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
                        alert('El proceso se ha iniciado correctamente');
                        break;
                    case 2:
                        $("#modal-pausar").modal('hide');
                        alert('El proceso se ha pausado correctamente');
                        break;
                    case 3:
                        $("#modal-posponer").modal('hide');
                        alert('El proceso se ha pospueto correctamente');
                        break;
                    default:
                        $("#modal-finalizar").modal('hide');
                        alert('El proceso se ha finalizado correctamente');
                        break;
                }
                location.reload();
            },
            error: function () {
                alert('El proceso no se ha iniciado correctamente. Intentelo mas tarde.')
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
            alert("Error inesperado, vuelva a intentarlo mas tarde o contactese con Tibox para informar en detalle cuando ocurrió el error.");
        },
    });
}

function mostrarOrden(modelo)
{
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    
    for (var i = 0; modelo!=null && i < modelo.length; i++)
    {
        if (modelo[i]["OrdenFabricacion"] == numeroOrden)
        {
            Orden(modelo[i]);
            break;
        }
    }
}

function Orden(modelo)
{
    document.getElementById("SKU").innerHTML = modelo["SKU"];
    document.getElementById("descripcionProducto").innerHTML = modelo["Descripcion"];
    document.getElementById("cantCajasPlan").innerHTML = modelo["CajasPlanificadas"];
    document.getElementById("cantBotellasPlan").innerHTML = modelo["BotellasPlanificadas"];
    document.getElementById("horaInicioPlan").innerHTML = modelo["HoraInicioPlanificada"];
    document.getElementById("horaTerminoPlan").innerHTML = modelo["HoraTerminoPlanificada"];
    document.getElementById("fechaPlan").innerHTML = (modelo["FechaFabricacion"]).split('T')[0];
    switch (modelo["Estado"]) {
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
    monitoreo(modelo["OrdenFabricacion"], modelo["BotellasPlanificadas"], modelo["CajasPlanificadas"])
    //monitoreoBotellas(modelo["OrdenFabricacion"]);
    //monitoreoCajas(modelo["OrdenFabricacion"]);
    //indicadorCantCajas(modelo["OrdenFabricacion"], modelo["CajasPlanificadas"]);
    //indicadorCantBotellas(modelo["OrdenFabricacion"], modelo["BotellasPlanificadas"]);
    //indicadorVelocidadBotellas(modelo["OrdenFabricacion"]);
    //indicadorVelocidadCajas(modelo["OrdenFabricacion"]);
}

function iniciarOrdenesSelect(modelo)
{
    for (var i = 0; modelo!=null && i < modelo.length; i++)
    {
        if (modelo[i]["Estado"] == 1 || modelo[i]["Estado"] == 2)
        {
            $('#numeroOrden').append("<option value='" + modelo[i]["OrdenFabricacion"] + "'selected>" + modelo[i]["OrdenFabricacion"] + "</option>");
            Orden(modelo[i]);
        }
        else
        {
            $('#numeroOrden').append("<option value='" + modelo[i]["OrdenFabricacion"] + "'>" + modelo[i]["OrdenFabricacion"] + "</option>");
        }
    }
}

/*function monitoreoBotellas(OrdenFabricacion)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $('#tablaBotellas').DataTable({
        'searching': false,
        'ordering': true,
        'info': false,
        'autoWidth': true,
        'paging': true,
        'scrollX': false,
        'destroy': true,
        'lengthChange': false,
        'responsive': true,
        'aaSorting': [[0, 'desc']],
        //"processing": true,
        'language': {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": ">",
                "previous": "<"
            }
        },

        'ajax': {
            "url": "/Proceso/GetMonitoreoBotellas",
            "method": "POST",
            "data": datos,
            "dataSrc": ""
        },

        'columns': [
            { "data": "id", "defaultContent": "" },
            { "data": "fechaHoraTermino", "defaultContent": "" },
        ]
    });
}*/

/*function monitoreoCajas(OrdenFabricacion)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $('#tablaCajas').DataTable({
        'searching': false,
        'ordering': true,
        'info': false,
        'autoWidth': true,
        'paging': true,
        'scrollX': false,
        'destroy': true,
        'lengthChange': false,
        'responsive': true,
        "serverSide": false,
        "aaSorting": [[0, "desc"]],
        //"processing": true,
        'language': {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": ">",
                "previous": "<"
            }
        },
        'ajax': {
            "url": "/Proceso/GetMonitoreoCajas",
            "method": "POST",
            "data": datos,
            "dataSrc": ""
        },
        'columns': [
            { "data": "id"},
            { "data": "fechaHoraTermino"},
        ], 
    });
}*/

/*function indicadorCantCajas(OrdenFabricacion, CajasPlanificadas)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
        'CajasPlanificadas': CajasPlanificadas
    };
    $.ajax({
        url: "/Proceso/GetCantCajas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantCajas").innerHTML = data.cantCajas;
            document.getElementById("progresoCajas").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentCajas").innerHTML = "" + data.porcentaje + "% de avance";
            //console.log(data)
        }
    })
}*/

/*function indicadorCantBotellas(OrdenFabricacion, BotellasPlanificadas)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
        'BotellasPlanificadas': BotellasPlanificadas
    };
    $.ajax({
        url: "/Proceso/GetCantBotellas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantBotellas").innerHTML = data.cantBotellas;
            document.getElementById("progresoBotellas").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentBotellas").innerHTML = "" + data.porcentaje + "% de avance";
            //console.log(data)
        }
    })
}*/

/*function indicadorVelocidadBotellas(OrdenFabricacion) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Proceso/GetVelocidadBotellas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantBotellasMin").innerHTML = data;
            //console.log(data)
        }
    })
}*/

/*function indicadorVelocidadCajas(OrdenFabricacion) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Proceso/GetVelocidadCajas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantCajasMin").innerHTML = data;
            //console.log(data)
        }
    })
}*/

/**
 * Ayuda a obtener la cantidad de cajas y botellas para insertarla en los indicadores correspondiente. Ademas ayuda a la creacion de las tablas que 
 * muestran los registros de cajas y botelllas. Para ello obtiene un listado de botellas y cajas para luego separarlo en dos lista y enviarlo a las
 * funciones encargadas completar los indicadores de cantidad de botellas y cajas y al las tablas de registros de botellas y cajas
 * @param {int} OrdenFabricacion
 * @param {int} botellasPlan
 * @param {int} cajasPlan
 */
function monitoreo(OrdenFabricacion, botellasPlan, cajasPlan)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Proceso/GetMonitoreoMateriales",
        method: "POST",
        data: datos,
        success: function (data) {
            
            var botellas = data.filter(element => element.tipo == "Botella");
            var cajas = data.filter(element => element.tipo == "Caja");
            var cantBotellas = botellas.length;
            var cantCajas = cajas.length;
            console.log(botellas);
            console.log(cajas);
            console.log(cantBotellas);
            console.log(cantCajas);
            indicadorCantBotellas1(cantBotellas, botellasPlan);
            indicadorCantCajas1(cantCajas, cajasPlan);
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
            
            //console.log(data)
        }
    })
}

/**
 * Consulta si la orden esta iniciada
 * @param {int} OrdenFabricacion
 */
function esOrdenIniciada(OrdenFabricacion) {
    $.ajax({
        url: "/Proceso/EsOrdenIniciada",
        method: "POST",
        success: function (data) {
            return data;
        }
    })
}


function monitoreoBotellas1(botellas) {

    $('#tablaBotellas').DataTable({
        'searching': false,
        'ordering': true,
        'info': false,
        'autoWidth': true,
        'paging': true,
        'scrollX': false,
        'destroy': true,
        'lengthChange': false,
        'responsive': true,
        'aaSorting': [[0, 'desc']],
        //"processing": true,
        'language': {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": ">",
                "previous": "<"
            }
        },
        'data': botellas,

        'columns': [
            { "data": "id"},
            {
                "data": "fechaHora", render: function (d) {
                    return moment(d).format("YYYY-MM-DD HH:mm:ss");
                }},
        ]
    });
}

function monitoreoCajas1(cajas) {

    $('#tablaCajas').DataTable({
        'searching': false,
        'ordering': true,
        'info': false,
        'autoWidth': true,
        'paging': true,
        'scrollX': false,
        'destroy': true,
        'lengthChange': false,
        'responsive': true,
        "serverSide": false,
        "aaSorting": [[0, "desc"]],
        //"processing": true,
        'language': {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": ">",
                "previous": "<"
            }
        },
        'data': cajas,
        'columns': [
            { "data": "id" },
            {
                "data": "fechaHora", render: function (d) {
                    return moment(d).format("YYYY-MM-DD HH:mm:ss");
                }},
        ],
    });
}





