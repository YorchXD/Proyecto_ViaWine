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

function mostrarOrden(modelo)
{
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;

    for (var i = 0; i < modelo.length; i++)
    {
        if (modelo[i]["OrdenFabricacion"] == numeroOrden)
        {
            Orden(modelo[i]);
            break;
        }
    }
}

function Orden(modelo) {
    document.getElementById("cliente").innerHTML = modelo["Cliente"];
    document.getElementById("SKU").innerHTML = modelo["SKU"];
    document.getElementById("secuencia").innerHTML = modelo["Secuencia"];
    document.getElementById("cantCajasPlan").innerHTML = modelo["CajasPlanificadas"];
    document.getElementById("cantBotellasPlan").innerHTML = modelo["BotellasPlanificadas"];
    //document.getElementById("descripcionProducto").innerHTML = modelo["Descripcion"];
    //document.getElementById("horaInicioPlan").innerHTML = modelo["HoraInicioPlanificada"];
    //document.getElementById("horaTerminoPlan").innerHTML = modelo["HoraTerminoPlanificada"];
    //document.getElementById("fechaPlan").innerHTML = (modelo["FechaFabricacion"]).split('T')[0];
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
    //indicadoresVelocidad(modelo["OrdenFabricacion"]);
}

/*function indicadorCantCajas(OrdenFabricacion, CajasPlanificadas)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
        'CajasPlanificadas': CajasPlanificadas
    };
    $.ajax({
        url: "/Resumen/GetCantCajas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantCajas").innerHTML = data.cantCajas;
            document.getElementById("progresoCajas").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentCajas").innerHTML = "" + data.porcentaje + "% de avance";
            console.log(data)
        }
    })
}

function indicadorCantBotellas(OrdenFabricacion, BotellasPlanificadas)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
        'BotellasPlanificadas': BotellasPlanificadas
    };
    $.ajax({
        url: "/Resumen/GetCantBotellas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantBotellas").innerHTML = data.cantBotellas;
            document.getElementById("progresoBotellas").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentBotellas").innerHTML = "" + data.porcentaje + "% de avance";
            console.log(data)
        }
    })
}*/

/*function indicadoresVelocidad(OrdenFabricacion)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Resumen/GetVelocidad",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantBotellasMin").innerHTML = data.cantBotellas;
            document.getElementById("cantCajasMin").innerHTML = data.cantCajas;
            console.log(data)
        }
    })
}*/


function indicadorCantBotellasDia() {
    $.ajax({
        url: "/Resumen/GetCantBotellasDia",
        method: "POST",
        data: {},
        success: function (data) {
            document.getElementById("cantBotellasDia").innerHTML = data.cantBotellas;
            document.getElementById("progresoBotellasDia").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentBotellasDia").innerHTML = "" + data.porcentaje + "% de avance";
            console.log(data)
        }
    })
}

function indicadorCantCajasDia() {

    $.ajax({
        url: "/Resumen/GetCantCajasDia",
        method: "POST",
        data: {},
        success: function (data) {
            document.getElementById("cantCajasDia").innerHTML = data.cantCajas;
            document.getElementById("progresoCajasDia").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentCajasDia").innerHTML = "" + data.porcentaje + "% de avance";
            console.log(data)
        }
    })
}

function indicadorCantOrdenesDia() {

    $.ajax({
        url: "/Resumen/GetCantOrdenesDia",
        method: "POST",
        data: {},
        success: function (data) {
            document.getElementById("cantOrdenesDia").innerHTML = data.cantOrdenes;
            document.getElementById("progresoOrdenesDia").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentOrdenesDia").innerHTML = "" + data.porcentaje + "% de avance";
            console.log(data)
        }
    })
}

function indicadorCantBotellasHora() {

    $.ajax({
        url: "/Resumen/GetCantBotellasDia",
        method: "POST",
        data: {},
        success: function (data) {
            var hoy = new Date();
            document.getElementById("porcentajePorHora").innerHTML = "" + data.porcentaje + "%";
            document.getElementById("progresoPorHora").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("horaPorcentaje").innerHTML = "Hora del avance: " + hoy.getHours() + ":00";
        }
    })
}

