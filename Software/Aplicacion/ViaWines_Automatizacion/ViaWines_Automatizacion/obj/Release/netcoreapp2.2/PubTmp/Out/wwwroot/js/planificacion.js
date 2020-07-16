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
            "dataSrc": "",
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
            { "data": "horaInicio" },
            { "data": "horaTermino" },
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

function planificacionDisponible() {
    
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



function seleccionarBuscarPlanificacion(fecha)
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
    console.log(hoy);

    if (fecha == hoy) {
        mostrarTablaOrdenes(fecha, 1)
    }
    else {
        mostrarTablaOrdenes(fecha, 2)
    }
}
