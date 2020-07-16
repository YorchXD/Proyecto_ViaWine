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

function exist_proces_ini(tipoAccion)
{
    var orden = $("#numeroOrden").val();
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
    monitoreoBotellas(modelo["OrdenFabricacion"]);
    monitoreoCajas(modelo["OrdenFabricacion"]);
    indicadorCantCajas(modelo["OrdenFabricacion"], modelo["CajasPlanificadas"]);
    indicadorCantBotellas(modelo["OrdenFabricacion"], modelo["BotellasPlanificadas"]);
    //indicadoresVelocidad(modelo["OrdenFabricacion"]);
    indicadorVelocidadBotellas(modelo["OrdenFabricacion"]);
    indicadorVelocidadCajas(modelo["OrdenFabricacion"]);
}

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

function monitoreoBotellas(OrdenFabricacion)
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
            { "data": "horaInicio", "defaultContent": "" },
            { "data": "horaTermino", "defaultContent": "" },
        ]
    });
}

function monitoreoCajas(OrdenFabricacion)
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
            { "data": "hora"},
        ], 
    });
}

function indicadorCantCajas(OrdenFabricacion, CajasPlanificadas)
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
        url: "/Proceso/GetCantBotellas",
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

/*function indicadoresVelocidad(OrdenFabricacion)
{
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Proceso/GetVelocidad",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantBotellasMin").innerHTML = data.cantBotellas;
            document.getElementById("cantCajasMin").innerHTML = data.cantCajas;
            console.log(data)
        }
    })
}*/

function indicadorVelocidadBotellas(OrdenFabricacion) {
    var datos = {
        'OrdenFabricacion': OrdenFabricacion
    };
    $.ajax({
        url: "/Proceso/GetVelocidadBotellas",
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
        url: "/Proceso/GetVelocidadCajas",
        method: "POST",
        data: datos,
        success: function (data) {
            document.getElementById("cantCajasMin").innerHTML = data;
            console.log(data)
        }
    })
}
