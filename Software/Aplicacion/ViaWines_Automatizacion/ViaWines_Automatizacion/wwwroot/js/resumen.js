var modelo = "";
var fecha = "";

function fechasOrdenes() {
    $.ajax({
        type: 'GET',
        url: '/Resumen/GetFechasOrdenes',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data) {
            // An array of dates
            var eventDates = {};

            $.each(data, function (indice, elemento) {
                //console.log('El elemento con el índice ' + indice + ' contiene ' + elemento);
                eventDates[new Date(elemento)] = new Date(elemento);
                //alert(elemento);
            });

            // datepicker
            $('#datepicker').datepicker({
                'destroy': true,
                beforeShowDay: function (date) {
                    var highlight = eventDates[date];
                    if (highlight) {
                        return [true, "event"];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", new Date());
        },
    });
}

function buscarPlanificacion()
{
    fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var datos = {
        'fecha': fecha
    };
    $.ajax({
        type: 'POST',
        url: "/Resumen/LeerPlanificaciones",
        data: datos,
        dataType: 'json',
        success: function (data) {
            resetearDatosOrden();

            if (!$.isEmptyObject(data)) {
                var hoy = fechaActual();
                modelo = data;
                if (fecha == hoy) {
                    iniciarOrdenesSelect(data);
                }
                else {
                    ordenesFechasAnteriores(data);
                }
                indicadoresDia();
                indicadorCantCajasHora();
                mostrarTablaOrdenes();
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Aun no existen ordenes para la fecha " + fecha);
                $("#modal-alerta").modal("show");
            }
        },
    });
}

function fechaActual()
{
    var hoy = new Date();
    var dd = hoy.getDate();
    var MM = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }

    if (MM < 10) {
        MM = '0' + MM;
    }

    hoy = yyyy + '-' + MM + '-' + dd;
    return hoy;
}

function resetearDatosOrden() {
    document.getElementById("cliente").innerHTML = "-";
    document.getElementById("SKU").innerHTML = "-";
    document.getElementById("secuencia").innerHTML = "-";
    document.getElementById("cantCajasPlan").innerHTML = "-";
    document.getElementById("cantBotellasPlan").innerHTML = "-";
    document.getElementById("estado").innerHTML = "-";
    document.getElementById("fechaPlan").innerHTML = "-";

    document.getElementById("cantBotellas").innerHTML = "-";
    document.getElementById("progresoBotellas").innerHTML = "<div class='progress-bar' style='width:" + 0 + "%'></div>";
    document.getElementById("porcentBotellas").innerHTML = "-% de avance";

    document.getElementById("cantCajas").innerHTML = "-";
    document.getElementById("progresoCajas").innerHTML = "<div class='progress-bar' style='width:" + 0 + "%'></div>";
    document.getElementById("porcentCajas").innerHTML = "-%";

    document.getElementById("cantBotellasMin").innerHTML = "-";
    document.getElementById("cantCajasMin").innerHTML = "-";
    $("#chartdiv1").empty();
    $("#chartdiv2").empty();
}

function iniciarOrdenesSelect(modelo)
{
    var opciones = '<option disabled selected value="null">Seleccione una orden</option>'
    for (var i = 0; modelo!=null && i < modelo.length; i++)
    {
        
        if (modelo[i]["estado"] == 1 || modelo[i]["estado"] == 2) {

            opciones += "<option value='" + modelo[i]["ordenFabricacion"] + "'selected>" + modelo[i]["ordenFabricacion"] + "</option>";
            //$('#numeroOrden').append("<option value='" + modelo[i]["ordenFabricacion"] + "'selected>" + modelo[i]["ordenFabricacion"] + "</option>");
            Orden(modelo[i]);
        }
        else
        {
            opciones += "<option value='" + modelo[i]["ordenFabricacion"] + "'>" + modelo[i]["ordenFabricacion"] + "</option>";
            //$('#numeroOrden').append("<option value='" + modelo[i]["ordenFabricacion"] + "'>" + modelo[i]["ordenFabricacion"] + "</option>");
        }
    }
    $('#numeroOrden').empty().append(opciones);
}

function ordenesFechasAnteriores(modelo)
{
    var opciones = '<option disabled selected value="null">Seleccione una orden</option>'
    for (var i = 0; modelo != null && i < modelo.length; i++) {
        opciones += "<option value='" + modelo[i]["ordenFabricacion"] + "'>" + modelo[i]["ordenFabricacion"] + "</option>";        
    }
    $('#numeroOrden').empty().append(opciones);
}

function mostrarOrden()
{
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;

    for (var i = 0; i < modelo.length; i++)
    {
        if (modelo[i]["ordenFabricacion"] == numeroOrden)
        {
            Orden(modelo[i]);
            break;
        }
    }
}


function Orden(modelo) {
    document.getElementById("cliente").innerHTML = modelo["cliente"];
    document.getElementById("SKU").innerHTML = modelo["sku"];
    document.getElementById("secuencia").innerHTML = modelo["secuencia"];
    document.getElementById("cantCajasPlan").innerHTML = modelo["cajasPlanificadas"];
    document.getElementById("cantBotellasPlan").innerHTML = modelo["botellasPlanificadas"];
    //document.getElementById("descripcionProducto").innerHTML = modelo["Descripcion"];
    //document.getElementById("horaInicioPlan").innerHTML = modelo["HoraInicioPlanificada"];
    //document.getElementById("horaTerminoPlan").innerHTML = modelo["HoraTerminoPlanificada"];
    document.getElementById("fechaPlan").innerHTML = (modelo["fechaFabricacion"]).split('T')[0];
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
    monitoreo(modelo["ordenFabricacion"], (modelo["fechaFabricacion"]).split('T')[0], modelo["botellasPlanificadas"], modelo["cajasPlanificadas"]);


    //BotCajMinHelper.CargarGrafico(modelo["OrdenFabricacion"]);
    
    //monitoreoPorMin(modelo["OrdenFabricacion"]);

    //monitoreoBotellas(modelo["OrdenFabricacion"]);
    //monitoreoCajas(modelo["OrdenFabricacion"]);
    //indicadorCantCajas(modelo["OrdenFabricacion"], modelo["CajasPlanificadas"]);
    //indicadorCantBotellas(modelo["OrdenFabricacion"], modelo["BotellasPlanificadas"]);
    //indicadorVelocidadBotellas(modelo["OrdenFabricacion"]);
    //indicadorVelocidadCajas(modelo["OrdenFabricacion"]);
    //indicadoresVelocidad(modelo["OrdenFabricacion"]);
}



/*function monitoreoPorMin(OrdenFabricacion)
{
    $.ajax({
        url: "/Resumen/GetMonitoreoOrden",
        method: "POST",
        data: { 'OrdenFabricacion': OrdenFabricacion},
        success: function (data) {
            console.log(data)
        }
    })

}*/
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
        data: { 'fecha': fecha },
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
        data: { 'fecha': fecha },
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
        data: { 'fecha': fecha },
        success: function (data) {
            document.getElementById("cantOrdenesDia").innerHTML = data.cantOrdenes;
            document.getElementById("progresoOrdenesDia").innerHTML = "<div class='progress-bar' style='width:" + data.porcentaje + "%'></div>";
            document.getElementById("porcentOrdenesDia").innerHTML = "" + data.porcentaje + "% de avance";
            console.log(data)
        }
    })
}