function indicadoresDia()
{
    indicadorCantBotellasDia();
    indicadorCantCajasDia();
    indicadorCantOrdenesDia();
}

function mostrarTablaOrdenes() {

    $('#tabla').DataTable({
        'responsive': true,
        'searching': true,
        'ordering': true,
        'info': false,
        //'autoWidth': true,
        'paging': true,
        'scrollX': true,
        'destroy': true,
        'lengthChange': false,
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
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        'ajax': {
            "url": "/Resumen/GetOrdenes",
            "method": "POST",
            "data": {},
            "dataSrc": "",
        },
        'aoColumns': [
            { "data": "secuencia" },
            { "data": "ordenFabricacion" },
            { "data": "cliente" },
            {
                "data": "estado", "render": function (estado) {
                    var estadoAux = "";
                    switch (estado) {
                        case 1:
                            estadoAux = "<span class='label bg-start'>Iniciada</span>"
                            break;
                        case 2:
                            estadoAux = "<span class='label bg-pause'>Pausada</span>"
                            break;
                        case 3:
                            estadoAux = "<span class='label bg-postpone'>Pospuesta</span>"
                            break;
                        case 4:
                            estadoAux = "<span class='label bg-end'>Finalizada</span>";
                            break;
                        default:
                            estadoAux = "<span class='label bg-gray'>No iniciada</span>";
                    }
                    return estadoAux;
                }
            },
            {
                "render": function (data, type, full) {
                    var progreso = "";
                    switch (full.estado) {
                        case 1:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-start' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        case 2:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-pause' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        case 3:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-postpone' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        case 4:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-end' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        default:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-gray' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                    }
                    return progreso;
                }
            },

            {
                "render": function (data, type, full) {
                    var porcentaje = "";
                    switch (full.estado) {
                        case 1:
                            porcentaje = "<span class='label bg-start'>" + full.porcentajeAvance + "%</span>";
                            break;
                        case 2:
                            porcentaje = "<span class='label bg-pause'>" + full.porcentajeAvance + "%</span>";
                            break;
                        case 3:
                            porcentaje = "<span class='label bg-postpone'>" + full.porcentajeAvance + "%</span>"
                            break;
                        case 4:
                            porcentaje = "<span class='label bg-end'>" + full.porcentajeAvance + "%</span>";
                            break;
                        default:
                            porcentaje = "<span class='label bg-gray'>" + full.porcentajeAvance + "%</span>";
                    }
                    return porcentaje;
                }
            },
        ]
    });
}

/*function indicadorVelocidadBotellas(OrdenFabricacion) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Resumen/GetVelocidadBotellas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantBotellasMin").innerHTML = data;
            console.log(data)
        }
    })
}

function indicadorVelocidadCajas(OrdenFabricacion) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Resumen/GetVelocidadCajas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantCajasMin").innerHTML = data;
            console.log(data)
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
function monitoreo(OrdenFabricacion, botellasPlan, cajasPlan) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Resumen/GetMonitoreoMateriales",
        method: "POST",
        data: datos,
        success: function (data) {
            console.log(data);
            var botellas = {};
            var cajas = {};
            var cantBotellas = 0;
            var cantCajas = 0;
            if (Object.entries(data).length!=0)
            {
                botellas = data.filter(element => element.tipo == "Botella");
                cajas = data.filter(element => element.tipo == "Caja");
                cantBotellas = botellas.length;
                cantCajas = cajas.length;
            }
            
            console.log(botellas);
            console.log(cajas);
            console.log(cantBotellas);
            console.log(cantCajas);
            indicadorCantBotellas1(cantBotellas, botellasPlan);
            indicadorCantCajas1(cantCajas, cajasPlan);
            indicadorVelocidadPorMin(OrdenFabricacion, 'botella');
            indicadorVelocidadPorMin(OrdenFabricacion, 'caja');
        }
    })
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
function indicadorCantBotellas1(cantBotellas, botellasPlan) {
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
        success: function (data) {
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