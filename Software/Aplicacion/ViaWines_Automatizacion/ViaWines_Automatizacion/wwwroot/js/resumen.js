function iniciarOrdenesSelect(modelo)
{
    for (var i = 0; modelo!=null && i < modelo.length; i++)
    {
        if (modelo[i]["Estado"] == 1)
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
    //monitoreoBotellas(modelo["OrdenFabricacion"]);
    //monitoreoCajas(modelo["OrdenFabricacion"]);
    indicadorCantCajas(modelo["OrdenFabricacion"], modelo["CajasPlanificadas"]);
    indicadorCantBotellas(modelo["OrdenFabricacion"], modelo["BotellasPlanificadas"]);
    indicadoresVelocidad(modelo["OrdenFabricacion"]);
}

function indicadorCantCajas(OrdenFabricacion, CajasPlanificadas)
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
}

function indicadoresVelocidad(OrdenFabricacion)
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
}


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
        'searching': true,
        'ordering': true,
        'info': false,
        'autoWidth': true,
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
                            estadoAux = "<span class='label bg-purple'>Iniciada</span>"
                            break;
                        case 2:
                            estadoAux = "<span class='label bg-orange'>Pausada</span>"
                            break;
                        case 3:
                            estadoAux = "<span class='label bg-maroon'>Pospuesta</span>"
                            break;
                        case 4:
                            estadoAux = "<span class='label bg-olive'>Finalizada</span>";
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
                                "<div class='progress-bar bg-purple' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        case 2:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-orange' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        case 3:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-maroon' style='width: " + full.porcentajeAvance + "%'></div>" +
                                "</div>";
                            break;
                        case 4:
                            progreso = "<div class='progress progress-xs progress-striped active'>" +
                                "<div class='progress-bar bg-olive' style='width: " + full.porcentajeAvance + "%'></div>" +
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
                            porcentaje = "<span class='label bg-purple'>" + full.porcentajeAvance + "%</span>";
                            break;
                        case 2:
                            porcentaje = "<span class='label bg-orange'>" + full.porcentajeAvance + "%</span>";
                            break;
                        case 3:
                            porcentaje = "<span class='label bg-maroon'>" + full.porcentajeAvance + "%</span>"
                            break;
                        case 4:
                            porcentaje = "<span class='label bg-olive'>" + full.porcentajeAvance + "%</span>";
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