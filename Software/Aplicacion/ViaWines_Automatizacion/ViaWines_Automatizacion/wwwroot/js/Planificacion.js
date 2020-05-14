﻿/*function mostrarPlanificacion() {
    $("#obtenerOrdenes").on("click", function () {
        test();
    });
}*/


/*function test() {
    var fecha = $("#datepicker").val();
    var datos = {
        fecha: fecha
    };
    $.ajax({
        method: "POST",
        dataType: "json; charset = utf-8",
        data: datos,
        dataType: "json",
        url: "/Planificacion/GetPlanificacion",
    }).done(function (info) {
        console.log(info);
    });
}*/

function mostrarTablaOrdenes(fecha, opcion) {
    var datos = {
        'fecha': fecha,
        'opcion': opcion
    };
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
            "url": "/Planificacion/GetPlanificacion",
            "method": "POST",
            "data": datos,
            "dataSrc": ""
        },
        'columns': [
            { "data": "secuencia" },
            { "data": "ordenFabricacion" },
            { "data": "version" },
            { "data": "cliente" },
            { "data": "sku" },
            { "data": "descripcion" },
            { "data": "botellasPlanificadas" },
            { "data": "botellasFabricadas" },
            { "data": "cajasPlanificadas" },
            { "data": "cajasFabricadas" },
            { "data": "fechaFabricacion" },
            { "data": "horaInicioPlanificada" },
            { "data": "horaTerminoPlanificada" },
            { "data": "estado" },
            { "data": "porcentajeAvance" },
        ]
    });
}

function planificacionDisponible1() {
    
    $.ajax({
        type: 'GET',
        url: '/Planificacion/GetFechasPlanificacion',
        data: {},
        dataType: 'json',
        success: function (data) {
            // An array of dates
            var eventDates = {};

            $.each(data, function (indice, elemento) {
                console.log('El elemento con el índice ' + indice + ' contiene ' + elemento);
                eventDates[new Date(elemento)] = new Date(elemento);
                //alert(elemento);
            });

            // datepicker
            $('#datepicker').datepicker({
                'destroy': true,
                beforeShowDay: function (date) {
                    var highlight = eventDates[date];
                    if (highlight) {
                        return [true, "event", 'Tooltip text'];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", new Date());
        },
    });
}



function seleccionarBuscarPlanificacion(fecha) {
    
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
    console.log(hoy);

    if (fecha == hoy) {
        mostrarTablaOrdenes(fecha, 1)
    }
    else {
        mostrarTablaOrdenes(fecha, 2)
    }
}



/*function planificacionDisponible() {

    // An array of dates
    var eventDates = {};
    eventDates[new Date('04/28/2020')] = new Date('04/28/2020');
    eventDates[new Date('04/29/2020')] = new Date('04/29/2020');
    eventDates[new Date('05/09/2020')] = new Date('05/07/2020');
    eventDates[new Date('05/12/2020')] = new Date('05/12/2020');
    eventDates[new Date('05/18/2020')] = new Date('05/18/2020');
    eventDates[new Date('05/23/2020')] = new Date('05/23/2020')

    // datepicker
    $('#datepicker').datepicker({
        beforeShowDay: function (date) {
            var highlight = eventDates[date];
            if (highlight) {
                return [true, "event", 'Tooltip text'];
            } else {
                return [false, '', ''];
            }
        }
    }).datepicker("setDate", new Date());
}*/