function indicadorCantCajasHora() {

    $.ajax({
        url: "/Resumen/GetCantCajasDia",
        method: "POST",
        data: {'fecha': fecha},
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
    BotCajHoraHelper.CargarGrafico();
}

function mostrarTablaOrdenes() {

    $('#tabla').DataTable({
        'responsive': true,
        'searching': false,
        'ordering': true,
        'info': false,
        //'autoWidth': true,
        'paging': true,
        'scrollX': true,
        'destroy': true,
        'lengthChange': false,
        "processing": true,
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
            "data": {'fecha': fecha},
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
function monitoreo(OrdenFabricacion, Fecha, botellasPlan, cajasPlan) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion,
        'Fecha': Fecha
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
            
            //console.log(botellas);
            //console.log(cajas);
            //console.log(cantBotellas);
            //console.log(cantCajas);
            indicadorCantBotellas1(cantBotellas, botellasPlan);
            indicadorCantCajas1(cantCajas, cajasPlan);
            indicadorVelocidadPorMin(OrdenFabricacion, 'botella');
            indicadorVelocidadPorMin(OrdenFabricacion, 'caja');
            BotCajMinHelper.CargarGrafico(OrdenFabricacion);
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

/*GRAFICO POR MINUTO */
var AdministradorBotCajMin = {
    GetChartData: function (ordenFabricacion) {
        var objProd = "";
        var jsonParams = { 'OrdenFabricacion': ordenFabricacion, 'fecha': fecha };
        var serviceUrl = "/Resumen/GetMonitoreoMin/";
        AdministradorBotCajMin.GetJsonResult(serviceUrl, jsonParams, false, false, onSuccess, onFailed);

        function onSuccess(jsonData) {
            objProd = jsonData;
        }

        function onFailed(error) {
            alert(error.statusText);
        }
        return objProd;
    },

    GetJsonResult: function (serviceUrl, jsonParams, isAsync, isCache, successCallback, errorCallback) {
        $.ajax({
            method: "GET",
            async: isAsync,
            cache: isCache,
            url: serviceUrl,
            data: jsonParams,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successCallback,
            error: errorCallback
        });
    }
};

var BotCajMinHelper = {
    CargarGrafico: function (numeroOrden) {
        var datos = AdministradorBotCajMin.GetChartData(numeroOrden);
        am4core.ready(function () {

            // Themes begin
            am4core.useTheme(am4themes_dataviz);
            am4core.useTheme(am4themes_animated);
            // Themes end

            var chart = am4core.create("chartdiv1", am4charts.XYChart);
            chart.data = datos;

            chart.dateFormatter.inputDateFormat = "HH:mm";
            var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
            dateAxis.renderer.minGridDistance = 60;
            dateAxis.startLocation = 0.5;
            dateAxis.endLocation = 0.5;
            dateAxis.baseInterval = {
                timeUnit: "minute",
                count: 1
            }

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.tooltip.disabled = true;

            var series = chart.series.push(new am4charts.LineSeries());
            series.dataFields.dateX = "hora";
            series.name = "Botellas";
            series.dataFields.valueY = "botellas";
            series.tooltipHTML = "<img src='img/vino.png' style='vertical-align:bottom; margin-right: 10px; width:24px; height:24px;'><span style='font-size:14px; color:#000000;'><b>{valueY.value}</b></span>";
            series.tooltipText = "[#000]{valueY.value}[/]";
            series.tooltip.background.fill = am4core.color("#FFF");
            series.tooltip.getStrokeFromObject = true;
            series.tooltip.background.strokeWidth = 3;
            series.tooltip.getFillFromObject = false;
            series.fillOpacity = 0.6;
            series.strokeWidth = 2;
            series.stacked = false;

            var bullet = series.bullets.push(new am4charts.CircleBullet());
            bullet.circle.radius = 6;
            bullet.circle.fill = am4core.color("#fff");
            bullet.circle.strokeWidth = 3;

            var series2 = chart.series.push(new am4charts.LineSeries());
            series2.name = "Cajas";
            series2.dataFields.dateX = "hora";
            series2.dataFields.valueY = "cajas";
            series2.tooltipHTML = "<img src='img/botellas-de-vino.png' style='vertical-align:bottom; margin-right: 10px; width:24px; height:24px;'><span style='font-size:14px; color:#000000;'><b>{valueY.value}</b></span>";
            series2.tooltipText = "[#000]{valueY.value}[/]";
            series2.tooltip.background.fill = am4core.color("#FFF");
            series2.tooltip.getFillFromObject = false;
            series2.tooltip.getStrokeFromObject = true;
            series2.tooltip.background.strokeWidth = 3;
            series2.sequencedInterpolation = true;
            series2.fillOpacity = 0.6;
            series2.stacked = false;
            series2.strokeWidth = 2;

            var bullet2 = series2.bullets.push(new am4charts.CircleBullet());
            bullet2.circle.radius = 6;
            bullet2.circle.fill = am4core.color("#fff");
            bullet2.circle.strokeWidth = 3;

            chart.cursor = new am4charts.XYCursor();
            chart.cursor.xAxis = dateAxis;
            chart.scrollbarX = new am4core.Scrollbar();

            // Add a legend
            chart.legend = new am4charts.Legend();
            chart.legend.position = "top";

            // Pre-zoom init
            dateAxis.start = 0.8;
            dateAxis.end = 5;
            dateAxis.keepSelection = true;

        }); // end am4core.ready()
    }
}
/*FIN GRAFICO POR MINUTO*/

/*GRAFICO POR HORA*/
var AdministradorBotCajHora = {
    GetChartData: function () {
        var objProd = "";
        var jsonParams = { 'fecha': fecha };
        var serviceUrl = "/Resumen/GetMonitoreoHora/";
        AdministradorBotCajHora.GetJsonResult(serviceUrl, jsonParams, false, false, onSuccess, onFailed);

        function onSuccess(jsonData) {
            objProd = jsonData;
        }

        function onFailed(error) {
            alert(error.statusText);
        }
        return objProd;
    },

    GetJsonResult: function (serviceUrl, jsonParams, isAsync, isCache, successCallback, errorCallback) {
        $.ajax({
            method: "GET",
            async: isAsync,
            cache: isCache,
            url: serviceUrl,
            data: jsonParams,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successCallback,
            error: errorCallback
        });
    }
};

var BotCajHoraHelper = {
    CargarGrafico: function () {
        var datos = AdministradorBotCajHora.GetChartData();
        am4core.ready(function () {

            // Themes begin
            am4core.useTheme(am4themes_dataviz);
            am4core.useTheme(am4themes_animated);
            // Themes end

            var chart = am4core.create("chartdiv2", am4charts.XYChart);
            chart.data = datos;

            chart.dateFormatter.inputDateFormat = "HH:mm";
            var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
            dateAxis.renderer.minGridDistance = 60;
            dateAxis.startLocation = 0.5;
            dateAxis.endLocation = 0.5;
            dateAxis.baseInterval = {
                timeUnit: "minute",
                count: 1
            }

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.tooltip.disabled = true;

            var series = chart.series.push(new am4charts.LineSeries());
            series.dataFields.dateX = "hora";
            series.name = "Botellas";
            series.dataFields.valueY = "botellas";
            series.tooltipHTML = "<img src='img/vino.png' style='vertical-align:bottom; margin-right: 10px; width:24px; height:24px;'><span style='font-size:14px; color:#000000;'><b>{valueY.value}</b></span>";
            series.tooltipText = "[#000]{valueY.value}[/]";
            series.tooltip.background.fill = am4core.color("#FFF");
            series.tooltip.getStrokeFromObject = true;
            series.tooltip.background.strokeWidth = 3;
            series.tooltip.getFillFromObject = false;
            series.fillOpacity = 0.6;
            series.strokeWidth = 2;
            series.stacked = false;

            var bullet = series.bullets.push(new am4charts.CircleBullet());
            //bullet.circle.radius = 6;
            bullet.circle.fill = am4core.color("#fff");
            bullet.circle.strokeWidth = 3;

            var series2 = chart.series.push(new am4charts.LineSeries());
            series2.name = "Cajas";
            series2.dataFields.dateX = "hora";
            series2.dataFields.valueY = "cajas";
            series2.tooltipHTML = "<img src='img/botellas-de-vino.png' style='vertical-align:bottom; margin-right: 10px; width:24px; height:24px;'><span style='font-size:14px; color:#000000;'><b>{valueY.value}</b></span>";
            series2.tooltipText = "[#000]{valueY.value}[/]";
            series2.tooltip.background.fill = am4core.color("#FFF");
            series2.tooltip.getFillFromObject = false;
            series2.tooltip.getStrokeFromObject = true;
            series2.tooltip.background.strokeWidth = 3;
            series2.sequencedInterpolation = true;
            series2.fillOpacity = 0.6;
            series2.stacked = false;
            series2.strokeWidth = 2;

            var bullet2 = series2.bullets.push(new am4charts.CircleBullet());
            bullet2.circle.radius = 6;
            bullet2.circle.fill = am4core.color("#fff");
            bullet2.circle.strokeWidth = 3;

            chart.cursor = new am4charts.XYCursor();
            chart.cursor.xAxis = dateAxis;
            chart.scrollbarX = new am4core.Scrollbar();

            // Add a legend
            chart.legend = new am4charts.Legend();
            chart.legend.position = "top";

        }); // end am4core.ready()
    }
}

/*FIN GRAFICO POR HORA*/

function actualizarIndicadores() {
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    for (var i = 0; (modelo != null || modelo != "") && i < modelo.length; i++) {
        if (numeroOrden == modelo[i]["ordenFabricacion"] && modelo[i]["estado"] == 1) {
            monitoreo(modelo[i]["ordenFabricacion"], (modelo[i]["fechaFabricacion"]).split('T')[0], modelo[i]["botellasPlanificadas"], modelo[i]["cajasPlanificadas"]);
            break;
        }
    }
    indicadoresDia();
    document.getElementById("horaActualizacionIndicadoresOrden").innerHTML = obtenerHora();
    document.getElementById("horaActualizacionIndicadoresDia").innerHTML = obtenerHora();


}
setInterval(actualizarIndicadores, 60 * 1000);

function actualizarIndicadorHora() {
    indicadorCantBotellasHora();
}
setInterval(actualizarIndicadorHora, 60 * 60 * 1000);